using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Nombre de la escena del juego")]
    public string nombreSiguienteEscena; // Asignás el nombre desde el Inspector

    // Llamado por el botón "Jugar"
    public void Jugar()
    {
        if (!string.IsNullOrEmpty(nombreSiguienteEscena))
        {
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó ninguna escena en el inspector.");
        }
    }

    // Llamado por el botón "Salir"
    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
#else
        Application.Quit(); // Cierra el juego compilado
#endif
    }
}
