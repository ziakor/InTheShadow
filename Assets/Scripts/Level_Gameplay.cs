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

		public PlayerControls controls;
		public List<GameObject> objectToFind = new List<GameObject>();
		public List<GameObject> objectToUse = new List<GameObject>();

		public GameObject modal;
		public GameObject menuPause;
		public GameObject winModal;

		public GameObject	pauseButton;
		public Color	hoverPauseButtonColor;
		public Color	defaultPauseButtonColor;
		private bool	isWin = false;

		public int levelMax = 3;

		public float timer = 0;
		public AudioSource winSound;

		public Text timerText;
		void Awake()
    {
			controls = new PlayerControls();

			controls.Player.Escape.performed += context => HandleEscapeButton();
			isWin = false;
      if (Player.currentLevel == levelMax)
				winModal.transform.GetChild(3).gameObject.SetActive(false);
			transition.SetTrigger("Show");

    }

		private void HandleEscapeButton()
		{
			onClickPause();
		}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
			if (!isWin)
			{
				timer += Time.deltaTime;
				FormatTimer(timer);
				CheckWin();
			}
    }

	private void FormatTimer(float timeToDisplay)
	{
		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);

		timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
	}
	private void CheckWin()
	{
		int i;
		i = 0;
		for (i = 0; i < objectToFind.Count; i++)
		{
			float res =Quaternion.Dot(objectToFind[0].transform.rotation, objectToUse[0].transform.rotation);
			if ( res > -0.999 && res < 0.999 )
				break;
				
		}
		if (i == objectToFind.Count)
		{
			showWinModal();
			isWin = true;
			Debug.Log("Succes");
			winSound.Play();
			Debug.Log("Bestime: " + Player.bestTime[Player.currentLevel]);
			Debug.Log("new_time: " + timer);
			if (Player.bestTime[Player.currentLevel] == 0 || Player.bestTime[Player.currentLevel] > timer)
				Player.ChangeBestTime(Player.currentLevel, timer);
			if (Player.currentLevel == Player.level)
				Player.ChangeLevel(Player.level + 1);
			Player.SavePlayer();
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

	public void QuitLevel()
  {
      StartCoroutine(LoadLevel("Menu"));
  }

	public void ChangeLevel(string new_level)
	{
		Player.ChangeCurrentLevel(Player.currentLevel + 1);
		StartCoroutine(LoadLevel(new_level));
	}
  IEnumerator LoadLevel(string scene_Name)
  {
    transition.SetTrigger("Fade");
    yield return new WaitForSeconds(transition_Time);
    SceneManager.LoadScene(scene_Name, LoadSceneMode.Single);
  }
	void OnEnable()
	{
		controls.Enable();
	}

	void OnDisable()
	{
		controls.Disable();
	}

}
