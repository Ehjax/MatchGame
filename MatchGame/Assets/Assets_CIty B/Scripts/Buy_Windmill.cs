using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_Windmill : MonoBehaviour {
	public GameObject windmillPrefab;
	public Button Purchase;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a windmill!");

		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("windmillPrefab")) 
		{
			Instantiate (windmillPrefab, new Vector3 (223, 2, 206), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("windmillPrefab");
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			Debug.Log ("You don't have enough for that");
		}
	}
}