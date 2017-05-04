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
    private string currPlayerName = "";

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
                PlayerPrefs.SetInt(currPlayerName + "_woodTotal", woodTotal);
                PrintDebugMsg("New total wood: " + woodCurr);
                break;
            case BlockTypes.Gold:
                preGoldTotal = goldTotal;
                goldTotal += amount;
                if (goldTotal < 0) goldTotal = 0;
                PlayerPrefs.SetInt(currPlayerName + "_goldTotal", goldTotal);
                PrintDebugMsg("New total gold: " + goldCurr);
                break;
            case BlockTypes.Stone:
                preStoneTotal = stoneTotal;
                stoneTotal += amount;
                if (stoneTotal < 0) stoneTotal = 0;
                PlayerPrefs.SetInt(currPlayerName + "_stoneTotal", stoneTotal);
                PrintDebugMsg("New total stone: " + stoneCurr);
                break;
            case BlockTypes.Food:
                preFoodTotal = foodTotal;
                foodTotal += amount;
                if (foodTotal < 0) foodTotal = 0;
                PlayerPrefs.SetInt(currPlayerName + "_foodTotal", foodTotal);
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
        woodTotal = PlayerPrefs.GetInt(currPlayerName + "_woodTotal");
        goldTotal = PlayerPrefs.GetInt(currPlayerName + "_goldTotal");
        stoneTotal = PlayerPrefs.GetInt(currPlayerName + "_stoneTotal");
        foodTotal = PlayerPrefs.GetInt(currPlayerName + "_foodTotal");
    }
    // Deletes all the total resources
    private void DeleteSavedTotals()
    {
        PlayerPrefs.DeleteKey(currPlayerName + "_woodTotal");
        PlayerPrefs.DeleteKey(currPlayerName + "_goldTotal");
        PlayerPrefs.DeleteKey(currPlayerName + "_stoneTotal");
        PlayerPrefs.DeleteKey(currPlayerName + "_foodTotal");
    }

    // Reads the saved upgrades from the city and applies each one that is enabled.
    private void LoadUpgrades()
    {
        foodBonus = 0;
        woodBonus = 0;
        stoneBonus = 0;
        goldBonus = 0;
        maxMoves = 0;

        if(PlayerPrefs.GetInt(currPlayerName + "_HouseCount") > 0)
        {
            PrintDebugMsg("HouseCount: " + PlayerPrefs.GetInt(currPlayerName + "_HouseCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_HouseCount");
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_HouseCount");
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_HouseCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_HouseCount");
            maxMoves += PlayerPrefs.GetInt(currPlayerName + "_HouseCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_MineCount") > 0)
        {
            PrintDebugMsg("MineCount: " + PlayerPrefs.GetInt(currPlayerName + "_MineCount"));
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_MineCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_MineCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_QuarryCount") > 0)
        {
            PrintDebugMsg("QuarryCount: " + PlayerPrefs.GetInt(currPlayerName + "_QuarryCount"));
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_QuarryCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_LumberCampCount") > 0)
        {
            PrintDebugMsg("LumberCampCount: " + PlayerPrefs.GetInt(currPlayerName + "_LumberCampCount"));
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_LumberCampCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_FarmCount") > 0)
        {
            PrintDebugMsg("FarmCount: " + PlayerPrefs.GetInt(currPlayerName + "_FarmCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_FarmCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount") > 0)
        {
            PrintDebugMsg("WarehouseCount: " + PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount");
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount");
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount");
            maxMoves += PlayerPrefs.GetInt(currPlayerName + "_WarehouseCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_BakeryCount") > 0)
        {
            PrintDebugMsg("BakeryCount: " + PlayerPrefs.GetInt(currPlayerName + "_BakeryCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_BakeryCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_WallsCount") > 0)
        {
            PrintDebugMsg("WallsCount: " + PlayerPrefs.GetInt(currPlayerName + "_WallsCount"));
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_WallsCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_WallsCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_ArmorsmithCount") > 0)
        {
            PrintDebugMsg("ArmorsmithCount: " + PlayerPrefs.GetInt(currPlayerName + "_ArmorsmithCount"));
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_ArmorsmithCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_ArmorsmithCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_WeaponsmithCount") > 0)
        {
            PrintDebugMsg("WeaponsmithCount: " + PlayerPrefs.GetInt(currPlayerName + "_WeaponsmithCount"));
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_WeaponsmithCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_WeaponsmithCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_BarracksCount") > 0)
        {
            PrintDebugMsg("BarracksCount: " + PlayerPrefs.GetInt(currPlayerName + "_BarracksCount"));
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_BarracksCount");
            maxMoves += PlayerPrefs.GetInt(currPlayerName + "_BarracksCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_MainGateCount") > 0)
        {
            PrintDebugMsg("MainGateCount: " + PlayerPrefs.GetInt(currPlayerName + "_MainGateCount"));
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_MainGateCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_MarketCount") > 0)
        {
            PrintDebugMsg("MarketCount: " + PlayerPrefs.GetInt(currPlayerName + "_MarketCount"));
            woodBonus += PlayerPrefs.GetInt(currPlayerName + "_MarketCount");
            stoneBonus += PlayerPrefs.GetInt(currPlayerName + "_MarketCount");
            goldBonus += PlayerPrefs.GetInt(currPlayerName + "_MarketCount");
            maxMoves += PlayerPrefs.GetInt(currPlayerName + "_MarketCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_DairyCount") > 0)
        {
            PrintDebugMsg("DairyCount: " + PlayerPrefs.GetInt(currPlayerName + "_DairyCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_DairyCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_WindmillCount") > 0)
        {
            PrintDebugMsg("WindmillCount: " + PlayerPrefs.GetInt(currPlayerName + "_WindmillCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_WindmillCount");
        }
        if (PlayerPrefs.GetInt(currPlayerName + "_SlaughterhouseCount") > 0)
        {
            PrintDebugMsg("SlaughterhouseCount: " + PlayerPrefs.GetInt(currPlayerName + "_SlaughterhouseCount"));
            foodBonus += PlayerPrefs.GetInt(currPlayerName + "_SlaughterhouseCount");
        }

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

        currPlayerName = Game.current.PlayerOne.name;
        PrintDebugMsg("Player's name: " + currPlayerName);
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
        UpdateUI();
    }
    // LateUpdate is called every frame after all other update functions, if the Behaviour is enabled.
    void LateUpdate()
    {

    }
    #endregion
}