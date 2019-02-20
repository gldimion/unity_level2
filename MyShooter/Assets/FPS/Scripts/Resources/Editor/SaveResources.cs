using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public static class SaveResources
{
    [MenuItem("Geekbrains/Lesson6HW/Save Resources")]
    private static void Save()
    {
        string path = Path.Combine(Application.dataPath, "ResourcesData.json");

        var objs = Object.FindObjectsOfType<FPS.BaseEnemy>();
        var dataList = new List<string>();

        foreach (var o in objs)
        {
            var data = new EnemyData
            {
                PrefabName = PrefabUtility.GetPrefabParent(o).name,
                Pos = o.transform.position,
                Rot = o.transform.rotation,
                Scale = o.transform.localScale
            };

            dataList.Add(JsonUtility.ToJson(data));
        }

        using (var sw = new StreamWriter(path))
        {
            foreach (string s in dataList)
                sw.WriteLine(s);
        }

        Debug.Log("Data saved");
    }
}
