using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CamArrowKeys : MonoBehaviour {

	private float zoomSpeed = 5.0f;
	private float speed = 5.0f;
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		transform.Translate (0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);
	}
}


