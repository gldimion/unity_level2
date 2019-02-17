using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Lesson5_1 : MonoBehaviour
{
    [System.NonSerialized]
    //[HideInInspector]
    public int x = 0;

    //[Space(50)]
    [Range(-10, 10)]
    public int z = 5;

    [Header("Заголовок")]

    [SerializeField]
    private int y = 10;

    [Tooltip("Подсказка")]
    public string y1;
    [Multiline(5)]
    public string y2;
    [TextArea(3, 6)]
    public string y3;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        Debug.Log("Update");
    }
}
