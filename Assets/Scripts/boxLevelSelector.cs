using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoxLevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Color default_Color;
    public Color hover_Color;
    public GameObject box = null;

		public GameObject box_connection = null;
    public Animator transition;
    public float transition_Time = 1f;

    private bool is_Clickable = true;

		public int levelNumber;

		public GameObject boxLevelNotCompleted;

		public GameObject boxLevelCompleted;

		void Awake()
		{
			if (levelNumber <= Player.level || Player.testmode == true)
			{
				HandleChangeChild(true);
				if (box_connection)
					box_connection.SetActive(true);
				if (Player.bestTime[levelNumber - 1] > 0)
				{
					boxLevelNotCompleted.SetActive(false);
					boxLevelCompleted.SetActive(true);
				}
			}
			else
			{
				HandleChangeChild(false);
				if (box_connection)
					box_connection.SetActive(false);
			}
		}

    void Update()
    {
				if (levelNumber <= Player.level || Player.testmode == true)
				{
					HandleChangeChild(true);
					if (box_connection)
						box_connection.SetActive(true);
					if (Player.bestTime[levelNumber - 1] > 0)
					{
						boxLevelNotCompleted.SetActive(false);
						boxLevelCompleted.SetActive(true);
					}
					else
					{
						boxLevelNotCompleted.SetActive(true);
						boxLevelCompleted.SetActive(false);
					}
				}
				else
				{
					HandleChangeChild(false);
					if (box_connection)
						box_connection.SetActive(false);
						
				}
    }

		public void HandleChangeChild(bool state)
		{
			
			for (int i = 0; i < this.transform.childCount; i++)
			{
					this.transform.GetChild(i).gameObject.SetActive(state);
			}

		}
    public void BoxEnter()
    {
      box.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = hover_Color;
    }
    public void BoxLeave()
    {
      box.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = default_Color;
    }

    public void LevelSelected(int idScene)
    {
      if (is_Clickable)
			{
				Player.ChangeCurrentLevel(idScene);
        StartCoroutine(LoadLevel(idScene));
			}
    }

    IEnumerator LoadLevel(int idScene)
    {
      transition.SetTrigger("Fade");
      yield return new WaitForSeconds(transition_Time);

      SceneManager.LoadScene(idScene, LoadSceneMode.Single); 
    }

    public void Start_Drag()
    {
      is_Clickable = false;
    }
    public void End_Drag()
    {
      is_Clickable = true;
    }
    
}
