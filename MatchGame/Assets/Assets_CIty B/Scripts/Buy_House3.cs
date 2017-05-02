using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_House3 : MonoBehaviour {
	public GameObject House3Prefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a third house!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("House")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_HouseCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_HouseCount") + 1);
			Instantiate(House3Prefab, new Vector3(212, 5, 218), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("House");
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			alertText.SetActive (true);

			Debug.Log ("You don't have enough for that");
		}
	
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
