using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TreeResize : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Toggle toggle;
    [SerializeField] Slider slider;
    [SerializeField] bool isOn = false;
    [Header("Resize")]
    [SerializeField, Range(1, 3)] float vectorY = 1f;
    [SerializeField,Range(0, 2)] float resizeSpeed;

    public void FixedUpdate()
    {
        
          
        if (isOn)
        {          
            vectorY += resizeSpeed * Time.deltaTime;       
            vectorY = Mathf.Clamp(vectorY, 1f, 1.5f);
                
            gameObject.transform.localScale = new Vector3(1, vectorY, 1);                     
        }
        else if(!isOn)
        {            
           vectorY -= resizeSpeed * Time.deltaTime;
           vectorY = Mathf.Clamp(vectorY, 1f, 2f);
             
            gameObject.transform.localScale = new Vector3(1, vectorY, 1);                  
        }
    }

    public void ChangeTreesH()
    {
        if (toggle.isOn)
        {
            isOn = true;         
        }
        else if(!toggle.isOn)
        {
            isOn = false;
        }
    }
}
