using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public int level;
	public bool testMode;
	public float[] bestTime;


	public PlayerData ()
	{
		level = Player.level;
		testMode = Player.testmode;
		bestTime = Player.bestTime;
	}
}
