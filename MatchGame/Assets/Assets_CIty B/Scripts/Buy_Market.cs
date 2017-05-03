using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_Market: MonoBehaviour {
	public GameObject marketPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Market!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Market")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_MarketCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_MarketCount") + 1);
			Instantiate(marketPrefab, new Vector3(250, 0, 240), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Market");
			Camera.main.transform.position = new Vector3 (174, 10, 220);

			//Display game ending message 
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
