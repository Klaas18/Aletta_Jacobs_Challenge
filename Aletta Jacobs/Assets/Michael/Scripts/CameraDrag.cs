using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float lookSensitivity = 2;
    private Vector3 dragOrigin;

    public GameObject player;
    public Camera myCamera;

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        player.transform.eulerAngles += lookSensitivity * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        myCamera.transform.eulerAngles += lookSensitivity * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
    }
}
