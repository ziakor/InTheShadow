using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
	private Vector2 screenBounds;
	private float heightMesh;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
				viewPos.x = Mathf.Clamp(viewPos.x, -2f, 1.8f);
				viewPos.y = Mathf.Clamp(viewPos.y, 0.5f, 3f);
				viewPos.z = Mathf.Clamp(viewPos.z, 3.5f, 3.9f);
				transform.position = viewPos;
    }
}
