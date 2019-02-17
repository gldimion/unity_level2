using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadResources : MonoBehaviour
{
    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        string path = Path.Combine(Application.dataPath, "ResourcesData.json");
        if (!File.Exists(path)) return;

        List<EnemyData> enemies = new List<EnemyData>();

        using (var sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                enemies.Add(JsonUtility.FromJson<EnemyData>(s));
            }
        }

        Debug.Log("Data loaded");

        foreach (var e in enemies)
        {
            var prefab = Resources.Load<GameObject>(e.PrefabName);
            var tempObj = Object.Instantiate(prefab, e.Pos, e.Rot);
            tempObj.transform.localScale = e.Scale;
            tempObj.name = e.PrefabName;
            tempObj.transform.parent = transform;
        }
    }
}
