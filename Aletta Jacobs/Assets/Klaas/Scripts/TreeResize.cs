using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeResize : MonoBehaviour
{
   [SerializeField] Toggle toggle;
    Vector3 v3 = new Vector3(1f, 1.5f, 1f);
    Vector3 orignalV3;
    [SerializeField,Range(0, 20)] float scale;
    private void Start()
    {
        orignalV3 = gameObject.transform.localScale; 
    }

  public void ChangeTreesH()
    {
        if (toggle.isOn)
        {
            gameObject.transform.localScale = v3;
            gameObject.transform.localPosition = -v3;
        }
        else
        {
            gameObject.transform.localScale = orignalV3;
            gameObject.transform.localPosition = -orignalV3;
        }
    }
}
