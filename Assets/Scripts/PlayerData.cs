using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int level;
	public bool testMode;

	public int currentLevel;

	public PlayerData ()
	{
		level = Player.level;
		testMode = Player.testmode;
		currentLevel = Player.currentLevel;
	}
}
