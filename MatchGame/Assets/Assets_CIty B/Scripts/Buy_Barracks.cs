using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Barracks : MonoBehaviour {

	public GameObject BarracksPrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {

        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_BarracksCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(BarracksPrefab, new Vector3(210, 4, 245), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_BarracksCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(BarracksPrefab, new Vector3(210, 4, 245), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a Barracks!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Barracks")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_BarracksCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_BarracksCount") + 1);
			Instantiate(BarracksPrefab, new Vector3(210, 4, 245), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Barracks");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (210, 12, 225);
			GetComponent<Image> ().color = Color.black;


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{

			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 1 second
			GetComponent<Image> ().color = Color.red;
			Debug.Log ("You don't have enough for that");
			alertText.SetActive (true);

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
