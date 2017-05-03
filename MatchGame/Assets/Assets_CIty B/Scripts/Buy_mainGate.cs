using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_mainGate: MonoBehaviour {
	public GameObject mainGatePrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Main Gate!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("mainGate")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_MainGateCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_MainGateCount") + 1);
			Instantiate(mainGatePrefab, new Vector3(174, 10, 269), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("mainGate");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (174, 10, 249);

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