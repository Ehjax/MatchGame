using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Dairy : MonoBehaviour {
	public GameObject DairyPrefab;
	public Button Purchase;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Barracks!");
		Instantiate(DairyPrefab, new Vector3(140, 5, 284), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
