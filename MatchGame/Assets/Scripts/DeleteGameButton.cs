// (Unity3D) New monobehaviour script that includes regions for common sections, and supports debugging.
using UnityEngine;
using System.Collections;

public class DeleteGameButton : MonoBehaviour
{
    #region GlobalVareables
    #region DefaultVareables
    public bool isDebug = false;
    private string debugScriptName = "DeleteGameButton";
    #endregion

    #region Static

    #endregion

    #region Public

    #endregion

    #region Private
    private Game savedGame = null;
    #endregion
    #endregion

    #region CustomFunction
    #region Static

    #endregion

    #region Public
    public void DeleteGame()
    {
        string playerName = savedGame.PlayerOne.name;
        PrintDebugMsg("Deleting " + savedGame.PlayerOne.name + "...");

        SaveLoad.Delete(savedGame);

        PlayerPrefs.DeleteKey(playerName + "_woodTotal");
        PlayerPrefs.DeleteKey(playerName + "_stoneTotal");
        PlayerPrefs.DeleteKey(playerName + "_goldTotal");
        PlayerPrefs.DeleteKey(playerName + "_foodTotal");

        PlayerPrefs.DeleteKey(playerName + "_HouseCount");
        PlayerPrefs.DeleteKey(playerName + "_MineCount");
        PlayerPrefs.DeleteKey(playerName + "_QuarryCount");
        PlayerPrefs.DeleteKey(playerName + "_LumberCampCount");
        PlayerPrefs.DeleteKey(playerName + "_FarmCount");
        PlayerPrefs.DeleteKey(playerName + "_WarehouseCount");
        PlayerPrefs.DeleteKey(playerName + "_BakeryCount");
        PlayerPrefs.DeleteKey(playerName + "_WallsCount");
        PlayerPrefs.DeleteKey(playerName + "_ArmorsmithCount");
        PlayerPrefs.DeleteKey(playerName + "_WeaponsmithCount");
        PlayerPrefs.DeleteKey(playerName + "_BarracksCount");
        PlayerPrefs.DeleteKey(playerName + "_MainGateCount");
        PlayerPrefs.DeleteKey(playerName + "_MarketCount");
        PlayerPrefs.DeleteKey(playerName + "_DairyCount");
        PlayerPrefs.DeleteKey(playerName + "_WindmillCount");
        PlayerPrefs.DeleteKey(playerName + "_SlaughterhouseCount");

        Camera.main.GetComponent<MainMenu>().ReloadContinue();
    }
    #endregion

    #region Private

    #endregion

    #region Debug
    private void PrintDebugMsg(string msg)
    {
        if (isDebug) Debug.Log(debugScriptName + "(" + this.gameObject.name + "): " + msg);
    }
    private void PrintWarningDebugMsg(string msg)
    {
        Debug.LogWarning(debugScriptName + "(" + this.gameObject.name + "): " + msg);
    }
    private void PrintErrorDebugMsg(string msg)
    {
        Debug.LogError(debugScriptName + "(" + this.gameObject.name + "): " + msg);
    }
    #endregion

    #region Getters_Setters
    public Game SavedGame
    {
        set
        {
            savedGame = value;

            Transform continuePanel = GameObject.Find("Canvas").transform.GetChild(3).GetChild(4).GetChild(0);
            transform.parent = continuePanel;
        }
    }
    #endregion
    #endregion

    #region UnityFunctions

    #endregion

    #region Start_Update
    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        PrintDebugMsg("Loaded.");
    }
    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    void Start()
    {

    }
    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {

    }
    // Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {

    }
    // LateUpdate is called every frame after all other update functions, if the Behaviour is enabled.
    void LateUpdate()
    {

    }
    #endregion
}