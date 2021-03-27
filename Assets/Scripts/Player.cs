using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public  static int level = 1;
	public  static bool testmode = false;

	public static bool HasSavegame = false;
	public static int currentLevel = 1;
	public static bool	invertY = false;
	public static float sensibilityMouse = 4;

	public static float brightness = 1f;
	public static float contrast = 1f;
	public static float saturation = 1f;

	void Awake()
	{
		LoadPlayer();
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		// Debug.Log(Player.testmode);
	}

	public static void ChangeColorAdjustEffect(float new_Brightness, float new_Contrast, float new_Saturation)
	{
		brightness = new_Brightness;
		contrast = new_Contrast;
		saturation = new_Saturation;
	}

	public static void ChangeInvertY(bool state)
	{
		invertY = state;
	}
	public static void ChangeControllerSensibility(float new_Sensibility)
	{
		sensibilityMouse = new_Sensibility;
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
