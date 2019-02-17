using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Lesson5_4))]
public class Lesson5_4Editor : Editor
{
    bool isButtonPressed;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var les5 = (Lesson5_4)target;

        if(GUILayout.Button("Заспаунить объекты", EditorStyles.miniButton))
        {
            les5.CreateObjs();
            isButtonPressed = true;
        }

        if(isButtonPressed)
        {
            EditorGUILayout.HelpBox("Кнопка нажата, ура!", MessageType.Warning);
        }
    }
}
