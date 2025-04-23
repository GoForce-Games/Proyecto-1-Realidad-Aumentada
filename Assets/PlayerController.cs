using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerController : MonoBehaviour
{

    public TMP_Text text;
    
    //private ARFaceManager m_faceManager;

    private void Start()
    {
        //m_faceManager = FindObjectOfType<ARFaceManager>();
    }


    private void Update()
    {
        if (FaceMoveToInput.jump)
        {
            transform.Translate(Vector3.up * 1.0f);
        }
        
        transform.Translate(Vector3.right * (FaceMoveToInput.tilt * 0.01f));
        text.text = FaceMoveToInput.tilt.ToString();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
            transform.Translate(Vector3.up * 1.0f);
        }
    }
    public void OnMoveX(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.Translate(Vector3.right * 1.0f);
        }
    }
}
