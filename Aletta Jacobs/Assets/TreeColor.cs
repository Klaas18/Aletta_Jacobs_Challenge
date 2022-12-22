using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TreeColor : MonoBehaviour
{
    [SerializeField] GameObject oldTreeH;
    [SerializeField] GameObject[] newTrees;
    [SerializeField] Toggle toggle;

    public void ChangeLeave()
    {
        if (toggle.isOn)
        {
            oldTreeH.SetActive(true);
            //for (int i = 0; i < newTrees.Length; i++)
            //{
            //    newTrees[i].SetActive(false);
            //}
        }
        else
        {
            oldTreeH.SetActive(false);
            //for (int i = 0; i < newTrees.Length; i++)
            //{
            //    newTrees[i].SetActive(true);
            //}
        }
    }
}
