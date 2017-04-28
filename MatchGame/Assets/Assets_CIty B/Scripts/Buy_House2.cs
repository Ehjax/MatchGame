using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_House2 : MonoBehaviour {
	public GameObject House2Prefab;
	public Button Purchase;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a second house!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("House")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_HouseCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_HouseCount") + 1);
			Instantiate(House2Prefab, new Vector3(227, 1, 184), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("House");
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			Debug.Log ("You don't have enough for that");
		}
	
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
