using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSize : MonoBehaviour
{

    private static float size;
    GameObject cube;

    public static float Size { get => size; set => size = value; }

    // Start is called before the first frame update
    void Start()
    {
        cube = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.localScale.Set(cube.transform.localScale.x, size/10, cube.transform.localScale.z);
    }

}
