using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player; // Asigna aquí el jugador desde el Inspector
    private float offsetY;

    void Start()
    {
        // Calculamos la diferencia inicial entre cámara y jugador
        offsetY = transform.position.y - player.position.y;
    }

    void LateUpdate()
    {
        // Solo seguimos al jugador si está por encima del centro de la cámara
        if (player.position.y > transform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y = player.position.y;
            transform.position = newPos;
        }
    }
}