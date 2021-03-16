using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectMovement : MonoBehaviour
{
	
	[SerializeField]
    private Camera gameCamera; 
    private InputAction click;


	private const float LEVEL_SELECTION_MAX_ROTATION = 25f;
	private const float LEVEL_SELECTION_MIN_ROTATION = -25f;
	private const float SPEED_ROTATION = 1.7f;
	public GameObject objectToRotate;

	public Vector2 rotationCountShow;
	public PlayerControls controls;
	public Vector2 rotationCount;

	public bool is_Drag;

  private bool restore_rotation = false;
	public Quaternion originalRotationValue;

	private void Awake()
	{
		is_Drag = false;
		controls = new PlayerControls();
		controls.Player.Rotate.performed += context => HandleRotateObjectEventPerformed(context);
		controls.Player.Rotate.canceled += context => HandleRotateObjectEventCanceled(context);
	}
    // Start is called before the first frame update
    void Start()
    {
        rotationCount = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
      RotateObject();

      if (restore_rotation)
      {
        	objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.rotation, originalRotationValue, 0.1f);
          if (objectToRotate.transform.rotation == originalRotationValue)
            restore_rotation = false;
      }
    }

	private void HandleRotateObjectEventCanceled(InputAction.CallbackContext context)
	{
		this.is_Drag = false;
		// objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, originalRotationValue,Time.time * 0.1f);
		// objectToRotate.transform.rotation = Quaternion.Lerp(objectToRotate.transform.rotation, originalRotationValue,Time.time * 0.1f);
    restore_rotation = true;
		this.rotationCount = Vector2.zero;
	}
	private void HandleRotateObjectEventPerformed(InputAction.CallbackContext context)
	{

		RaycastHit hit; 
    Vector3 coor = Mouse.current.position.ReadValue();
    if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit)) 
    {
      // print(hit.collider.gameObject.name);
      objectToRotate = hit.collider.gameObject;
      this.is_Drag = true;
      originalRotationValue = objectToRotate.transform.rotation;
    }
		//ebug.Log("Player want rotate the object " );
		// Debug.Log(Mouse.current.position.ReadValue());
	}

	private void RotateObject()
	{
		if (this.is_Drag)
		{
			// Debug.Log(rotationCount);
			Vector2 currentRotate = Mouse.current.delta.ReadValue();
			Vector3 rotateValue = new Vector3(currentRotate.y, -currentRotate.x, 0);
			if (currentRotate.x > 0 && this.rotationCount.x < LEVEL_SELECTION_MAX_ROTATION)
			{
				this.rotationCount.x += SPEED_ROTATION;
				objectToRotate.transform.Rotate(0,-SPEED_ROTATION, 0, Space.World);
			}
			if (currentRotate.x < 0 && this.rotationCount.x > LEVEL_SELECTION_MIN_ROTATION)
			{
				this.rotationCount.x -= SPEED_ROTATION;
				objectToRotate.transform.Rotate(0,SPEED_ROTATION, 0, Space.World);
			}
			if (currentRotate.y > 0 && this.rotationCount.y < LEVEL_SELECTION_MAX_ROTATION)
			{
				this.rotationCount.y += SPEED_ROTATION;
				objectToRotate.transform.Rotate(SPEED_ROTATION, 0, 0, Space.Self);
			}
			if (currentRotate.y < 0 && this.rotationCount.y > LEVEL_SELECTION_MIN_ROTATION)
			{
				this.rotationCount.y -= SPEED_ROTATION;
				objectToRotate.transform.Rotate(-SPEED_ROTATION, 0, 0, Space.Self);
			}
		}
		rotationCountShow = rotationCount;
	}
	void OnEnable()
	{
		controls.Enable();
	}

	void OnDisable()
	{
		controls.Disable();
	}

	void PrintName(GameObject go)
	{
		print(go.name);
	}
}

