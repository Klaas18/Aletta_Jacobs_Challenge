using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    Vector3 rotateDay = new Vector3(50, -30, 0);
    Vector3 rotateNight = new Vector3(-90, -30, 0);
   public void ChangeTime()
    {
        if(toggle.isOn)
        {
            gameObject.transform.rotation = Quaternion.Euler(rotateNight);
        } else
        {
            gameObject.transform.rotation = Quaternion.Euler(rotateDay);
        }
    }
}
