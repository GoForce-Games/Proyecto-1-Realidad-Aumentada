using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.XR.ARFoundation;

public class FaceMoveToInput : MonoBehaviour
{
    private ARFaceManager m_face = null; 

    private FaceInputDevice m_faceDevice = null;
    
    [SerializeField] private float maxTiltAngle = 15.0f;
    [SerializeField] private float tiltSensitivity = 1.0f;


    private void Awake()
    {
        InputSystem.RegisterLayout<FaceInputDevice>(
            matches: new InputDeviceMatcher()
                .WithInterface("FaceInput"));

        m_faceDevice = InputSystem.AddDevice<FaceInputDevice>("FaceInput");
    }

    private void OnEnable()
    {
        if (m_face)
            m_face.facesChanged += OnFaceChanged;
    }

    private void OnDisable()
    {
        if (m_face)
            m_face.facesChanged -= OnFaceChanged;
    }


    private void OnFaceChanged(ARFacesChangedEventArgs facesChangedEventArgs)
    {
        foreach (ARFace f in facesChangedEventArgs.updated)
            UpdateFaceTracking(f);
    }

    private void UpdateFaceTracking(ARFace face)
    {
        float rotZ = face.transform.rotation.eulerAngles.z;
        float moveX = Mathf.Clamp(rotZ, -maxTiltAngle, maxTiltAngle) / maxTiltAngle;

        bool leftEyeOpen = face.leftEye.localScale.y > 0.5f;
        bool rightEyeOpen = face.rightEye.localScale.y > 0.5f;
        
        InputSystem.QueueDeltaStateEvent(m_faceDevice.tiltX, moveX);
        InputSystem.QueueDeltaStateEvent(m_faceDevice.leftEyeClosed, leftEyeOpen ? 0f : 1f);
        InputSystem.QueueDeltaStateEvent(m_faceDevice.rightEyeClosed, rightEyeOpen ? 0f : 1f);
        InputSystem.Update();

        Debug.LogFormat("Tilt: %f\nLeft eye open: %s\nRight eye open: %s", moveX, leftEyeOpen, rightEyeOpen);


    }
}
