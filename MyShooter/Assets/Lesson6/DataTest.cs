using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    public enum ProviderTypes
    {
        TXT,
        XML,
        JSON,
        PLAYER_PREFS
    }

    [ContextMenuItem("RunTest", nameof(RunTest))]
    public ProviderTypes ProviderType;

    private DataManager dataManager;

    private void RunTest()
    {
        var path = Application.dataPath;
        var playerData = new PlayerData
        {
            Name = "Player888",
            HP = 77.7f,
            IsVisible = true
        };

        dataManager = new DataManager();
        switch (ProviderType)
        {
            case ProviderTypes.TXT:
                dataManager.SetData<StreamData>();
                break;
            case ProviderTypes.XML:
                dataManager.SetData<XMLData>();
                break;
            case ProviderTypes.JSON:
                dataManager.SetData<JsonData>();
                break;
            case ProviderTypes.PLAYER_PREFS:
                dataManager.SetData<PlayerPrefsData>();
                break;
        }

        dataManager.SetOptions(path);
        Debug.Log(playerData);
        dataManager.Save(playerData);

        var dataLoadded = dataManager.Load();
        Debug.Log(dataLoadded);
    }
}
