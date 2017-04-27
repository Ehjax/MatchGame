using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Wall : MonoBehaviour {
	public GameObject WallPrefab;
	public Button Purchase;

	void Start () {
		gameObject.GetComponent<ParticleSystem> ();
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		Debug.Log ("You bought a City Wall!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Wall")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_WallsCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_WallsCount") + 1);
			Instantiate(WallPrefab, new Vector3(229, 1, 204), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Wall");
		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			Debug.Log ("You don't have enough for that");
		}

		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
