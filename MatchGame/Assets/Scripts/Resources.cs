// (Unity3D) New monobehaviour script that includes regions for common sections, and supports debugging.
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Resources : MonoBehaviour
{
    #region GlobalVareables
    #region DefaultVareables
    public bool isDebug = false;
    private string debugScriptName = "Resources";
    #endregion

    #region Static
    public static Resources SINGLETON = null;
    #endregion

    #region Public
    public int startingMoves = 10;

    [Tooltip("Shows the moves remaining.")]
    public Text movesUI = null;

    [Tooltip("Shows the total wood for the whole game.")]
    public Text woodTotalUI = null;
    [Tooltip("Shows the total gold for the whole game.")]
    public Text goldTotalUI = null;
    [Tooltip("Shows the total stone for the whole game.")]
    public Text stoneTotalUI = null;
    [Tooltip("Shows the total food for the whole game.")]
    public Text foodTotalUI = null;

    [Tooltip("Shows the wood for the current round.")]
    public Text woodCurrUI = null;
    [Tooltip("Shows the gold for the current round.")]
    public Text goldCurrUI = null;
    [Tooltip("Shows the stone for the current round.")]
    public Text stoneCurrUI = null;
    [Tooltip("Shows the food for the current round.")]
    public Text foodCurrUI = null;

    public GameObject endRoundPanel = null;
    #endregion

    #region Private
    private int maxMoves = 0;
    private int currMoves = 0;

    private int woodTotal = 0;
    private int goldTotal = 0;
    private int stoneTotal = 0;
    private int foodTotal = 0;

    private int preWoodTotal = 0;
    private int preGoldTotal = 0;
    private int preStoneTotal = 0;
    private int preFoodTotal = 0;

    private int woodCurr = 0;
    private int goldCurr = 0;
    private int stoneCurr = 0;
    private int foodCurr = 0;

    private int woodBonus = 0;
    private int goldBonus = 0;
    private int stoneBonus = 0;
    private int foodBonus = 0;
    #endregion
    #endregion

    #region CustomFunction
    #region Static

    #endregion

    #region Public
    // Called when the player made a successful move. Returns true if player has no more moves left afterward.
    public bool MadeMove()
    {
        if(currMoves > 0) currMoves--;
        PrintDebugMsg("Remaining moves: " + currMoves);
        UpdateUI();

        if (currMoves <= 0) return true;
        return false;
    }

    // Adds/subtracts amount to the chosen resource for the current round.
    public void AdjustCurrResource(BlockTypes type, int amount)
    {
        switch(type)
        {
            case BlockTypes.Wood:
                woodCurr += amount + woodBonus;
                if (woodCurr < 0) woodCurr = 0;
                PrintDebugMsg("New wood: " + woodCurr);
                break;
            case BlockTypes.Gold:
                goldCurr += amount + goldBonus;
                if (goldCurr < 0) goldCurr = 0;
                PrintDebugMsg("New gold: " + goldCurr);
                break;
            case BlockTypes.Stone:
                stoneCurr += amount + stoneBonus;
                if (stoneCurr < 0) stoneCurr = 0;
                PrintDebugMsg("New stone: " + stoneCurr);
                break;
            case BlockTypes.Food:
                foodCurr += amount + foodBonus;
                if (foodCurr < 0) foodCurr = 0;
                PrintDebugMsg("New food: " + foodCurr);
                break;
        }

        UpdateUI();
    }
    // Adds/subtracts amount to the chosen resource for the total resources in the game.
    public void AdjustTotalResource(BlockTypes type, int amount)
    {
        switch (type)
        {
            case BlockTypes.Wood:
                preWoodTotal = woodTotal;
                woodTotal += amount;
                if (woodTotal < 0) woodTotal = 0;
                PlayerPrefs.SetInt("woodTotal", woodTotal);
                PrintDebugMsg("New total wood: " + woodCurr);
                break;
            case BlockTypes.Gold:
                preGoldTotal = goldTotal;
                goldTotal += amount;
                if (goldTotal < 0) goldTotal = 0;
                PlayerPrefs.SetInt("goldTotal", goldTotal);
                PrintDebugMsg("New total gold: " + goldCurr);
                break;
            case BlockTypes.Stone:
                preStoneTotal = stoneTotal;
                stoneTotal += amount;
                if (stoneTotal < 0) stoneTotal = 0;
                PlayerPrefs.SetInt("stoneTotal", stoneTotal);
                PrintDebugMsg("New total stone: " + stoneCurr);
                break;
            case BlockTypes.Food:
                preFoodTotal = foodTotal;
                foodTotal += amount;
                if (foodTotal < 0) foodTotal = 0;
                PlayerPrefs.SetInt("foodTotal", foodTotal);
                PrintDebugMsg("New total food: " + foodCurr);
                break;
        }

        UpdateUI();
    }

    // Takes the current resources from this round and applies it to the total resources for each.
    public void EndRound()
    {
        AdjustTotalResource(BlockTypes.Wood, woodCurr);
        AdjustTotalResource(BlockTypes.Gold, goldCurr);
        AdjustTotalResource(BlockTypes.Stone, stoneCurr);
        AdjustTotalResource(BlockTypes.Food, foodCurr);

        endRoundPanel.SetActive(true);

        UpdateUI();
    }
    #endregion

    #region Private
    // Updates all the UI labels for each resource and moves counter.
    private void UpdateUI()
    {
        movesUI.text = "Moves remaining: " + currMoves;

        woodTotalUI.text = "Total wood: " + preWoodTotal + " + " + woodCurr + " = " + woodTotal;
        goldTotalUI.text = "Total gold: " + preGoldTotal + " + " + goldCurr + " = " + goldTotal;
        stoneTotalUI.text = "Total stone: " + preStoneTotal + " + " + stoneCurr + " = " + stoneTotal;
        foodTotalUI.text = "Total food: " + preFoodTotal + " + " + foodCurr + " = " + foodTotal;

        woodCurrUI.text = "Wood: " + woodCurr;
        goldCurrUI.text = "Gold: " + goldCurr;
        stoneCurrUI.text = "Stone: " + stoneCurr;
        foodCurrUI.text = "Food: " + foodCurr;
    }

    // Loads the resource totals from PlayerPrefs
    private void LoadSavedTotals()
    {
        woodTotal = PlayerPrefs.GetInt("woodTotal");
        goldTotal = PlayerPrefs.GetInt("goldTotal");
        stoneTotal = PlayerPrefs.GetInt("stoneTotal");
        foodTotal = PlayerPrefs.GetInt("foodTotal");
    }
    // Deletes all the total resources
    private void DeleteSavedTotals()
    {
        PlayerPrefs.DeleteKey("woodTotal");
        PlayerPrefs.DeleteKey("goldTotal");
        PlayerPrefs.DeleteKey("stoneTotal");
        PlayerPrefs.DeleteKey("foodTotal");
    }

    // Reads the saved upgrades from the city and applies each one that is enabled.
    private void LoadUpgrades()
    {
        foodBonus = 0;
        woodBonus = 0;
        stoneBonus = 0;
        goldBonus = 0;
        maxMoves = 0;

        if(PlayerPrefs.GetInt("HouseCount") > 0)
        {
            foodBonus += PlayerPrefs.GetInt("HouseCount");
            woodBonus += PlayerPrefs.GetInt("HouseCount");
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
            maxMoves += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("MineCount") > 0)
        {
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("QuarryCount") > 0) stoneBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("LumberCampCount") > 0) woodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("FarmCount") > 0) foodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("WarehouseCount") > 0)
        {
            foodBonus += PlayerPrefs.GetInt("HouseCount");
            woodBonus += PlayerPrefs.GetInt("HouseCount");
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
            maxMoves += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("BakeryCount") > 0) foodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("WallsCount") > 0)
        {
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("ArmorsmithCount") > 0)
        {
            woodBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("WeaponsmithCount") > 0)
        {
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("BarricksCount") > 0)
        {
            woodBonus += PlayerPrefs.GetInt("HouseCount");
            maxMoves += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("MainGateCount") > 0) woodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("MarketCount") > 0)
        {
            woodBonus += PlayerPrefs.GetInt("HouseCount");
            stoneBonus += PlayerPrefs.GetInt("HouseCount");
            goldBonus += PlayerPrefs.GetInt("HouseCount");
            maxMoves += PlayerPrefs.GetInt("HouseCount");
        }
        if (PlayerPrefs.GetInt("DairyCount") > 0) foodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("WindmillCount") > 0) foodBonus += PlayerPrefs.GetInt("HouseCount");
        if (PlayerPrefs.GetInt("SlaughterhouseCount") > 0) foodBonus += PlayerPrefs.GetInt("HouseCount");

        PrintDebugMsg("Bonuses (Food/Wood/Stone/Gold/Moves): " + foodBonus + "/" + woodBonus + "/" + stoneBonus + "/" + goldBonus + "/" + maxMoves);
    }
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
    private void OnApplicationQuit()
    {
        DeleteSavedTotals();
    }
    #endregion

    #region Start_Update
    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        PrintDebugMsg("Loaded.");

        if (Resources.SINGLETON == null) SINGLETON = this;
        else PrintErrorDebugMsg("More than one Resources.SINGLETONs detected!");
    }
    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    void Start()
    {
        maxMoves = startingMoves;
        currMoves = maxMoves;

        LoadSavedTotals();
        LoadUpgrades();

        UpdateUI();
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