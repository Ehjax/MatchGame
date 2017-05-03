using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadMatch3 : MonoBehaviour {

	public Button match;

	void Start () {
		Button btn = match.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){

		SceneManager.LoadScene("match3");
	}
}
