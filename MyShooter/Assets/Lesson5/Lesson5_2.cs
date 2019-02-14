using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5_2 : MonoBehaviour
{
    [ContextMenuItem("Randomize", nameof(Randomize))]
    public int randX = 0;

    void Randomize()
    {
        randX = Random.Range(-100, 100);
    }
}
