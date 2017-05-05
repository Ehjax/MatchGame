// (Unity3D) New monobehaviour script that includes regions for common sections, and supports debugging.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateResourceTotals : MonoBehaviour
{
    #region GlobalVareables
    #region DefaultVareables
    public bool isDebug = false;
    private string debugScriptName = "UpdateResourceTotals";
    #endregion

    #region Static

    #endregion

    #region Public

    #endregion

    #region Private
    private Text uiWoodText = null;
    private Text uiStoneText = null;
    private Text uiGoldText = null;
    private Text uiFoodText = null;
    #endregion
    #endregion

    #region CustomFunction
    #region Static

    #endregion

    #region Public

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
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform currChild = transform.GetChild(i);
            if (currChild.name == "Wood") uiWoodText = currChild.GetComponent<Text>();
            else if (currChild.name == "Stone") uiStoneText = currChild.GetComponent<Text>();
            else if (currChild.name == "Gold") uiGoldText = currChild.GetComponent<Text>();
            else if (currChild.name == "Food") uiFoodText = currChild.GetComponent<Text>();
        }
    }
    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {

    }
    // Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        uiWoodText.text = "Wood: " + PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_woodTotal");
        uiStoneText.text = "Stone: " + PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_stoneTotal");
        uiGoldText.text = "Gold: " + PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_goldTotal");
        uiFoodText.text = "Food: " + PlayerPrefs.GetInt(Game.current.PlayerOne.name + "_foodTotal");
    }
    // LateUpdate is called every frame after all other update functions, if the Behaviour is enabled.
    void LateUpdate()
    {

    }
    #endregion
}