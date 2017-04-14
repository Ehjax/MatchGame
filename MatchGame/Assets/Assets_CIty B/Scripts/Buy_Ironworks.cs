using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Ironworks : MonoBehaviour {
	public GameObject IronworksPrefab;
	public Button Purchase;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought an Ironworks!");
		Instantiate(IronworksPrefab, new Vector3(210, 0, 334), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
