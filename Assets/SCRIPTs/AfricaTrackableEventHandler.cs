/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class AfricaTrackableEventHandler : gameManagerScript, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    private Renderer obj;
    
    // private bool pauseTimer = false;

    //declare global var
    string minutes;
    string seconds; //shows ms
    public Transform TextTargetName;
    public Transform TextDescription;
    public Transform PanelDescription;
    //public UnityEngine.Video.VideoPlayer videoPlayer;

    private IEnumerator coroutine;
    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        //timerText.text = "00:00";
        obj = GetComponent<Renderer>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable mlevelSelected " + mlevelSelected + " & select_africa : "+select_africa);
            if(mlevelSelected && select_africa){
            Debug.Log("Africa::Trackable " + mTrackableBehaviour.TrackableName + " found");
                OnTrackingFound();
            }
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        //videoPlayer.Play();
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
        {
            component.enabled = true;
            obj = component;
        }

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            //check for continent outline
            if (mTrackableBehaviour.TrackableName == "africaB0"||
            (mTrackableBehaviour.TrackableName == "africaB1") ||
            (mTrackableBehaviour.TrackableName == "africaB2") ||
            (mTrackableBehaviour.TrackableName == "africaB3") ||
            (mTrackableBehaviour.TrackableName == "africaB4")){

                EnableItem();

                //if (mTrackableBehaviour.TrackableName == "africaB0"){
                Debug.Log(">>>calls ResumeTimer()");
                StartTimer();
                //}
                //startTimer = true;
            }

            // added to stop timer
            if (mTrackableBehaviour.TrackableName == "africaB5")
            {

                Debug.Log(">>> Stop timer");
                PauseTimer(); //startTimer = false;
                unlock_africa = true;
                mlevelSelected = false;

            }
        }


    protected virtual void OnTrackingLost()
    {
        //videoPlayer.Pause();
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        //pauseTimer = true;
        if(!initial)
            PauseTimer(); //startTimer = false;
        
        //added
        TextTargetName.GetComponent<Text>().text = "no target";
        TextDescription.gameObject.SetActive(false);
        PanelDescription.gameObject.SetActive(false);

    }

    public void EnableItem(){
        if(coroutine != null){ return; }
        coroutine = ShowItem();
        StartCoroutine(coroutine);
    }

    private IEnumerator ShowItem(){

        yield return new WaitForSeconds(2f);

        if(obj != null){
            obj.enabled = false;
        }
        StopCoroutine(coroutine);
        coroutine = null;
    }
      
    // This is called from the tracking script when losing track
    public void DisableItem(){
        StopCoroutine(coroutine);
        coroutine = null;
    }

    /* added methods*/

    //Start Timer
    public void StartTimer()
    {
        Time.timeScale = 1;
        //startTime = Time.time;
        startTimer = true; //SS
        //pauseTimer = false;
        //Start Timer Here
        
        initial = false;
        Debug.Log("Timer Started");
    }

	//Pause timer
    public void PauseTimer()
    {
        Time.timeScale = 0;

        pauseTimer = true;
		startTimer = false;
		
        Debug.Log("Timer PAUSED");
    }

    // Update is called once per frame
    void Update () {

        if (startTimer)
        {
            resumeTimer = Time.time - startTime; //stores time since timer has started
            Debug.Log(">> enter Update() fn : "+resumeTimer);
            
            minutes = ((int)resumeTimer/ 60).ToString("00");
            seconds = (resumeTimer % 60).ToString("00.00"); //shows ms
            Debug.Log(">> "+minutes + ":" + seconds);
            timerText.text =  "Timer " +minutes + ":" + seconds;
            timerText.color = Color.white;
        }
        else if(pauseTimer){
            //startTimer = false;
            // PauseTimer();
            timerText.text += " PAUSE";
            timerText.color = Color.red;
            Debug.Log("Pause::startTimer:"+ startTimer);

            //startTime = resumeTimer;
            pauseTimer = false;
        }
    }

    //Reset Timer
   /* public void ResetTimer()
    {
        startTime = 0;
        Debug.Log("Timer Reset");
    }


    //Stop Timer
    public void StopTimer()
    {
        //Stop Timer Here
        //to be chanaged later
        Debug.Log("Timer Stopped");
        PauseTimer();
    }
    */
    

    #endregion // PROTECTED_METHODS
 }