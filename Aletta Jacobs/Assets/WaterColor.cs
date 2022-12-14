using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterColor : MonoBehaviour
{
    [SerializeField] MeshRenderer meshR;
    [SerializeField] Material newMat;
    [SerializeField] Material oldMat;
    [SerializeField] Toggle toggle;

    private void Start()
    {
        meshR = gameObject.GetComponent<MeshRenderer>();
    }

    public void ChangeWater()
    {
        if (toggle.isOn)
        {        
            meshR.material = newMat;
        }
        else
        {
            meshR.material = oldMat;
        }
    }
}
