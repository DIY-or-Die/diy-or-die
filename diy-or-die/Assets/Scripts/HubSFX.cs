using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class HubSFX : MonoBehaviour
{
    string refillFluid = "event:/SFX/Refill/Heat";
    string refillTire = "event:/SFX/Refill/Traction";
    string refillWindShield = "event:/SFX/Refill/Visibility";

    string crafting = "event:/SFX/Craft/Crafting2";

    GameObject theCar;
    // Start is called before the first frame update
    void Start()
    {
        theCar = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("F*CKING GIVE ME SOMETHING!!!!!");

        if(theCar.transform.GetChild(0).gameObject)
        {
            Debug.Log("Play Heat Sound");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I NEED A SIGN!!!!!!!!!");
        Debug.Log(other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
{
        Debug.Log("Blah");
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("WHY WONT YOU COLLIDE ME?!?!?!?!!?!?!?!!");
        Debug.Log(other);
    }

}
