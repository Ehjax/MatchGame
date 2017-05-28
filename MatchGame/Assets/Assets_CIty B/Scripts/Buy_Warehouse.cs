using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Warehouse : MonoBehaviour {
	public GameObject warehousePrefab;
	public Button Purchase;
	public GameObject alertText;


	void Start () {
        if(PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_WarehouseCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(warehousePrefab, new Vector3(188, 9, 211), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);

	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_WarehouseCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(warehousePrefab, new Vector3(188, 9, 211), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought a Slaughterhouse!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Slaughterhouse")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_WarehouseCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_WarehouseCount") + 1);
			Instantiate(warehousePrefab, new Vector3(188, 9, 211), Quaternion.identity);
			//Purchase.gameObject.SetActive(false);
			GetComponent<Image> ().color = Color.red;
			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Warehouse");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			Camera.main.transform.position = new Vector3 (192, 11, 191);
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
