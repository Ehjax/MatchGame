using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Weaponsmith : MonoBehaviour {
	public GameObject weaponsmithPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_WeaponsmithCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(weaponsmithPrefab, new Vector3(210, 0, 334), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_WeaponsmithCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(weaponsmithPrefab, new Vector3(210, 0, 334), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought an Weaponsmith!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Weaponsmith")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_WeaponsmithCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_WeaponsmithCount") + 1);
			Instantiate(weaponsmithPrefab, new Vector3(210, 0, 334), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("House");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (210, 0, 314);
			GetComponent<Image> ().color = Color.black;


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 3 second


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
