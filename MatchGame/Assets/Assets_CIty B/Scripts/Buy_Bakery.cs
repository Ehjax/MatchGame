using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Bakery : MonoBehaviour {
	public GameObject bakeryPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		//alertText.SetActive (false);
		BuildingPurchasing.SINGLETON.alertTextActive = false;

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Bakery!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Bakery")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_BakeryCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_BakeryCount") + 1);
			Instantiate(bakeryPrefab, new Vector3(274, 2, 230), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Bakery");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (274, 2, 200);
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			//alertText.SetActive (true);
			BuildingPurchasing.SINGLETON.alertTextActive = true;
			GetComponent<Image> ().color = Color.red;
			Debug.Log ("You don't have enough for that");
		}

		//Purchase.gameObject.SetActive(false);
	}
}
