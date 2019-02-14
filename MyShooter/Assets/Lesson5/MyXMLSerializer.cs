using System.IO;
using System.Xml.Serialization;

public static class MyXMLSerializer
{
    private static XmlSerializer serializer;

    static MyXMLSerializer()
    {
        serializer = new XmlSerializer(typeof(SerializableGameObject[]));
    }

    public static void Save(SerializableGameObject[] objs, string path)
    {
        if (objs == null || objs.Length == 0 || string.IsNullOrEmpty(path)) return;

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(fs, objs);
        }
    }

    public static SerializableGameObject[] Load(string path)
    {
        if (!File.Exists(path)) return null;

        SerializableGameObject[] res;
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            res = (SerializableGameObject[])serializer.Deserialize(fs);
        }

        return res;
    }
}
