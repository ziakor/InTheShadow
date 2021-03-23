using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

		void Awake()
    {
      transition.SetTrigger("Show");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
			Debug.Log("Succes");
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

	public void hideWindModal()
	{
		winModal.SetActive(false);
		modal.SetActive(false);
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
