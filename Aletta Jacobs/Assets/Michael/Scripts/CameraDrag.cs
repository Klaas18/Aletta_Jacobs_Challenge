using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float lookSensitivity = 2;
    private Vector3 dragOrigin;

    public GameObject player;
    public Camera myCamera;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] public float _moveSpeed;

    void FixedUpdate()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    dragOrigin = Input.mousePosition;
        //    return;
        //}

        //if (!Input.GetMouseButton(0)) return;

        //player.transform.eulerAngles += lookSensitivity * new Vector3(0, Input.GetAxis("Mouse X"), 0);
        myCamera.transform.eulerAngles -= new Vector3(_joystick.Vertical * (_moveSpeed * Time.deltaTime),0);
        myCamera.transform.eulerAngles += new Vector3(0, _joystick.Horizontal * (_moveSpeed * Time.deltaTime));


    }
}
