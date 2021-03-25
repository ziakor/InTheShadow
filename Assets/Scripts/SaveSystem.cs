using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
	public static void SavePlayer()
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath +  "/player.epitech";
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData();

		formatter.Serialize(stream, data);
		stream.Close();
		Debug.Log("SavePLayer");
	}

	public static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath +  "/player.epitech";
		if (File.Exists(path))
		{
				BinaryFormatter formatter = new BinaryFormatter();
				FileStream stream = new FileStream(path, FileMode.Open);

				PlayerData data =  formatter.Deserialize(stream) as PlayerData;
				stream.Close();
				return data;
		}
		else 
		{
			Debug.Log("Save file not found in" + path);
			return null;
		}
	}  
}
