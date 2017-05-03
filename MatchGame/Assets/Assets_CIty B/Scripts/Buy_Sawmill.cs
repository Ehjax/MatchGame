﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Sawmill : MonoBehaviour {
	public GameObject sawmillPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Sawmill!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Sawmill")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_LumberCampCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_LumberCampCount") + 1);
			Instantiate(sawmillPrefab, new Vector3(210, 0, 334), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Sawmill");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (210, 0, 314);

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
