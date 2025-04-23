using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.XR.ARFoundation;

public class FaceMoveToInput : MonoBehaviour
{
    private ARFaceManager m_faceManager = null;
    //public ARFace face;

    private FaceInput _face = null;
    
    [SerializeField] private float maxTiltAngle = 15.0f;
    [SerializeField] private float tiltSensitivity = 1.0f;

    private bool initialized = false;
    private float startAngleX = 0.0f;

    public static bool jump = false;

    public static float tilt = 0.0f;
    

    private void Start()
    {
        m_faceManager = FindObjectOfType<ARFaceManager>();
    }

    private void OnEnable()
    {
        if (!m_faceManager)
            m_faceManager = FindObjectOfType<ARFaceManager>();
        
        if (m_faceManager)
            m_faceManager.facesChanged += OnFaceChanged;
    }

    private void OnDisable()
    {
        if (!m_faceManager)
            m_faceManager = FindObjectOfType<ARFaceManager>();
        
        if (m_faceManager)
            m_faceManager.facesChanged -= OnFaceChanged;
    }


    private void OnFaceChanged(ARFacesChangedEventArgs facesChangedEventArgs)
    {
        foreach (ARFace f in facesChangedEventArgs.updated)
            UpdateFaceTracking(f);
    }

    private void UpdateFaceTracking(ARFace face)
    {
        float rotX = face.transform.rotation.eulerAngles.x;
        float rotZ = face.transform.rotation.eulerAngles.z;
        if (rotZ >= 180) rotZ -= 360; 
        float moveX = Mathf.Clamp(rotZ*tiltSensitivity, -maxTiltAngle, maxTiltAngle) / maxTiltAngle;

        if (!initialized)
        {
            startAngleX = rotX;
            initialized = true;
        }

        jump = Math.Abs(rotX - startAngleX) > 15.0f;
        
        tilt = moveX;

    }
}
