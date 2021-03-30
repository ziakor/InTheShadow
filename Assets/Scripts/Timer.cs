using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
		private float bestTime = -1f;
		public int level = 1;

		public Text bestTimeText;
		
		void Awake()
		{
			bestTime = Player.bestTime[level - 1];
			DisplayBestTime();
		
		}
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
			bestTime = Player.bestTime[level - 1];
			DisplayBestTime();

    }

		private void DisplayBestTime()
		{
			if (bestTime > 0)
			{
				float minutes = Mathf.FloorToInt(bestTime / 60);
				float seconds = Mathf.FloorToInt(bestTime % 60);
				bestTimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
			}
			else{
				bestTimeText.text = "-- : --";
			}

		}
}
