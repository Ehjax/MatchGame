using System.Collections;
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
			Instantiate (windmillPrefab, new Vector3 (223, 1, 206), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Windmill");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (223, 2, 186);
			GetComponent<Image> ().color = Color.black;


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second

			Debug.Log ("You don't have enough for that");
		}
	}


	IEnumerator GoAway(GameObject alertText, float delay)
	{
		alertText.SetActive (true);
		yield return new WaitForSeconds(delay);
		alertText.SetActive(false);
	}
}