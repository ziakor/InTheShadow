using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Level_Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public float transition_Time = 1f;

		public List<GameObject> objectToFind = new List<GameObject>();
		public List<GameObject> objectToUse = new List<GameObject>();

		public GameObject modal;
		public GameObject menuPause;
		public GameObject winModal;

		public GameObject	pauseButton;
		public Color	hoverPauseButtonColor;
		public Color	defaultPauseButtonColor;
		private bool	isWin = false;


		public AudioSource winSound;
		void Awake()
    {
			isWin = false;
      transition.SetTrigger("Show");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
			if (!isWin)
				CheckWin();
    }


	private void CheckWin()
	{
		int i;
		i = 0;
		for (i = 0; i < objectToFind.Count; i++)
		{
			if (Quaternion.Dot(objectToFind[0].transform.rotation, objectToUse[0].transform.rotation) < 0.999)
				break;
				
		}
		if (i == objectToFind.Count)
		{
			showWinModal();
			isWin = true;
			Debug.Log("Succes");
			winSound.Play();
			if (Player.currentLevel == Player.level)
			{
				Player.ChangeLevel(Player.level + 1);
				Player.SavePlayer();
			}
		}
	}
	private void ClickSound()
  {
    GetComponent<AudioSource>().Play();
  }

	public void ShowMenuPause()
	{
		menuPause.SetActive(true);
		modal.SetActive(true);

	}
	public void HideMenuPause()
	{
		menuPause.SetActive(false);
		modal.SetActive(false);
	}
	public void showWinModal()
	{
		winModal.SetActive(true);
		modal.SetActive(true);
	}

	public void hideWinModal()
	{
		winModal.SetActive(false);
		modal.SetActive(false);
	}

	public void onClickPause()
	{
		if (menuPause.activeSelf)
			HideMenuPause();
		else if (!winModal.activeSelf)
			ShowMenuPause();
	}
	public void onPointerEnterPause()
	{
		pauseButton.GetComponent<Image>().color = hoverPauseButtonColor;
	}
	public void  onPointerLeavePause()
	{
		pauseButton.GetComponent<Image>().color = defaultPauseButtonColor;
	}

	public void QuitLevel(string level_to_unload)
  {
      StartCoroutine(LoadLevel("Menu", level_to_unload));
  }
  IEnumerator LoadLevel(string scene_Name, string current_level)
  {
    transition.SetTrigger("Fade");
    yield return new WaitForSeconds(transition_Time);
    SceneManager.LoadScene(scene_Name, LoadSceneMode.Single);
		SceneManager.UnloadSceneAsync(current_level);
  }


}
