using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerPrefsData : IDataProvider
{
    private const string PLAYER_DATA_NAME_KEY = "PLAYER_DATA_NAME_KEY";
    private const string PLAYER_DATA_HP_KEY = "PLAYER_DATA_HP_KEY";
    private const string PLAYER_DATA_IS_VIS_KEY = "PLAYER_DATA_IS_VIS_KEY";

    public PlayerData Load()
    {
        var playerData = new PlayerData();

        if (PlayerPrefs.HasKey(PLAYER_DATA_NAME_KEY))
            playerData.Name = PlayerPrefs.GetString(PLAYER_DATA_NAME_KEY);
        playerData.HP = PlayerPrefs.GetFloat(PLAYER_DATA_HP_KEY, 100f);
        playerData.IsVisible = bool.Parse(PlayerPrefs.GetString(PLAYER_DATA_IS_VIS_KEY, false.ToString()));

        Debug.Log("Data loaded");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {
        PlayerPrefs.SetString(PLAYER_DATA_NAME_KEY, playerData.Name);
        PlayerPrefs.SetFloat(PLAYER_DATA_HP_KEY, playerData.HP);
        PlayerPrefs.SetString(PLAYER_DATA_IS_VIS_KEY, playerData.IsVisible.ToString());

        Debug.Log("Data saved");
        PlayerPrefs.Save();
    }

    public void SetOptions(string path)
    {
    }
}
