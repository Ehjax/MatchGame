using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

		// VARIABLES
		public int max_X;
		public int min_X;
		public int max_Z;
		public int min_Z;
		public int max_Y;
		public int min_Y;


		public static MoveCamera SINGLETON; 
		public bool reachedTarget;
		public Button Purchase;
		public Transform target;
		public float speed;
		public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
		public float panSpeed = 4.0f;		// Speed of the camera when being panned
		public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth

		private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
		private bool isPanning;		// Is the camera being panned?
		private bool isRotating;	// Is the camera being rotated?
		private bool isZooming;		// Is the camera zooming?

	void Start () {
		if (MoveCamera.SINGLETON == null)
			SINGLETON = this;
		//Button btn = Purchase.GetComponent<Button>();
		//btn.onClick.AddListener(TaskOnClick);
	}
		//
		// UPDATE
		//

		void Update () 
		{

		if (target != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			if (Vector3.Distance(transform.position, target.position) <= 20f)
				
			target = null;
			reachedTarget = true;
		}

			// Get the left mouse button
			if(Input.GetMouseButtonDown(0))
			{
				// Get mouse origin
				mouseOrigin = Input.mousePosition;
				isRotating = true;
			}

			// Get the right mouse button
			if(Input.GetMouseButtonDown(1))
			{
				// Get mouse origin
				mouseOrigin = Input.mousePosition;
				isPanning = true;
			}

			// Get the middle mouse button
			if(Input.GetMouseButtonDown(2))
			{
				// Get mouse origin
				mouseOrigin = Input.mousePosition;
				isZooming = true;
			}

			// Disable movements on button release
			if (!Input.GetMouseButton(0)) isRotating=false;
			if (!Input.GetMouseButton(1)) isPanning=false;
			if (!Input.GetMouseButton(2)) isZooming=false;

			// Rotate camera along X and Y axis
			if (isRotating)
			{
				Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

				transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
				transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
			}

			// Move the camera on it's XY plane
			if (isPanning)
			{
			
				Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

				Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
				transform.Translate(move, Space.Self);
		/*
			 * if (Camera.main.transform.position.x > max_X)
				Camera.main.transform.position = new Vector3 (max_X, Camera.main.transform.position.x, Camera.main.transform.position.y);
			if (Camera.main.transform.position.x < min_X)
				Camera.main.transform.position = new Vector3 (min_X, Camera.main.transform.position.x, Camera.main.transform.position.y);
			if (Camera.main.transform.position.y > max_Y)
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x,max_Y , Camera.main.transform.position.y);
			if (Camera.main.transform.position.y < min_Y)
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, min_Y, Camera.main.transform.position.y);
		*/
			}


			// Move the camera linearly along Z axis
			if (isZooming)
			{
				Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

				Vector3 move = pos.y * zoomSpeed * transform.forward; 
				transform.Translate(move, Space.World);
			/*
			if (Camera.main.transform.position.z > max_Z)
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, max_Z);
			if (Camera.main.transform.position.z < min_Z)
				Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, min_Z);
*/
			}


		}

	public void TaskOnClick()
	{
		reachedTarget = false; 
	}

	}
