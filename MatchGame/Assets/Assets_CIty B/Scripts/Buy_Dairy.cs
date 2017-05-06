using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Dairy : MonoBehaviour {
	public GameObject DairyPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_DairyCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(DairyPrefab, new Vector3(189, 26, 250), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_DairyCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(DairyPrefab, new Vector3(189, 26, 250), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a Dairy Farm!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Dairy")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_DairyCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_DairyCount") + 1);
			Instantiate(DairyPrefab, new Vector3(189, 26, 250), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Dairy");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (189, 35, 250);
			GetComponent<Image> ().color = Color.black;


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second
			GetComponent<Image> ().color = Color.red;
			alertText.SetActive (true);
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
