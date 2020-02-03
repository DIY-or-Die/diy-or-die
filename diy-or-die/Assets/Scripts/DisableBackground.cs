using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBackground : MonoBehaviour
{
    private float counter;

    void Update()
    {
        counter += Time.deltaTime;
        if (counter > 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
