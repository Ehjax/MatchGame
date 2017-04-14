using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Barracks : MonoBehaviour {

	public GameObject BarracksPrefab;
	public Button Purchase;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Barracks!");
		Instantiate(BarracksPrefab, new Vector3(210, 4, 245), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
