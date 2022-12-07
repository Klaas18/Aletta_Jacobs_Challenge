using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeResize : MonoBehaviour
{
    Vector3 v3 = new Vector3(1f, 1.5f, 1f);
    private void Start()
    {

    }

  public void ChangeTreesH()
    {
        gameObject.transform.position.Set(-1f,1f, -1f);
    //    gameObject.transform.localScale.Set(1f, 1.5f, 1f);
        gameObject.transform.localScale = v3;
        gameObject.transform.localPosition = -v3;
    }
}
