using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLData : IDataProvider
{
    private string path;

    public PlayerData Load()
    {
        if (!File.Exists(path)) return default(PlayerData);

        var playerData = new PlayerData();

        using (var reader = new XmlTextReader(path))
        {
            while(reader.Read())
            {
                string key = "Name";
                if (reader.IsStartElement(key)) playerData.Name = reader.GetAttribute("value");

                key = "HP";
                if (reader.IsStartElement(key))
                    if (!float.TryParse(reader.GetAttribute("value"), out playerData.HP))
                    {
                        playerData.HP = 100f;
                        Debug.LogWarning($"PlayerData.HP is not float! {path}");
                    }

                key = "IsVisible";
                if (reader.IsStartElement(key))
                    if (!bool.TryParse(reader.GetAttribute("value"), out playerData.IsVisible))
                    {
                        playerData.IsVisible = true;
                        Debug.LogWarning($"PlayerData.HP is not float! {path}");
                    }
            }

        }

        Debug.Log("Data loaded!");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {
        var xmlDoc = new XmlDocument();
        var rootNode = xmlDoc.CreateElement("PlayerData");
        xmlDoc.AppendChild(rootNode);

        var element = xmlDoc.CreateElement("Name");
        element.SetAttribute("value", playerData.Name);
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("HP");
        element.SetAttribute("value", playerData.HP.ToString());
        rootNode.AppendChild(element);

        element = xmlDoc.CreateElement("IsVisible");
        element.SetAttribute("value", playerData.IsVisible.ToString());
        rootNode.AppendChild(element);

        xmlDoc.Save(path);
        Debug.Log("Data saved!");
    }

    public void SetOptions(string path)
    {
        this.path = Path.Combine(path, "data.xml");
    }
}
