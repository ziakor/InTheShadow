using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneAnimation : MonoBehaviour
{
    public Animator transition;
    public float transition_Time = 1f;
    // Start is called before the first frame update

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
        
    }
}
