﻿// (Unity3D) New monobehaviour script that includes regions for common sections, and supports debugging.
using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    #region GlobalVareables
    #region DefaultVareables
    public bool isDebug = false;
    private string debugScriptName = "Background";
    #endregion

    #region Static

    #endregion

    #region Public
    public AudioClip[] backgroundMusic;
    public Sprite[] backgroundImages;
    #endregion

    #region Private
    
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
        int randNum = Random.Range(0, backgroundMusic.Length);
        GetComponent<AudioSource>().clip = backgroundMusic[randNum];
        GetComponent<AudioSource>().Play();
        
        randNum = Random.Range(0, backgroundImages.Length);
        GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = backgroundImages[randNum];
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