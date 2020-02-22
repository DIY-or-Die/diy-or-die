using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.SceneManagement;

public class TitleMusic : MonoBehaviour
{
    EventInstance titleMusic;

    EventDescription titleDesc;
    PARAMETER_DESCRIPTION titleTrigger;
    PARAMETER_ID titleID;

    Bus MasterBus;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = RuntimeManager.GetBus("Bus:/");

        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        titleMusic = RuntimeManager.CreateInstance("event:/Music/Title");
        titleDesc = RuntimeManager.GetEventDescription("event:/Music/Title");

        titleDesc.getParameterDescriptionByName("Fade", out titleTrigger);
        titleID = titleTrigger.id;

        titleMusic.setParameterByID(titleID, 1.00f);

        titleMusic.start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnDestroy()
    {
        Debug.Log("Fade out music");
        titleMusic.setParameterByID(titleID, 0.00f);
    }
}
