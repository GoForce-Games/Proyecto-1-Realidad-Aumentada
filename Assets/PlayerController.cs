using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction m_jump;
    private InputAction m_moveX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_jump = InputSystem.actions["Jump"];
        m_moveX = InputSystem.actions["MoveX"];
    }

    // Update is called once per frame
    void Update()
    {
        if (m_jump.IsPressed())
        {
            Debug.Log("Jump");
        }

        if (m_moveX.ReadValue<int>() != 0)
        {
            Debug.Log("MoveX");
        }
    }
}
