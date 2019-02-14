using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Lesson5HW
{
    private static readonly Dictionary<string, int> _nameDictionary = new Dictionary<string, int>();

    [MenuItem("Geekbrains/Lesson5HW/Сделать имена объектов уникальными")]
    private static void UniqueNames()
    {
        var sceneObj = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];  // Находим все объекты на сцене
        if (sceneObj != null)
        {
            foreach (var obj in sceneObj)
            {
                DataCollection(obj);
            }
        }
        foreach (var i in _nameDictionary)
        {
            for (var j = 0; j <= i.Value; j++)
            {
                var gameObj = GameObject.Find(i.Key);
                if (gameObj)
                {
                    gameObj.name += " (" + (j + 1) + ")";
                }
            }
        }
        _nameDictionary.Clear();  // Очищаем память
    }

    /// <summary>
    /// Собирает информацию об объекте (имя и индекс)
    /// </summary>
    /// <param name="sceneObj">Объект на сцене</param>
    private static void DataCollection(GameObject sceneObj)
    {
        string[] tempName = sceneObj.name.Split('(');
        tempName[0] = tempName[0].Trim();  // Убираем пробелы
        if (!_nameDictionary.ContainsKey(tempName[0]))
        {
            _nameDictionary.Add(tempName[0], 0);
        }
        else
        {
            _nameDictionary[tempName[0]]++;
        }
        sceneObj.name = tempName[0];
    }

    [MenuItem("Geekbrains/Lesson5HW/Удалить все объекты сцены")]
    private static void ClearAll()
    {
        var sceneObj = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];  // Находим все объекты на сцене
        if (sceneObj != null)
        {
            foreach (var obj in sceneObj)
            {
                MonoBehaviour.DestroyImmediate(obj);
            }
        }
    }
}
