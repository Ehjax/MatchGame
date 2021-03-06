﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BuildingPurchasing : MonoBehaviour {
	public List<Building> buildings;
//	public int [] Tiers = new int[4]; 
	public static BuildingPurchasing SINGLETON; 
	private int currentTier = 0;
	public int currentBuilt = 0;
	private int[] buildsRequired = {5,5,5,5,1};
	public float alertTextTimeout = 10F;
	private float alertTextTimeRemaining; 
	public bool alertTextActive = false;
	public bool clicked = false;
	[Tooltip("Shows the total wood for the whole game.")]
	public Text woodTotalUI = null;
	[Tooltip("Shows the total gold for the whole game.")]
	public Text goldTotalUI = null;
	[Tooltip("Shows the total stone for the whole game.")]
	public Text stoneTotalUI = null;
	[Tooltip("Shows the total food for the whole game.")]
	public Text foodTotalUI = null;

	private int woodTotal = 0;
	private int goldTotal = 0;
	private int stoneTotal = 0;
	private int foodTotal = 0;


	void Awake() 
	{
		
		alertTextTimeRemaining = alertTextTimeout;
		if (BuildingPurchasing.SINGLETON == null)
			SINGLETON = this;
		else Debug.LogError("Building Purchasing SINGLETON Already exists");
		setUp ();
	}
	private void UpdateUI()
	{

		/*woodTotalUI.text = "Total wood: " + Game.current.PlayerOne.name + "_woodTotal";
		goldTotalUI.text = "Total gold: " + Game.current.PlayerOne.name + "_goldTotal";
		stoneTotalUI.text = "Total stone: " + Game.current.PlayerOne.name + "_stoneTotal";
		foodTotalUI.text = "Total food: "+ Game.current.PlayerOne.name + "_foodTotal";*/

	}
	public bool checkCost (string name) 
		{
		foreach (Building building in buildings) 
		{
			if (building.name != name)
				continue;

			int wood = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_woodTotal");
			int food = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_foodTotal");
			int stone = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_stoneTotal");
			int gold = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_goldTotal");

			if (wood >= building.wood &&
			    stone >= building.stone &&
			    gold >= building.gold &&
			    food >= building.food) 
			{

				return true;
			}
		}

		return false;


	        }
	private void setUp () 
	{
		foreach (Building building in buildings)
		{
			PlayerPrefs.SetInt (building.name, 0);
		}
	}
public bool purchase (string name)
			{
		if (checkCost (name))
		{
            Building building = GetBuilding (name);

			if (building != null) {
                int wood = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_woodTotal");
				int food = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_foodTotal");
				int stone = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_stoneTotal");
				int gold = PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_goldTotal");
				Debug.Log ("Wood, food, stone, gold: " + wood + ", " + food + ", " + stone + ", " + gold);

				PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_woodTotal", wood - building.wood); // differences after purchase 
				PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_foodTotal", food - building.food);
				PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_stoneTotal", stone - building.stone);
				PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_goldTotal", gold - building.gold);

                Debug.Log(building.name + "(" + name + "): " + building.wood + ", " + building.food + ", " + building.stone + ", " + building.gold);
				Debug.Log ("Wood, food, stone, gold: " + (wood - building.wood) + ", " + (food - building.food) + ", " + (stone - building.stone) + ", " + (gold - building.gold));

				PlayerPrefs.SetInt (name, 1); 
				return true; 
			} else
				Debug.LogError ("No " + name + " found!");

		} 	
		return false;	
	}

	public Building GetBuilding(string name)
	{
		foreach (Building building in buildings) 
		{
			if (building.name == name)
				return building;
		}

		return null;
	}
	public void checkTier () 
	{
		foreach (Building building in buildings)
		{
			if (currentBuilt >= buildsRequired [currentTier])
				currentTier++;
				currentBuilt = 0;
			}
	}
	private void Update()
	{
		if (alertTextActive && alertTextTimeRemaining > 0) 
		{
			// reduce the remaining time by time passed since last update frame
			alertTextTimeRemaining -= Time.deltaTime;
			alertTextActive = false;
		}
	}

}

	

[System.Serializable]
public class Building 
			{
	public string name; 
	public int stone;
	public int wood;
	public int gold;
	public int food; 
}


	//* [System.Serializable]						
//public class buttonClick
//{
	//public List<buttonClick> buttons;

	//void Start() 
	//{
	//for (int i = 0; i <buttonClick .Length; i++) 
	//{
	//		int capturedIterator = i;
	//		buttonClick [i].onClick.AddListener(() => 
	//}
//	}
//} 