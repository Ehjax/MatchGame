using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Slaughterhouse : MonoBehaviour {
	public GameObject slaughterPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

	public void TaskOnClick(){
		Debug.Log ("You bought a Slaughterhouse!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Slaughterhouse")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_SlaughterhouseCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_SlaughterhouseCount") + 1);
			Instantiate(slaughterPrefab, new Vector3(272, 5, 264), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Slaughterhouse");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (265, 11, 252);
			GetComponent<Image> ().color = Color.black;



		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second
			Debug.Log ("You don't have enough for that");
		}

		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}


	IEnumerator GoAway(GameObject alertText, float delay)
	{
		alertText.SetActive (true);
		yield return new WaitForSeconds(delay);
		alertText.SetActive(false);
	}
}
