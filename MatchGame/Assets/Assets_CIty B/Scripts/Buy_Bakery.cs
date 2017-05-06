using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Bakery : MonoBehaviour {
	public GameObject bakeryPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_BakeryCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(bakeryPrefab, new Vector3(274, 2, 230), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		//alertText.SetActive (false);
		BuildingPurchasing.SINGLETON.alertTextActive = false;

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_BakeryCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(bakeryPrefab, new Vector3(274, 2, 230), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a Bakery!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Bakery")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_BakeryCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_BakeryCount") + 1);
			Instantiate(bakeryPrefab, new Vector3(274, 2, 230), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Bakery");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (274, 2, 200);

			GetComponent<Image> ().color = Color.black;

		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second
			//alertText.SetActive (true);
			BuildingPurchasing.SINGLETON.alertTextActive = true;
			GetComponent<Image> ().color = Color.red;
			Debug.Log ("You don't have enough for that");
		}

		//Purchase.gameObject.SetActive(false);
	}

	IEnumerator GoAway(GameObject alertText, float delay)
	{
		alertText.SetActive (true);
		yield return new WaitForSeconds(delay);
		alertText.SetActive(false);
	}
}
