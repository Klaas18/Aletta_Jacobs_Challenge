using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;

    public GameObject player;
    public Camera myCamera;

    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] public float _moveSpeed;

    public bool isUsingJoystick = true;
    void FixedUpdate()
    {

        if (!isUsingJoystick)
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    dragOrigin = Input.mousePosition;
            //    return;
            //}
            if (!Input.GetMouseButton(0)) return;
            player.transform.eulerAngles += (_moveSpeed * Time.deltaTime) * new Vector3(0, Input.GetAxis("Mouse X"), 0);
            myCamera.transform.eulerAngles += (_moveSpeed * Time.deltaTime) * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        }
        else
        {


            myCamera.transform.eulerAngles -= new Vector3(_joystick.Vertical * (_moveSpeed * Time.deltaTime), 0);
            player.transform.eulerAngles += new Vector3(0, _joystick.Horizontal * (_moveSpeed * Time.deltaTime));

        }
    }
}
