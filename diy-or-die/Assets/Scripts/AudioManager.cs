﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    EventInstance music;

    EventInstance birdAmbience;
    EventInstance nightAmbience;

    EventInstance carMoving;
    EventDescription carReached;
    PARAMETER_DESCRIPTION triggerCarReached;
    PARAMETER_ID cID;

    bool NightModeOn = false;
    bool carOn = false;
    //Ambient Sounds


    //Sound Effects
    string carHonk = "event:/SFX/Car/Car_Honk";
    string startCar = "event:/SFX/Car/Car_Start";

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        birdAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambience/Bird_Ambient");
        nightAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambience/Night_Ambient");
        //startCar= FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Car/Car_Start");

        carMoving = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Car/Car_Moving");
        carReached = FMODUnity.RuntimeManager.GetEventDescription("event:/SFX/Car/Car_Moving");
        //if (gameObject.tag == "carInGame")
        //{
        //    Debug.Log("Car loaded");
        //    carMoving.start();
        //}

        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Car/Car_Moving");
        carMoving.start();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
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

    private void OnMouseDown()
    {
        //Debug.Log("Night Mode");
        if(gameObject.tag == "Night_Ambience")
        {
            
            if (!NightModeOn)
            {
                Debug.Log("Night Mode Click");
                birdAmbience.start();
                //nightAmbience.start();
                NightModeOn = true;
            } else
            {
                NightModeOn = false;
                birdAmbience.setPaused(false);
                //nightAmbience.setPaused(false);
            }
        }
        if(gameObject.tag == "StartingCar" && carOn == false)
        {
            Debug.Log("Starting Car");
            carOn = true;
            //startCar.start();
            FMODUnity.RuntimeManager.PlayOneShot(startCar);
        }
    }

    private void OnMouseOver()
    {
        if (gameObject.tag == "ReachedToPitStop")
        {
            ReachedPitStop();
        }
    }


}
