/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System.Collections;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class GameLevel : gameManagerScript, ITrackableEventHandler 
{
    //public static bool unlock_africa;
    public Renderer[] continent;
    public Renderer Lock;
    private attachGif lockGif;

    [SerializeField] private Texture2D[] frames;

    [SerializeField] protected TrackableBehaviour mTrackableBehaviour;
    [SerializeField] protected TrackableBehaviour.Status m_PreviousStatus;
    [SerializeField] protected TrackableBehaviour.Status m_NewStatus;

    protected virtual void Start()
    {
        //obj = GetComponent<Renderer>();
        //unlock_africa = false;
        //lockGif = GetComponent<attachGif>();
        

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }


    // Update is called once per frame
    void Update () {
       /* if (mlevelSelected && mTrackableBehaviour != null) {
            //SelectLevel();
            mlevelSelected = false;
        }*/
    }

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
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
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

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

         Debug.Log("1-Trackable : " + mTrackableBehaviour.TrackableName + " found!");

        // Enable rendering:
        foreach (var component in  rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        if ((mTrackableBehaviour.TrackableName == "africa") || 
            (mTrackableBehaviour.TrackableName == "australia") ||
            (mTrackableBehaviour.TrackableName == "NorthAmerica") ||
            (mTrackableBehaviour.TrackableName == "SouthAmerica")){
            Debug.Log(">>> inside continent "+mTrackableBehaviour.TrackableName);
            if(continent != null && continent.Length >0){
                Debug.Log("**Trackable : " + mTrackableBehaviour.TrackableName + " found!");
                Color red = Color.red;
                SelectLevel(continent, red);
                //select_africa = true;
                selectedGameLevels++;
                Debug.Log(">>> select_continent::selectedGameLevels "+selectedGameLevels);
            
                if(!mlevelSelected){
                    if ((mTrackableBehaviour.TrackableName == "africa") && !select_africa){
                        select_africa = true;
                    }

                    if ((mTrackableBehaviour.TrackableName == "australia") && !select_australia){
                        select_australia = true;
                    }

                    if((mTrackableBehaviour.TrackableName == "NorthAmerica") && !select_am_nord){
                        select_am_nord = true;
                    }

                    if((mTrackableBehaviour.TrackableName == "SouthAmerica") && !select_am_sud){
                        select_am_sud = true;
                    }

                    Lock.material.color = Color.yellow;
                    Lock.material.mainTexture = frames[0];
                    mlevelSelected = true;
                }else{
                    Debug.Log(">>> Level "+mTrackableBehaviour.TrackableName+" selected <<<");
                    if (unlock_africa){
                        Lock.material.mainTexture = frames[1];
                    }
                }
            }
        }
    }


     protected virtual void OnTrackingLost()
    {
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
    }


    private void SelectLevel(Renderer[] continent, Color color) {
	     Debug.Log(">>> inside level ");
        if(continent != null){
             Debug.Log(">>> inside continent ");

            for(int i = 0; i < continent.Length; i++){
                continent[i].material.color = color;
            }
        }
    }

}
