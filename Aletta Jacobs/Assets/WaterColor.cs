using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterColor : MonoBehaviour
{
    [SerializeField] MeshRenderer meshR;
    [SerializeField] MeshRenderer[] meshRArray;
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
            for (int i = 0; i < meshRArray.Length; i++)
            {
                meshRArray[i].material = newMat;
            }
            meshR.material = newMat;
        }
        else
        {
            for (int i = 0; i < meshRArray.Length; i++)
            {
                meshRArray[i].material = oldMat;
            }
            meshR.material = oldMat;
        }
    }
}
