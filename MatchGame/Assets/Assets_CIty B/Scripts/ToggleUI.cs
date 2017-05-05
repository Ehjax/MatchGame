using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class ToggleUI : MonoBehaviour {
	public Button Toggle;

	public Button Buy_Items;
	public Button Buy_House;
	public Button Buy_House2;
	public Button Buy_House3;
	public Button Buy_Armorsmith;
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
	public Button Buy_Warehouse;


	void Start () {

		Button btn = Toggle.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	public void TaskOnClick(){
		Debug.Log ("before clicked" + BuildingPurchasing.SINGLETON.clicked);
		Buy_House.gameObject.SetActive (false);
		Buy_House2.gameObject.SetActive (false);
		Buy_House3.gameObject.SetActive (false);
		Buy_Market.gameObject.SetActive (false);
		Buy_Armorsmith.gameObject.SetActive (false);
		Buy_Windmill.gameObject.SetActive (false);
		Buy_mainGate.gameObject.SetActive (false);
		Buy_Weaponsmith.gameObject.SetActive (false);
		Buy_Barracks.gameObject.SetActive (false);
		Buy_Dairy.gameObject.SetActive (false);
		Buy_Wall.gameObject.SetActive (false);
		Buy_Sawmill.gameObject.SetActive (false);
		Buy_Slaughterhouse.gameObject.SetActive (false);
		Buy_Quarry.gameObject.SetActive (false);
		Buy_Mine.gameObject.SetActive (false);
		Buy_Mine.gameObject.SetActive (false);
		Buy_Farm.gameObject.SetActive (false);
		Buy_Bakery.gameObject.SetActive (false);
		Buy_Warehouse.gameObject.SetActive(false);
		Buy_Items.gameObject.SetActive(true);

}

}

