using UnityEngine;

public class CanvasLocator : MonoBehaviour
{

    GameObject canvas;
    Transform canvasLoc;

    private void Start()
    {
        Transform[] children = new Transform[transform.childCount];

        int i = 0;
        foreach (Transform T in transform)
            children[i++] = T;
    }

    private void Update()
    {
    }
}
