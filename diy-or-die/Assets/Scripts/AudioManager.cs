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

    string refillFluid = "event:/SFX/Refill/Heat";
    string refillTire = "event:/SFX/Refill/Traction";
    string refillWindShield = "event:/SFX/Refill/Visibility";

    string crafting = "event:/SFX/Craft/Crafting2";

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
            //Debug.Log("Grabbed item");
            RuntimeManager.PlayOneShot(clicking);
            //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/Dropping");
            

        }
        //FMODUnity.RuntimeManager.PlayOneShot(clicking);
    }

    void OnMouseUp()
    {
        //Debug.Log("Here I am");
        //Debug.Log(gameObject);
        float HubY = 150.0f;
        float VisibilityHubX = 60.0f;
        float TractionHubX = 80.0f;
        float TemperatureHubX = 190.0f;

        
        //Debug.Log(Input.mousePosition.y);

        if(Input.mousePosition.x < VisibilityHubX && Input.mousePosition.y < HubY)
        {
            Debug.Log("Play Wipers Sound");
            RuntimeManager.PlayOneShot(refillWindShield);
        }
        else if (Input.mousePosition.x < TractionHubX && Input.mousePosition.y < HubY)
        {
            Debug.Log("Play Traction Sound");
            RuntimeManager.PlayOneShot(refillTire);
        }
        else if (Input.mousePosition.x < TemperatureHubX && Input.mousePosition.y < HubY)
        {
            Debug.Log("Play Fluid Sound");
            RuntimeManager.PlayOneShot(refillFluid);
        }
        else
        {
            RuntimeManager.PlayOneShot(dropping);
        }

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
