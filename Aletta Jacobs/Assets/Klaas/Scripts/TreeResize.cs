using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeResize : MonoBehaviour
{
    [SerializeField]List<Component>Trees = new List<Component>();
    [SerializeField] Component[] trees;
    Vector3 v3 = new Vector3(1.5f, 1.5f, 1.5f);
    private void Start()
    {
           trees = gameObject.GetComponentsInChildren(typeof(Transform));
     
      foreach(Transform t in trees)
        {
          
            t.localScale = v3;
            t.localScale.Set(1.5f, 1.5f, 1.5f);
        }
    }

  public void ChangeTree()
    {
       
      
    }
}
