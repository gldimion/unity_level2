using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Lesson7 : MonoBehaviour
{
    public Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Profiler.BeginSample("GetComponent<Transform>");
        for (int i = 0; i < 10000; i++)
            GetComponent<Transform>().position = Vector3.one;
        Profiler.EndSample();

        Profiler.BeginSample("TransformCached");
        for (int i = 0; i < 10000; i++)
            _transform.position = Vector3.one;
        Profiler.EndSample();

        Profiler.BeginSample("transform");
        for (int i = 0; i < 10000; i++)
            transform.position = Vector3.one;
        Profiler.EndSample();
    }
}
