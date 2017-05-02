﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_Windmill : MonoBehaviour {
	public GameObject windmillPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a windmill!");

		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Windmill")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_WindmillCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_WindmillCount") + 1);
			Instantiate (windmillPrefab, new Vector3 (223, 2, 206), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Windmill");
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			alertText.SetActive (false);

			Debug.Log ("You don't have enough for that");
		}
	}
}