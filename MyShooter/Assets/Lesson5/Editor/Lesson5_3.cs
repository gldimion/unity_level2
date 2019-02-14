using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Lesson5_3 : MonoBehaviour
{
    [MenuItem("Geekbrains/New Item")]
    private static void NewMenuItem()
    {
        Debug.Log("Click on NewMenuItem");
    }

    [MenuItem("Assets/Geekbrains/New Item 2")]
    private static void NewMenuItem2()
    {
        Debug.Log("Click on NewMenuItem2");
    }

    [MenuItem("CONTEXT/Rigidbody/New Item 3")]
    private static void NewMenuItem3()
    {
        Debug.Log("Click on NewMenuItem3");
    }
}
