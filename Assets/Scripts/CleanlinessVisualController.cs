using UnityEngine;

public class CleanlinessVisualController : MonoBehaviour
{
    [SerializeField] private AquariumStats aquariumStats;
    [SerializeField] private SpriteRenderer filtroVidrioRenderer;
    [SerializeField] private int maxCleanlinessLevel = 100; // Valor máximo de limpieza
    
    private void Start()
    {
        // Asegurarse de que tenemos acceso al AquariumStats
        if (aquariumStats != null)
        {
            // Suscribirse al evento del acuario para actualizar cuando cambie la limpieza
            aquariumStats.aquariumEvent.AddListener(UpdateFiltroVidrioAlpha);
            
            // Inicializar con el valor actual de limpieza
            UpdateFiltroVidrioAlpha();
        }
        else
        {
            Debug.LogWarning("CleanlinessVisualController: No se ha asignado AquariumStats");
        }
    }
    
    private void OnDestroy()
    {
        // Eliminar el listener cuando se destruya el objeto
        if (aquariumStats != null)
        {
            aquariumStats.aquariumEvent.RemoveListener(UpdateFiltroVidrioAlpha);
        }
    }
    
    // Método que actualiza el alpha del FiltroVidrio basado en el nivel de limpieza
    private void UpdateFiltroVidrioAlpha()
    {
        if (filtroVidrioRenderer != null && aquariumStats != null)
        {
            // Obtener el nivel de limpieza actual
            float cleanlinessLevel = aquariumStats.CleanlinessLevel;
            
            // Normalizar el valor de limpieza (convertirlo a un rango de 0 a 1)
            float normalizedCleanliness = cleanlinessLevel / maxCleanlinessLevel;
            
            // Cuando la limpieza está al mínimo (0), el alpha debe estar al máximo (1)
            // Cuando la limpieza está al máximo (100), el alpha debe ser cero (0)
            // Por lo tanto, usamos una relación inversa: alpha = 1 - normalizedCleanliness
            
            Color currentColor = filtroVidrioRenderer.color;
            currentColor.a = 1 - normalizedCleanliness;
            filtroVidrioRenderer.color = currentColor;
        }
    }
}