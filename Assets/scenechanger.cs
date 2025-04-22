using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    void Start()
    {
        Invoke("CambiarEscena", 10f); // Llama al método después de 10 segundos
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("PlatformSpawnerDev"); // Reemplaza "NombreDeLaEscena" con el nombre real
    }
}

