using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CloudSpeed : MonoBehaviour
{
    [Header("Particle System")]
    [SerializeField] ParticleSystem clouds1;
    [SerializeField] ParticleSystem clouds2;
    [Header("UI")]
    [SerializeField] Toggle toggle;
    [SerializeField] bool isON;
    [Header("Speed")]
    [SerializeField, Range(0, 10)] float speedCloud;
    [SerializeField, Range(0.5f, 100)] float simuSpeed;

    private void FixedUpdate()
    {
        var main = clouds1.main;
        var main2 = clouds2.main;
        if (isON)
        {
            simuSpeed += speedCloud * Time.deltaTime;
           simuSpeed = Mathf.Clamp(simuSpeed, 0.5f, 100);
            main.simulationSpeed = simuSpeed;
            main2.simulationSpeed = simuSpeed;
        }
        else if(!isON)
        {
            simuSpeed -= speedCloud * Time.deltaTime;
            simuSpeed = Mathf.Clamp(simuSpeed, 0.5f, 100);
            main.simulationSpeed = simuSpeed;
            main2.simulationSpeed = simuSpeed;
        }
              
    }

    public void ChangeCloud()
    {         
        if (toggle.isOn)
        {
            isON = true;  
        }
        else
        {
            isON = false;
        }            
    }
}
