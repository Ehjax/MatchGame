using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowBuyables : MonoBehaviour {
	//Create the Button Variables
	public Button Buy_Items;
	public Button Buy_House;
	public Button Buy_Market;
	public Button Buy_Windmill;
	public Button Buy_mainGate;
	public Button Buy_Weaponsmith;
	public Button Buy_Barracks;
	public Button Buy_Dairy;
	public Button Buy_Wall;
	public Button Buy_Sawmill;
	public Button Buy_Slaughterhouse;
	public Button Buy_Quarry;
	public Button Buy_Mine;
	public Button Buy_Bakery;
	public Button Buy_Farm;






	// at runtime hide all 'buy' buttons and add event listener to Buy_Items button
	void Start () {
		Buy_House.gameObject.SetActive(false);
		Buy_Market.gameObject.SetActive(false);
		Buy_Windmill.gameObject.SetActive(false);
		Buy_mainGate.gameObject.SetActive(false);
		Buy_Weaponsmith.gameObject.SetActive(false);
		Buy_Barracks.gameObject.SetActive(false);
		Buy_Dairy.gameObject.SetActive(false);
		Buy_Wall.gameObject.SetActive(false);
		Buy_Sawmill.gameObject.SetActive(false);
		Buy_Slaughterhouse.gameObject.SetActive(false);
		Buy_Quarry.gameObject.SetActive(false);
		Buy_Mine.gameObject.SetActive(false);
		Buy_Mine.gameObject.SetActive(false);
		Buy_Farm.gameObject.SetActive(false);
		Buy_Bakery.gameObject.SetActive(false);











		// get the Buy_Items button
		Button btn = Buy_Items.GetComponent<Button>();
		// add event listener to it
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You Want To Buy Stuff!");
		Buy_House.gameObject.SetActive(true);
		Buy_Market.gameObject.SetActive(true);
		Buy_Windmill.gameObject.SetActive(true);
		Buy_mainGate.gameObject.SetActive(true);
		Buy_Weaponsmith.gameObject.SetActive(true);
		Buy_Barracks.gameObject.SetActive(true);
		Buy_Dairy.gameObject.SetActive(true);
		Buy_Wall.gameObject.SetActive(true);
		Buy_Sawmill.gameObject.SetActive(true);
		Buy_Slaughterhouse.gameObject.SetActive(true);
		Buy_Quarry.gameObject.SetActive(true);
		Buy_Mine.gameObject.SetActive(true);
		Buy_Farm.gameObject.SetActive(true);
		Buy_Bakery.gameObject.SetActive(true);




		Buy_Items.gameObject.SetActive(false);
	}
}
