using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Nombre de la escena del juego")]
    public string nombreSiguienteEscena; // Asignás el nombre desde el Inspector

    [Header("Modal de Nombre")] public GameObject modalNombre;
    public TMP_InputField inputNombre;
    public Button buttonOk;
    public PetStats petStatsSO;
    public float fadeDuration = 0.3f;
    public SoundManager soundManager;

    private CanvasGroup modalCanvasGroup;

    void Start()
    {
        
        // Configurar el modal
        modalCanvasGroup = modalNombre.GetComponent<CanvasGroup>();
        if (modalCanvasGroup == null)
        {
            modalCanvasGroup = modalNombre.AddComponent<CanvasGroup>();
        }

        // Ocultar el modal al inicio
        modalNombre.SetActive(false);
        modalCanvasGroup.alpha = 0f;
        modalCanvasGroup.interactable = false;
        modalCanvasGroup.blocksRaycasts = false;

        // Configurar el botón OK
        buttonOk.onClick.AddListener(GuardarNombreYContinuar);
    }

    // Llamado por el botón "Jugar"
    public void Jugar()
    {
        // Mostrar el modal de nombre con fade
        StartCoroutine(MostrarModalNombre());
    }

    private IEnumerator MostrarModalNombre()
    {
        // Activar el modal
        modalNombre.SetActive(true);

        // Fade in
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            modalCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurar que el alpha sea exactamente 1 al final
        modalCanvasGroup.alpha = 1f;

        // Activar interacción
        modalCanvasGroup.interactable = true;
        modalCanvasGroup.blocksRaycasts = true;
    }

    public void GuardarNombreYContinuar()
    {
        // Guardar el nombre en el ScriptableObject
        if (inputNombre.text.Length > 0)
        {
            petStatsSO.Name = inputNombre.text;
        }

        // Cargar la siguiente escena
        if (!string.IsNullOrEmpty(nombreSiguienteEscena))
        {
            soundManager.Change("musica acuario");
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