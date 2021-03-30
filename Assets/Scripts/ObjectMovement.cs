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
	public  float SPEED_ROTATION = 1.0f;
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
	private Vector3[] moveBoundaries= {new Vector3(-1.9f, 76.4f, 3.6f),new Vector3(0.7f, 78f, 3.8f)};
	public GameObject	GameActive;

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
			if (objectToRotate != null)
			{
				if (!moveObject)
					RotateObject();
				else
					MoveObject();
			}
			if (GameActive && GameActive.activeSelf)
			{
				is_Drag = false;
				moveObject = false;
			}
		}

	private void HandleVerticalRotatePerformed(InputAction.CallbackContext context)
	{
		GetObjectUnderMouse();
		if (objectToRotate)
		{
			this.verticalRotate = true;
			this.horizontalRotate = false;
		}
	}
	private void HandleVerticalRotateCanceled(InputAction.CallbackContext context)
	{

		this.verticalRotate = true;
		this.horizontalRotate = true;
	}
	 private void HandleHorizontalRotatePerformed(InputAction.CallbackContext context)
	{
		GetObjectUnderMouse();
		if (objectToRotate != null)
		{
			this.horizontalRotate = true;
			this.verticalRotate = false;
		}
	}
	private void HandleHorizontalRotateCanceled(InputAction.CallbackContext context)
	{

		this.horizontalRotate = true;
		this.verticalRotate = true;
	}
	private void HandleMoveObjectPerformed(InputAction.CallbackContext context)
	{
		if (!is_Drag)
			this.moveObject = true;
	}
	private void HandleMoveObjectCanceled(InputAction.CallbackContext context)
	{
		this.moveObject = false;
	}
	private void HandleLeftClickCanceled(InputAction.CallbackContext context)
	{
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

		GetObjectUnderMouse();
		if (objectToRotate != null)
		{
			this.is_Drag = true;
			if (moveObject)
			{
				mouseZCoord = gameCamera.WorldToScreenPoint(objectToRotate.transform.position).z;
				mouseMoveOffset = objectToRotate.transform.position - GetMouseWOrldPos();
			}
		}
	}

	private void GetObjectUnderMouse()
	{
		RaycastHit hit; 
		Vector3 coor = Mouse.current.position.ReadValue();
		if (Physics.Raycast(gameCamera.ScreenPointToRay(coor), out hit)) 
		{
			if (hit.collider.gameObject.tag == "Triggerable" && (!GameActive  || !GameActive.activeSelf))
			{
				objectToRotate = hit.collider.gameObject;
				originalRotationValue = objectToRotate.transform.rotation;
			}
		}
	}

	private void MoveObject()
	{
		if (objectToRotate != null && objectMoveable)
		{
			Vector3 newPos = GetMouseWOrldPos() + mouseMoveOffset;
			if (newPos.x < moveBoundaries[0].x || newPos.x > moveBoundaries[1].x)
				newPos.x = objectToRotate.transform.position.x;
			
			if (newPos.y < moveBoundaries[0].y || newPos.y > moveBoundaries[1].y)
				newPos.y = objectToRotate.transform.position.y;
			
			if (newPos.z < moveBoundaries[0].z || newPos.z > moveBoundaries[1].z)
				newPos.z = objectToRotate.transform.position.z;
			objectToRotate.transform.position = newPos;
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
			if (Player.invertY)
				currentRotate.y *= -1;
			
			// Vector3 rotateValue = new Vector3(currentRotate.y, -currentRotate.x, 0);
			if (horizontalRotate)
			{
				if (currentRotate.x > 0 && (this.rotationCount.x < LEVEL_SELECTION_MAX_ROTATION || !limitRotation))
				{
					this.rotationCount.x += (SPEED_ROTATION * Player.sensibilityMouse);
					objectToRotate.transform.Rotate(0,(-SPEED_ROTATION * Player.sensibilityMouse), 0, Space.World);
				}
				if (currentRotate.x < 0 && (this.rotationCount.x > LEVEL_SELECTION_MIN_ROTATION || !limitRotation))
				{
					this.rotationCount.x -= (SPEED_ROTATION * Player.sensibilityMouse);
					objectToRotate.transform.Rotate(0,(SPEED_ROTATION * Player.sensibilityMouse), 0, Space.World);
				}
			}

			if (verticalRotate)
			{
				if (currentRotate.y > 0 && (this.rotationCount.y < LEVEL_SELECTION_MAX_ROTATION || !limitRotation))
				{
					this.rotationCount.y += (SPEED_ROTATION * Player.sensibilityMouse) / 1.6f;
					objectToRotate.transform.Rotate((SPEED_ROTATION * Player.sensibilityMouse) / 1.6f, 0, 0, Space.Self);
				}
				if (currentRotate.y < 0 && (this.rotationCount.y > LEVEL_SELECTION_MIN_ROTATION || !limitRotation))
				{
					this.rotationCount.y -= (SPEED_ROTATION * Player.sensibilityMouse) / 1.6f;
					objectToRotate.transform.Rotate((-SPEED_ROTATION * Player.sensibilityMouse) / 1.6f, 0, 0, Space.Self);
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

