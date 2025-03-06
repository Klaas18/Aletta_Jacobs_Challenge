using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    GameObject tempDebug;
    [Header("Debug Stuff")]
    [SerializeField] GameObject player;

    [Header("Debug UI")]
    [SerializeField] GameObject debugCanvas;
    [SerializeField] bool isDebugActive = false;
    [SerializeField] DebugCanvas debugCanvasScript;

    [Header("Camera Angle")]
    [SerializeField] Toggle cameraToggle;
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] Camera topDownCamera;
    [SerializeField] bool isFistPerson = true;

    [Header("Walk & Look Speed")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraDrag cameraDrag;
    [SerializeField] Slider walkSpeedS;
    [SerializeField] Slider lookSpeedS;

    [Header("Controlles")]
    [SerializeField] GameObject joyStickCanvas;
    [SerializeField] Toggle joyStickToggle;



    private void Awake()
    {
        //debugCanvasScript = FindObjectOfType<DebugCanvas>();
        playerController = GetComponentInParent<PlayerController>();
        cameraDrag = GetComponentInParent<CameraDrag>();

       // SetFunctions();
        //cameraToggle.onValueChanged.AddListener(ChangeCameraAngle);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   


    public void SpawnDebugCanvas()
    {
        if (!isDebugActive)
        {
            tempDebug = Instantiate(debugCanvas);
            try
            {
                cameraToggle = GameObject.Find("Camera Angle Toggle").GetComponent<Toggle>();
                walkSpeedS = GameObject.Find("Walk Slider").GetComponent<Slider>();
                lookSpeedS = GameObject.Find("Look Slider").GetComponent<Slider>();
                joyStickToggle = GameObject.Find("JoyStick Toggle").GetComponent<Toggle>();
            }
            catch { }
            SetFunctions();
            isDebugActive = true;
        } else
        {
            Destroy(tempDebug);
            isDebugActive = false;
        }
    }

    protected void SetFunctions()
    {
        cameraToggle.onValueChanged.AddListener(ChangeCameraAngle);
        walkSpeedS.onValueChanged.AddListener(WalkSpeed);
        lookSpeedS.onValueChanged.AddListener(LookSpeed);
        joyStickToggle.onValueChanged.AddListener(ChangeControlles);
        lookSpeedS.value = cameraDrag._moveSpeed;

    }
    private void ChangeCameraAngle(bool y)
    {
        if (isFistPerson)
        {
            firstPersonCamera.enabled = false;
            topDownCamera.enabled = true;
            isFistPerson = false;
        }
        else if(!isFistPerson)
        {

            topDownCamera.enabled = false;
            firstPersonCamera.enabled = true;
            isFistPerson = true;
        }
    }

    public void CameraAngle()
    {
        if (isFistPerson)
        {
            firstPersonCamera.enabled = false;
            isFistPerson = false;
        }
        else if (!isFistPerson)
        {
            firstPersonCamera.enabled = true;
            isFistPerson = true;
        }
    }
    public void WalkSpeed(float f)
    {
        playerController.playerSpeed = walkSpeedS.value;
    }
    public void LookSpeed(float f)
    {
        cameraDrag._moveSpeed = lookSpeedS.value;
    }

    public void ChangeControlles(bool b)
    {
        if (joyStickToggle.isOn == true)
        {
            joyStickCanvas.SetActive(true);
            playerController.isUsingJoystick = true;
            cameraDrag.isUsingJoystick = true;
        } else if(joyStickToggle.isOn == false)
        {
            joyStickCanvas.SetActive(false);
            playerController.isUsingJoystick = false;
            cameraDrag.isUsingJoystick = false; 
        }
        
    }
}
