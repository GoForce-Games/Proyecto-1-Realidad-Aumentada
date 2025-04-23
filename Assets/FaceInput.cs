using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;

[InputControlLayout(displayName = "FaceInput")]
public class FaceInput : InputDevice
{
    public AxisControl tiltX { get; private set; }
    public ButtonControl leftEyeClosed { get; private set; }
    public ButtonControl rightEyeClosed { get; private set; }
    
    protected override void FinishSetup()
    {
        base.FinishSetup();
        tiltX = GetChildControl<AxisControl>("tiltX");
        leftEyeClosed = GetChildControl<ButtonControl>("leftEyeClosed");
        rightEyeClosed = GetChildControl<ButtonControl>("rightEyeClosed");
    }
}