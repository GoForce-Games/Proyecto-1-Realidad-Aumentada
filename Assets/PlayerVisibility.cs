using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVisibility : MonoBehaviour
{
    private bool isDefeated = false;

    void OnBecameInvisible()
    {
        if (!isDefeated && Camera.main != null && transform.position.y < Camera.main.transform.position.y)
        {
            isDefeated = true;
            Debug.Log("El jugador ha sido derrotado por salir de la pantalla.");
            StartCoroutine(DelayBeforeDeathScene());
        }
    }

    private System.Collections.IEnumerator DelayBeforeDeathScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EscenaMuerte"); // Cambia el nombre si tu escena tiene otro nombre
    }
} 
