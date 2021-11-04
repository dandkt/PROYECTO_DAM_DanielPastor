/***
 * 
 *  To use, add this script to a Camera Game Object.
 *
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float rotateSpeed = 2.0f;
    [SerializeField]
    private bool lockCursor = true;

    private Camera _camera;
    //private float _cameraSpeed = 1;

    private const KeyCode KEY_FORWARD = KeyCode.W;
    private const KeyCode KEY_BACK = KeyCode.S;
    private const KeyCode KEY_LEFT = KeyCode.A;
    private const KeyCode KEY_RIGHT = KeyCode.D;
    private const KeyCode KEY_UP = KeyCode.Keypad8;
    private const KeyCode KEY_DOWN = KeyCode.Keypad5;
    private const KeyCode KEY_SPEED_INC = KeyCode.KeypadPlus;
    private const KeyCode KEY_SPEED_DEC = KeyCode.KeypadMinus;


    private bool _cursorIsLocked = true;
    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Use this for initialization
    void Start () {
        _camera = GetComponent<Camera>();

        if (_camera == null)
        {
            Debug.Log("Error: There is no main camera in use...");
        } else
        {
          //  Init(transform, _camera.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (_camera != null)
        {
            //Check to see if a 'speed' button has been pressed
            GetSpeed();
            //Rotate and move the camera
            MouseLook();
            Move();
            UpdateCursorLock();
        }
            
	}

    private void GetSpeed ()
    {
        if (Input.GetKeyDown(KEY_SPEED_INC))
        {
            speed += 0.1f;
        } else if (Input.GetKeyDown(KEY_SPEED_DEC))
        {
            speed -= 0.1f;
        }
    }

    private void Move()
    {
        float frameSpeed = Time.deltaTime * speed;

        //Forward / Back
        if (Input.GetKey(KEY_FORWARD))
        {
            this.transform.Translate(0, 0, frameSpeed, Space.Self);
        } else if (Input.GetKey(KEY_BACK))
        {
            this.transform.Translate(0, 0, -frameSpeed, Space.Self);
        }

        //Left / Right
        if (Input.GetKey(KEY_LEFT))
        {
            this.transform.Translate(-frameSpeed, 0, 0, Space.Self);
        }
        else if (Input.GetKey(KEY_RIGHT))
        {
            this.transform.Translate(frameSpeed, 0, 0, Space.Self);
        }

        //Up / Down
        if (Input.GetKey(KEY_UP))
        {
            this.transform.Translate(0, frameSpeed, 0, Space.Self);
        }
        else if (Input.GetKey(KEY_DOWN))
        {
            this.transform.Translate(0, -frameSpeed, 0, Space.Self);
        }


    }

    private void MouseLook()
    {
        if (_cursorIsLocked)
        {
            yaw += rotateSpeed * Input.GetAxis("Mouse X");
            pitch -= rotateSpeed * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (!lockCursor)
        {//we force unlock the cursor if the user disable the cursor locking helper
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursos
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            _cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _cursorIsLocked = true;
        }

        if (_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
