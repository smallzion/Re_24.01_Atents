using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Test_SaveFile : MonoBehaviour
{
    void SaveFile()
    {
        string[] data1 = {"aaa" ,"bbb", "ccc", "ddd", "eee"};
        int[] data2 = { 11,22,33,44,55 };
        SaveData saveData = new SaveData();
        saveData.rankerNames = data1;
        saveData.highScores = data2;
        string jsonText = JsonUtility.ToJson(saveData);
        string path = $"{Application.dataPath}/Save/";
        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string fullPath = path + "data.json";
        File.WriteAllText(fullPath, jsonText);
    }

    private void Start()
    {
        SaveFile();
    }
}
