using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Diagnostics;

public class BuildAndroid 
{
    private const string APP_NAME = "Palette";
    private const string ARCHIVE_PATH = "../Bin/Android/";
 

    [MenuItem("Build/Build_Android")]
    public static void Build_Android()
    {
        string output;
        string hostname = "";
        string revision = "";
        string APK_PATH = Path.Combine(Application.dataPath, ARCHIVE_PATH);

       int i = 0;
        using (Process process = new Process())
        {
            process.StartInfo.FileName = Path.Combine(Application.dataPath, "../Batch_Script/Git_Revision.bat");
            process.StartInfo.Arguments = "";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WorkingDirectory = "";
            process.Start();
    
            while ((output = process.StandardOutput.ReadLine()) != null)
            {
                i++;
                if (i == 3)
                {
                    hostname = output;
                }
                bool isNumber = int.TryParse(output, out int n);
                if (isNumber)
                {
                    revision = output;
                }
            }
            process.WaitForExit();
        }

        if (Directory.Exists(APK_PATH))
        {
            DeleteDirectory(APK_PATH);
        }
        else
        {
            Directory.CreateDirectory(APK_PATH);
        }
      
        string fileName = SetPlayerSettingsForAndroid(hostname, revision);
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        string apk_path = APK_PATH + fileName;
        buildPlayerOptions.locationPathName = apk_path;
        buildPlayerOptions.scenes = GetBuildSceneList();
        buildPlayerOptions.target = BuildTarget.Android;
        BuildPipeline.BuildPlayer(buildPlayerOptions);

    }

    private static string[] GetBuildSceneList()
    {
        EditorBuildSettingsScene[] scene = UnityEditor.EditorBuildSettings.scenes;
        List<string> listScenePath = new List<string>();
        for (int i = 0; i < scene.Length; i++ )
        {
            if (scene[i].enabled)
            {
                listScenePath.Add(scene[i].path);
            }
        }
        return listScenePath.ToArray();
    }

    private static string SetPlayerSettingsForAndroid(string hostname, string revision)
    {
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.All;
        string fileName = string.Format("{0}_{1}_{2}.apk", APP_NAME, revision, hostname);
        return fileName;
    }

    static void DeleteDirectory(string _folderPath)
    {
        File.SetAttributes(_folderPath, FileAttributes.Normal); //폴더 읽기 전용 해제

        foreach (string _folder in Directory.GetDirectories(_folderPath)) //폴더 탐색
        {
            DeleteDirectory(_folder); //재귀 호출
        }

        foreach (string _file in Directory.GetFiles(_folderPath)) //파일 탐색
        {
            File.SetAttributes(_file, FileAttributes.Normal); //파일 읽기 전용 해제
            File.Delete(_file); //파일 삭제
        }

        Directory.Delete(_folderPath); //폴더 삭제
    }
}
