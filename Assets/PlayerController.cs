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
    public float jumpPower;
    public float moveSpeed;
    public float coyoteTime = 0.2f;

    private Rigidbody rb;
    private bool m_grounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 movement = rb.velocity;
        
        if (m_grounded)
        {
            movement.y = jumpPower;
        }

        movement.x = FaceMoveToInput.tilt * moveSpeed;
        
        rb.velocity = movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        m_grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        //StartCoroutine(CoyoteTime());
        m_grounded = false;
    }

    // https://en.wiktionary.org/wiki/coyote_time
    // Used in the context of jumping in the game
    IEnumerator CoyoteTime()
    { 
        if (!FaceMoveToInput.jump)
            yield return new WaitForSeconds(coyoteTime);
        m_grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform") && transform.position.y >= other.transform.position.y)
        {
            other.isTrigger = false;
        }
    }
}
