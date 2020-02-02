using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    EventInstance music;
    

    EventInstance birdAmbience;
    EventInstance nightAmbience;

    //100 - 76% Health
    EventDescription musicDescription;
    PARAMETER_DESCRIPTION triggerMusic;
    PARAMETER_ID mID;

    //75 - 51% Health
    PARAMETER_DESCRIPTION ThreeFourthsHp;
    PARAMETER_ID m34ID;

    //51 - 26% Health
    PARAMETER_DESCRIPTION TwoFourthsHP;
    PARAMETER_ID m24ID;

    //25 - 1% Health
    PARAMETER_DESCRIPTION OneFourthHP;
    PARAMETER_ID m14ID;

    void Awake()
    {
        music = RuntimeManager.CreateInstance("event:/Music/Music");
        musicDescription = RuntimeManager.GetEventDescription("event:/Music/Music");

        musicDescription.getParameterDescriptionByName("Health", out triggerMusic);
        mID = triggerMusic.id;

        music.setParameterByID(mID, 4.00f);
        Debug.Log("on Wake");
        music.start();
    }

    // Start is called before the first frame update
    void Start()
    {
        //birdAmbience = RuntimeManager.CreateInstance("event:/SFX/Ambience/Bird_Ambient");
        //nightAmbience = RuntimeManager.CreateInstance("event:/SFX/Ambience/Night_Ambient");
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if(gameObject.tag == "75HealthMusic")
        {
            Debug.Log("Dropped 75% Health");
            musicDescription.getParameterDescriptionByName("Health", out triggerMusic);
            mID = triggerMusic.id;

            music.setParameterByID(mID, 3.00f);
        } 
        else if (gameObject.tag == "50HealthMusic")
        {
            musicDescription.getParameterDescriptionByName("Health", out triggerMusic);
            mID = triggerMusic.id;

            music.setParameterByID(mID, 2.00f);
        }
        else if (gameObject.tag == "25HealthMusic")
        {
            musicDescription.getParameterDescriptionByName("Health", out triggerMusic);
            mID = triggerMusic.id;

            music.setParameterByID(mID, 1.00f);
        }
        else if (gameObject.tag == "music")
        {
            musicDescription.getParameterDescriptionByName("Health", out triggerMusic);
            mID = triggerMusic.id;

            music.setParameterByID(mID, 4.00f);
        }

    }

    //Debug.Log("Night Mode");
    //if(gameObject.tag == "Night_Ambience")
    //{

    //    if (!NightModeOn)
    //    {
    //        Debug.Log("Night Mode Click");
    //        birdAmbience.start();
    //        //nightAmbience.start();
    //        NightModeOn = true;
    //    } else
    //    {
    //        NightModeOn = false;
    //        birdAmbience.setPaused(false);
    //        //nightAmbience.setPaused(false);
    //    }
    //}
}
