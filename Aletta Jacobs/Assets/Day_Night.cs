using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    [Header("Lighting Manager")]
    [SerializeField] LightingManager lightingManager;
    [Header("Toggle")]
    [SerializeField] Toggle toggle;
    Vector3 rotateDay = new Vector3(50, -30, 0);
    Vector3 rotateNight = new Vector3(-90, -30, 0);

    private void Update()
    {
        RotateTo();
    }
    public void ChangeTime()
    {
      
        if(toggle.isOn)
        {
            lightingManager.isTimeRunning = true;
            lightingManager.TimeOfDay = 20;
                             
        } else
        {
           
            lightingManager.TimeOfDay = 12;
         
        }
    }

    public void RotateTo()
    {
     
    }
}
