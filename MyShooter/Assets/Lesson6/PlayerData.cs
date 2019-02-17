using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string Name;
    public float HP;
    public bool IsVisible;

    public override string ToString()
    {
        return $"Name: {Name} HP: {HP} IsVisible: {IsVisible}";
    }
}
