using UnityEngine;

public class PetAnimationController : MonoBehaviour
{
    [SerializeField] private PetStats petStats;
    [SerializeField] private Animator animator;
    
    [Header("Parámetro del Animator")]
    [SerializeField] private string moodParameterName = "MoodState";
    
    // Valores para el parámetro del Animator
    private const int MOOD_IDLE = 0;
    private const int MOOD_HAPPY = 1;
    private const int MOOD_SAD = 2;
    private const int MOOD_TIRED = 3;
    private const int MOOD_ANGRY = 4;
    private const int MOOD_BORED = 5;
    private const int MOOD_HUNGRY = 6;
    
    private Mood currentMood;
    
    private void Start()
    {
        // Verificar que tenemos los componentes necesarios
        if (petStats == null)
        {
            Debug.LogError("PetAnimationController: No se ha asignado PetStats");
            return;
        }
        
        if (animator == null)
        {
            // Intentar obtener el componente Animator del objeto actual
            animator = GetComponent<Animator>();
            
            if (animator == null)
            {
                Debug.LogError("PetAnimationController: No se ha encontrado un componente Animator");
                return;
            }
        }
        
        // Suscribirse al evento de cambio de stats para actualizar la animación
        petStats.statsEvent.AddListener(UpdateAnimation);
        
        // Inicializar con la animación actual
        currentMood = petStats.Mood;
        UpdateAnimation();
    }
    
    private void OnDestroy()
    {
        // Eliminar el listener cuando se destruya el objeto
        if (petStats != null)
        {
            petStats.statsEvent.RemoveListener(UpdateAnimation);
        }
    }
    
    // Método que actualiza la animación basada en el mood actual
    public void UpdateAnimation()
    {
        if (animator == null)
            return;
            
        // Obtener el mood actual
        Mood newMood = petStats.Mood;
        
        // Si el mood no ha cambiado, no hacemos nada
        if (currentMood == newMood)
            return;
            
        currentMood = newMood;
        
        // Cambiar la animación según el mood
        switch (currentMood)
        {
            case Mood.Happy:
                animator.SetInteger(moodParameterName, MOOD_HAPPY);
                Debug.Log("Cambiando a animación Feliz");
                break;
            case Mood.Sad:
                animator.SetInteger(moodParameterName, MOOD_SAD);
                Debug.Log("Cambiando a animación Triste");
                break;
            case Mood.Tired:
                animator.SetInteger(moodParameterName, MOOD_TIRED);
                Debug.Log("Cambiando a animación Cansado");
                break;
            case Mood.Angry:
                animator.SetInteger(moodParameterName, MOOD_ANGRY);
                Debug.Log("Cambiando a animación Enojado");
                break;
            case Mood.Bored:
                animator.SetInteger(moodParameterName, MOOD_BORED);
                Debug.Log("Cambiando a animación Aburrido");
                break;
            case Mood.Hungry:
                animator.SetInteger(moodParameterName, MOOD_HUNGRY);
                Debug.Log("Cambiando a animación Hambriento");
                break;
            default:
                animator.SetInteger(moodParameterName, MOOD_IDLE);
                Debug.Log("Cambiando a animación Idle");
                break;
        }
    }
}