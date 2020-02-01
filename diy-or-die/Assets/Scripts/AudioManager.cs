using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    EventInstance music;

    EventInstance birdAmbience;
    EventInstance nightAmbience;

    EventInstance carSound;

    bool NightModeOn = false;
    bool carOn = false;
    //Ambient Sounds


    //Sound Effects
    string carHonk = "event:/SFX/Car/Car_Honk";
    string startCar = "event:/SFX/Car/Car_Start";

    // Start is called before the first frame update
    void Start()
    {
        birdAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambience/Bird_Ambient");
        nightAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Ambience/Night_Ambient");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            FMODUnity.RuntimeManager.PlayOneShot(carHonk);
        }
    }

    private void OnMouseDown()
    {

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
            FMODUnity.RuntimeManager.PlayOneShot(startCar);
        }
    }


}
