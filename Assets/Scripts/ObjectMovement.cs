using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMovement : MonoBehaviour
{
	
	[SerializeField]
	private Camera gameCamera; 
	private InputAction click;

	public  bool limitRotation = false;
	public bool  resetPosition = false;
	public const float LEVEL_SELECTION_MAX_ROTATION = 25f;
	public const float LEVEL_SELECTION_MIN_ROTATION = -25f;
	public const float SPEED_ROTATION = 1.7f;
	public GameObject objectToRotate = null;

	public Vector2 rotationCountShow;
	public PlayerControls controls;
	public Vector2 rotationCount;

	public bool is_Drag;

	private bool restore_rotation = false;
	public Quaternion originalRotationValue;
	public bool objectMoveable = false;
	private bool horizontalRotate = true;
	private bool verticalRotate = true;

	private bool moveObject = false;
	private float mouseZCoord;
	private Vector3 mouseMoveOffset;

	private void Awake()
	{
		is_Drag = false;
		controls = new PlayerControls();
		controls.Player.Rotate.performed += context => HandleLeftClickPerformed(context);
		controls.Player.Rotate.canceled += context => HandleLeftClickCanceled(context);
		controls.Player.LockVerticalRotate.performed += context => HandleHorizontalRotatePerformed(context);
		controls.Player.LockVerticalRotate.canceled += context => HandleHorizontalRotateCanceled(context);
		controls.Player.LockHorizontalRotate.performed += context => HandleVerticalRotatePerformed(context);
		controls.Player.LockHorizontalRotate.canceled += context => HandleVerticalRotateCanceled(context);

		controls.Player.MoveObject.performed += context => HandleMoveObjectPerformed(context);
		controls.Player.MoveObject.canceled += context => HandleMoveObjectCanceled(context);

		

	}
		// Start is called before the first frame update
		void Start()
		{
				rotationCount = Vector2.zero;
		}

		// Update is called once per frame
		void Update()
		{
			// Debug.Log(moveObject);
			if (objectToRotate != null)
			{
				if (!moveObject)
					RotateObject();
				else
					MoveObject();

			}
		}

	private void HandleVerticalRotatePerformed(InputAction.CallbackContext context)
	{
		Debug.Log("VerticalRotatePerform");
		GetObjectUnderMouse();
		if (objectToRotate)
		{
			this.verticalRotate = true;
			this.horizontalRotate = false;
		}
	}
	private void HandleVerticalRotateCanceled(InputAction.CallbackContext context)
	{
		Debug.Log("VerticalRotateCancel");

		this.verticalRotate = true;
		this.horizontalRotate = true;
	}
	 private void HandleHorizontalRotatePerformed(InputAction.CallbackContext context)
	{
		Debug.Log("HorizontalRotatePerform");
		GetObjectUnderMouse();
		if (objectToRotate != null)
		{
			this.horizontalRotate = true;
			this.verticalRotate = false;
		}
	}
	private void HandleHorizontalRotateCanceled(InputAction.CallbackContext context)
	{
		Debug.Log("HorizontalRotateCancel");

		this.horizontalRotate = true;
		this.verticalRotate = true;
	}
	private void HandleMoveObjectPerformed(InputAction.CallbackContext context)
	{
		Debug.Log("MoveObjectPerform");
		this.moveObject = true;
	}
	private void HandleMoveObjectCanceled(InputAction.CallbackContext context)
	{
		Debug.Log("MoveObjectCancel");
		this.moveObject = false;
	}
	private void HandleLeftClickCanceled(InputAction.CallbackContext context)
	{
		Debug.Log("RotateAllCancel");
		this.is_Drag = false;
		//Ajouter condition si il y a le shift ou le ctrl dactif, ne pas reset
		this.verticalRotate = true;
		this.horizontalRotate = true;
		if (resetPosition)
			restore_rotation = true;
		else
			objectToRotate = null;
		this.rotationCount = Vector2.zero;
	}
	
	private void HandleLeftClickPerformed(InputAction.CallbackContext context)
	{
		Debug.Log("RotateAllPerform");

		GetObjectUnderMouse();
		if (objectToRotate != null)
		{
			this.is_Drag = true;
			if (moveObject)
			{
				Debug.Log("NAME: " + objectToRotate.name);
				mouseZCoord = gameCamera.WorldToScreenPoint(objectToRotate.transform.position).z;
				mouseMoveOffset = objectToRotate.transform.position - GetMouseWOrldPos();
				Debug.Log(mouseMoveOffset);
			}
		}
	}

	private void GetObjectUnderMouse()
	{
		RaycastHit hit; 
		Vector3 coor = Mouse.current.position.ReadValue();
		if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit)) 
		{
			if (hit.collider.gameObject.tag == "Triggerable")
			{
				objectToRotate = hit.collider.gameObject;
				Debug.Log(objectToRotate.name);
				originalRotationValue = objectToRotate.transform.rotation;
			}
		}
	}

	private void MoveObject()
	{
		// Debug.Log("Move Object Func");
		if (objectToRotate != null && objectMoveable)
		{
			objectToRotate.transform.position = GetMouseWOrldPos() + mouseMoveOffset;
		}

	}
	private Vector3 GetMouseWOrldPos()
	{
		Vector3 mousepoint = Mouse.current.position.ReadValue();
		mousepoint.z = mouseZCoord;

		return gameCamera.ScreenToWorldPoint(mousepoint);
	}
	private void RotateObject()
	{
		if (this.is_Drag)
		{
			Vector2 currentRotate = Mouse.current.delta.ReadValue();
			Vector3 rotateValue = new Vector3(currentRotate.y, -currentRotate.x, 0);
			if (horizontalRotate)
			{
				if (currentRotate.x > 0 && (this.rotationCount.x < LEVEL_SELECTION_MAX_ROTATION || !limitRotation))
				{
					this.rotationCount.x += SPEED_ROTATION;
					objectToRotate.transform.Rotate(0,-SPEED_ROTATION, 0, Space.World);
				}
				if (currentRotate.x < 0 && (this.rotationCount.x > LEVEL_SELECTION_MIN_ROTATION || !limitRotation))
				{
					this.rotationCount.x -= SPEED_ROTATION;
					objectToRotate.transform.Rotate(0,SPEED_ROTATION, 0, Space.World);
				}
			}

			if (verticalRotate)
			{
				if (currentRotate.y > 0 && (this.rotationCount.y < LEVEL_SELECTION_MAX_ROTATION || !limitRotation))
				{
					this.rotationCount.y += SPEED_ROTATION;
					objectToRotate.transform.Rotate(SPEED_ROTATION, 0, 0, Space.Self);
				}
				if (currentRotate.y < 0 && (this.rotationCount.y > LEVEL_SELECTION_MIN_ROTATION || !limitRotation))
				{
					this.rotationCount.y -= SPEED_ROTATION;
					objectToRotate.transform.Rotate(-SPEED_ROTATION, 0, 0, Space.Self);
				}
			}
		}
		else
		{
			if (restore_rotation && objectToRotate)
			{
				objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.rotation, originalRotationValue, 0.1f);
				if (objectToRotate.transform.rotation == originalRotationValue)
					restore_rotation = false;
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
}

