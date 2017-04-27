using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public enum Menu {
        Title,
        MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;

	void OnGUI () {

		GUILayout.BeginArea(new Rect(0,200,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.MainMenu) {

			//GUILayout.Box("Anti - Nomad");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				Game.current = new Game();
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				SaveLoad.Load();
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}

		else if (currentMenu == Menu.NewGame) {

			GUILayout.Box("Name Your Characters");
			GUILayout.Space(10);

			GUILayout.Label("Player One");
			Game.current.PlayerOne.name = GUILayout.TextField(Game.current.PlayerOne.name, 20);
		
			if(GUILayout.Button("Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save();
				//Move on to game...
				SceneManager.LoadScene("match3");
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}

		}

		else if (currentMenu == Menu.Continue) {
			
			GUILayout.Box("Select Save File");
			GUILayout.Space(10);
			
			foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(g.PlayerOne.name)) {
					Game.current = g;
					//Move on to game...
					SceneManager.LoadScene("City_Final");				}

			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
			
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}

    public GameObject titleScreen = null;
    public GameObject mainMenuScreen = null;
    public GameObject newGameScreen = null;
    public InputField nameField = null;
    public GameObject continueScreen = null;

    public void StartGame()
    {
        currentMenu = Menu.MainMenu;
    }
    public void NewGame()
    {
        currentMenu = Menu.NewGame;
        Game.current = new Game();
    }
    public void SaveName()
    {
        Game.current.PlayerOne.name = nameField.text;
        Debug.Log(Game.current.PlayerOne.name);
        SaveLoad.Save();
        SceneManager.LoadScene("match3");
    }
    public void Continue()
    {
        currentMenu = Menu.Continue;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        switch (currentMenu)
        {
            case Menu.Title:
                titleScreen.SetActive(true);
                mainMenuScreen.SetActive(false);
                newGameScreen.SetActive(false);
                continueScreen.SetActive(false);
                break;
            case Menu.MainMenu:
                titleScreen.SetActive(false);
                mainMenuScreen.SetActive(true);
                newGameScreen.SetActive(false);
                continueScreen.SetActive(false);
                break;
            case Menu.NewGame:
                titleScreen.SetActive(false);
                mainMenuScreen.SetActive(false);
                newGameScreen.SetActive(true);
                continueScreen.SetActive(false);
                break;
            case Menu.Continue:
                titleScreen.SetActive(false);
                mainMenuScreen.SetActive(false);
                newGameScreen.SetActive(false);
                continueScreen.SetActive(true);
                break;
        }
    }
}
