using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Farm : MonoBehaviour {
	public GameObject farmPrefab;
	public Button Purchase;
	public GameObject alertText;

	void Start () {
        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_FarmCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(farmPrefab, new Vector3(240, 5, 230), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_FarmCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(farmPrefab, new Vector3(240, 5, 230), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a Farm!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Farm")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_FarmCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_FarmCount") + 1);
			Instantiate(farmPrefab, new Vector3(240, 5, 230), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Farm");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (240, 5, 210);
			GetComponent<Image> ().color = Color.black;


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second
			alertText.SetActive (true);
			Debug.Log ("You don't have enough for that");
			GetComponent<Image> ().color = Color.red;
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
