using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
// 해당 스크립트를 추가한 게임 오브젝트에 필요한 컴포넌트가 없다면 자동으로 추가한다.
// (Rigidbody, SphereCollider, Animator)

public class EnemyMovement : MonoBehaviour
{
    public float pursuitSpeed;
    public float wanderSpeed; // 평상시 속도
    public float currentSpeed; // 현재 속도

    public float directionChangeInterval; // 배회할 방향의 전환 빈도
    public bool followPlayer; // 플레이어 추적 기능 (off시 배회만)

    Coroutine moveCoroutine; // 현재 실행중인 이동 코루틴 참조를 저장 (적을 목적지로 옮김)
    SphereCollider sphereCollider; 
    Rigidbody rigidbody;
    Animator animator;

    Transform targetTransform = null; // 플레이어를 추적할 때 사용 (PlayerObject의 transform을 얻어 targetTransform에 대입)
    Vector3 endPosition; // 배회하는 캐릭터의 목적지
    float currenAngle = 0; // 배회할 방향을 바꿀 경우 기존 각도에 새로운 각도 더해줌

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        currentSpeed = wanderSpeed;
        StartCoroutine(WanderRoutine());
        // currentSpeed에 wanderSpeed를 현재 속도로 저장, 처음에는 배회하는 속도로 적이 천천히 움직이도록
    }

    void Update()
    {
        Debug.DrawLine(rigidbody.position, endPosition, Color.red);
    }

    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndPoint(); // 새로운 목적지를 선택함

            if(moveCoroutine != null) // null인지 아닌지를 확인해 적의 이동여부 체크 (null이 아니라면 이동 중)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rigidbody, currentSpeed));
        }
    }

    void ChooseNewEndPoint()
    {
        currenAngle += Random.Range(0, 360); // 0~360 사이 값 무작위 선택 -> currentAngle값과 무작위 값 더함 -> 새로운 방향 나타내는 각도
        currenAngle = Mathf.Repeat(currenAngle, 360); // 주어진 값이 지정한 값의 범위 안에 들 때까지 반복 (360보다 작거나 클 수 없다)
        endPosition += Vector3FromAngle(currenAngle); // 결과 값을 endposition 값에 더하고 대입
    }

    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadius = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleRadius), Mathf.Sin(inputAngleRadius), 0);
        // 입력받은 inputAngleDegrees 값에 Mathf.Deg2Rad 상수를 곱해 변환
        //변환한 값을 사용해 적의 방향으로 사용할 Vector 생성
    }

    public IEnumerator Move(Rigidbody rigidBodyToMove, float speed)
    {
        float remainingDistance = (transform.position - endPosition).sqrMagnitude;
        while(remainingDistance > float.Epsilon)
        {
            if(targetTransform != null)
            {
                endPosition = targetTransform.position;
            }
            if(rigidBodyToMove != null)
            {
                animator.SetBool("isWalking", true);
                Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);

                rigidbody.MovePosition(newPosition);
                remainingDistance = (transform.position - endPosition).sqrMagnitude;
            }

            yield return new WaitForFixedUpdate();
        }
        animator.SetBool("isWalking", false);
    }

    private void OnTriggerEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && followPlayer)
        {
            currentSpeed = pursuitSpeed;
            targetTransform = collision.gameObject.transform;
            if(moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            moveCoroutine = StartCoroutine(Move(rigidbody, currentSpeed));
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isWalking", false);
            currentSpeed = wanderSpeed;

            if(moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }
            targetTransform = null;
        }
    }

    void OnDrawGizmos()
    {
        if(sphereCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
        }
    }
}


// https://my-develop-note.tistory.com/35