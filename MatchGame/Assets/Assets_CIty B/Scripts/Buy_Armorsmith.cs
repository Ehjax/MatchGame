using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Armorsmith : MonoBehaviour {
	public GameObject armorsmithPrefab;
	public Button Purchase;
	public GameObject alertText;

	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought an Armorsmith!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Armorsmith")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_ArmorsmithCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_ArmorsmithCount") + 1);
			Instantiate(armorsmithPrefab, new Vector3(143, 9, 330), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Armorsmith");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();

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
