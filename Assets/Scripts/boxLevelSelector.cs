using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoxLevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Color default_Color;
    public Color hover_Color;
    public GameObject box;

    public Animator transition;
    public float transition_Time = 1f;

    private bool is_Clickable = true;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BoxEnter()
    {
      // Debug.Log("ENTER " + box.name);
      
      box.GetComponent<MeshRenderer>().material.color = hover_Color;
    }
    public void BoxLeave()
    {
      // Debug.Log("LEAVE " + box.name);
      box.GetComponent<MeshRenderer>().material.color = default_Color;
    }

    public void LevelSelected(string scene_Name)
    {
      if (is_Clickable)
        StartCoroutine(LoadLevel(scene_Name));
    }

    IEnumerator LoadLevel(string scene_Name)
    {
      transition.SetTrigger("Fade");
      yield return new WaitForSeconds(transition_Time);

      SceneManager.LoadScene(scene_Name, LoadSceneMode.Single); 
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
