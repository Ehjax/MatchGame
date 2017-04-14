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
		Instantiate(WallPrefab, new Vector3(229, 1, 204), Quaternion.identity);
		//Purchase.gameObject.SetActive(false);
		GetComponent<Image> ().color = Color.red;
	}
}
