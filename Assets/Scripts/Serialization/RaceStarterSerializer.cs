using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class RaceStarterSerializer : MonoBehaviour
{
    public static void SaveRaceStarterData(string data, string name)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".dat");

        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public static string GetRaceStarterData(string name)
    {
        if (File.Exists(Application.persistentDataPath + "/" + name + ".dat")) {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + name + ".dat", FileMode.Open);
            string data = (string)binaryFormatter.Deserialize(file);

            file.Close();
            return data;
        }

        throw new FileNotFoundException();
    }
}