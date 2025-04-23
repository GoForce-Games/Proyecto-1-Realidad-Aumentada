using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Invoke("PantallaMuerte", 5f); // Llama al método después de 10 segundos
    }

    // Update is called once per frame
    void PantallaMuerte()
    {
        SceneManager.LoadScene("Game"); // Reemplaza "NombreDeLaEscena" con el nombre real
    }
}
