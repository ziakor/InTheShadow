using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public  static int level = 1;
	public  static bool testmode = false;

	public static bool HasSavegame = false;
	public static int currentLevel = 1;
	void Awake()
	{
		LoadPlayer();
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		// Debug.Log(Player.testmode);
	}

	public static void ChangeCurrentLevel(int newCurrentLevel)
	{
		currentLevel = newCurrentLevel;
	}
	public static void ChangeLevel(int newLevel)
	{
		level = newLevel;
	}
	public static void TestModePlayer(bool test)
	{
		testmode = test;
	}

	public static void SavePlayer()
	{
		SaveSystem.SavePlayer();
	}
	public static void LoadPlayer()
	{
		PlayerData data = SaveSystem.LoadPlayer();
		if (data != null)
		{
			level = data.level;
			testmode = data.testMode;
			HasSavegame = true;
		}
	}
}
