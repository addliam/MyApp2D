using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Llamar la librería SceneManagement

public class controlNivel : MonoBehaviour
{
    /* MonoBehaviour: Clase padre, 
    desde donde se llaman las funciones (Ciclo de vida). 
    Los objetos públicos se visualizarán 
    como elementos dentro del inspector */

    public void metodoLeerEscenas(string argumentoEscena)
    {
        SceneManager.LoadScene(argumentoEscena);
    }
}
