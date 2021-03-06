using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Buy_House2 : MonoBehaviour {
	public GameObject House2Prefab;
	public Button Purchase;
	public GameObject alertText;

	void Start () {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_HouseCount") > 1)
        {
            gameObject.SetActive(false);
            Instantiate(House2Prefab, new Vector3(227, 1, 184), Quaternion.identity);
        }

        Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_HouseCount") > 1)
        {
            gameObject.SetActive(false);
            Instantiate(House2Prefab, new Vector3(227, 1, 184), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a second house!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("House")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_HouseCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_HouseCount") + 1);
			Instantiate(House2Prefab, new Vector3(227, 1, 184), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("House");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (215, 6, 164);
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
