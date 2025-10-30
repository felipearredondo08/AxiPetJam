using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionsModalController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject modalOptions;
    public Button optionsButton;
    
    [Header("Configuración de Fade")]
    public float fadeDuration = 0.3f;
    public bool startHidden = true;
    
    private CanvasGroup modalCanvasGroup;
    private bool isVisible = false;
    
    void Start()
    {
        // Asegurarse de que el modal tenga un CanvasGroup
        modalCanvasGroup = modalOptions.GetComponent<CanvasGroup>();
        if (modalCanvasGroup == null)
        {
            modalCanvasGroup = modalOptions.AddComponent<CanvasGroup>();
        }
        
        // Configurar el botón para que llame a la función ToggleModal
        optionsButton.onClick.AddListener(ToggleModal);
        
        // Configuración inicial
        if (startHidden)
        {
            modalCanvasGroup.alpha = 0f;
            modalCanvasGroup.interactable = false;
            modalCanvasGroup.blocksRaycasts = false;
            modalOptions.SetActive(false);
            isVisible = false;
        }
        else
        {
            modalCanvasGroup.alpha = 1f;
            modalCanvasGroup.interactable = true;
            modalCanvasGroup.blocksRaycasts = true;
            modalOptions.SetActive(true);
            isVisible = true;
        }
    }
    
    public void ToggleModal()
    {
        if (isVisible)
        {
            StartCoroutine(FadeOut());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
    }
    
    private IEnumerator FadeIn()
    {
        // Activar el GameObject antes de comenzar el fade in
        modalOptions.SetActive(true);
        
        // Iniciar con alpha 0
        modalCanvasGroup.alpha = 0f;
        
        // Desactivar interacción hasta que sea visible
        modalCanvasGroup.interactable = false;
        modalCanvasGroup.blocksRaycasts = false;
        
        // Fade in gradual
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            modalCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Asegurar que el alpha sea exactamente 1 al final
        modalCanvasGroup.alpha = 1f;
        
        // Activar interacción cuando sea completamente visible
        modalCanvasGroup.interactable = true;
        modalCanvasGroup.blocksRaycasts = true;
        
        isVisible = true;
    }
    
    private IEnumerator FadeOut()
    {
        // Desactivar interacción inmediatamente
        modalCanvasGroup.interactable = false;
        modalCanvasGroup.blocksRaycasts = false;
        
        // Fade out gradual
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            modalCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Asegurar que el alpha sea exactamente 0 al final
        modalCanvasGroup.alpha = 0f;
        
        // Desactivar el GameObject cuando sea completamente invisible
        modalOptions.SetActive(false);
        
        isVisible = false;
    }
}