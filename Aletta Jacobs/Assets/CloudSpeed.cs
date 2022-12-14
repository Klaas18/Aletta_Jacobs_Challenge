using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CloudSpeed : MonoBehaviour
{
    [SerializeField] ParticleSystem clouds1;
    [SerializeField] ParticleSystem clouds2;
    
    [SerializeField] Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    public void ChangeCloud()
    {
        var main = clouds1.main;
        var main2 = clouds2.main;
        if (toggle.isOn)
        {
            main.simulationSpeed = 100;
            main2.simulationSpeed = 100;
        } else
        {
            main.simulationSpeed = 0.5f;
            main2.simulationSpeed = 0.5f;
        }
              
    }
}
