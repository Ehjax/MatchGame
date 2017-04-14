using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_mainGate: MonoBehaviour {
	public GameObject mainGatePrefab;
	public Button Purchase;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Main Gate!");
		Instantiate(mainGatePrefab, new Vector3(174, 10, 269), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}