using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class DataShow : MonoBehaviour
{
    [Header("Avarage Height")]
     [SerializeField] private TextMeshProUGUI[] textSMesh;
     private Toggle toggle;
     private float avarage;
     private  int[] numbers;
    
    public void ShowAverage()
    {
        if (!toggle.isOn)
        {
            textSMesh[0].text = "";
        }
        else if(toggle.isOn)
        {
            numbers = JSONReader.heightList.ToArray();
            textSMesh[0].text = numbers.Average().ToString();
        }
    }
}
