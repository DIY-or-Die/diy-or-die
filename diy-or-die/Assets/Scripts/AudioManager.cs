using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    EventInstance carMoving;
    EventDescription carReached;
    PARAMETER_DESCRIPTION triggerCarReached;
    PARAMETER_ID cID;

    PLAYBACK_STATE playState;

    //bool NightModeOn = false;
    bool carOn = false;
    //Ambient Sounds


    //Sound Effects
    string carHonk = "event:/SFX/Car/Car_Honk";
    string startCar = "event:/SFX/Car/Car_Start";
    string clicking = "event:/SFX/UI/Clicking";
    string dropping = "event:/SFX/UI/Dropping";

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

        //startCar= FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Car/Car_Start");

        carMoving = RuntimeManager.CreateInstance("event:/SFX/Car/Car_Moving");
        carReached = RuntimeManager.GetEventDescription("event:/SFX/Car/Car_Moving");

        carMoving.start();
        
        //Debug.Log(playState);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("h"))
        {
            FMODUnity.RuntimeManager.PlayOneShot(carHonk);
        }

    }

    void CarInGame()
    {
        if(carOn)
        {
            Debug.Log(startCar);
        }
    }

    void ReachedPitStop()
    {
        Debug.Log("Did I reach the end?");
        carReached.getParameterDescriptionByName("Intensity", out triggerCarReached);
        cID = triggerCarReached.id;
        carMoving.setParameterByID(cID, 1.00f);
    }

    void OnMouseDown()
    {
        //Debug.Log("Clicked on something");
        if (gameObject)
        {
            Debug.Log("Grabbed item");
            RuntimeManager.PlayOneShot(clicking);
            //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Dropping");


        }
        //FMODUnity.RuntimeManager.PlayOneShot(clicking);
    }

    void OnMouseUp()
    {
        RuntimeManager.PlayOneShot(dropping);

    }

    //private void OnMouseDown()
    //{

    //    if(gameObject.tag == "StartingCar" && carOn == false)
    //    {
    //        Debug.Log("Starting Car");
    //        carOn = true;
    //        //startCar.start();
    //        FMODUnity.RuntimeManager.PlayOneShot(startCar);
    //    }
    //}

    //private void OnMouseOver()
    //{
    //    if (gameObject.tag == "ReachedToPitStop")
    //    {
    //        ReachedPitStop();
    //    }
    //}


}
