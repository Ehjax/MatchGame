using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Buy_Armorsmith : MonoBehaviour {
	public GameObject armorsmithPrefab;
	public Button Purchase;
	public GameObject alertText;
//	public Transform target;

	void Start () {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_ArmorsmithCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(armorsmithPrefab, new Vector3(143, 6, 320), Quaternion.identity);
        }

		Button btn = Purchase.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		alertText.SetActive (false);
	}

    private void Update()
    {
        if (PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_ArmorsmithCount") > 0)
        {
            gameObject.SetActive(false);
            Instantiate(armorsmithPrefab, new Vector3(143, 6, 320), Quaternion.identity);
        }
    }

    public void TaskOnClick(){
		Debug.Log ("You bought an Armorsmith!");
		if (GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().checkCost("Armorsmith")) 
		{
			PlayerPrefs.SetInt (Game.current.PlayerOne.name + "_ArmorsmithCount", PlayerPrefs.GetInt (Game.current.PlayerOne.name + "_ArmorsmithCount") + 1);
			Instantiate(armorsmithPrefab, new Vector3(143, 6, 320), Quaternion.identity);
			//transform.LookAt(target);

			//Purchase.gameObject.SetActive(false);

			GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing> ().purchase ("Armorsmith");
			BuildingPurchasing.SINGLETON.currentBuilt++;
			BuildingPurchasing.SINGLETON.checkTier ();
			GetComponent<Image> ().color = Color.black;
			Camera.main.transform.position = new Vector3 (123, 9, 300);


		} 
		else if (!GameObject.Find ("Main Camera").GetComponent<BuildingPurchasing>().checkCost("name"))
		{
			alertText.SetActive (true);
			StartCoroutine (GoAway (alertText, 3.0F)); // 3 second

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

