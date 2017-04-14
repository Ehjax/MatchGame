using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Sawmill : MonoBehaviour {
	public GameObject sawmillPrefab;
	public Button Purchase;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Sawmill!");
		Instantiate(sawmillPrefab, new Vector3(210, 0, 334), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
