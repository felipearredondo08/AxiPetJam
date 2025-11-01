using UnityEngine;
using System.Collections;

public class LuzPeceraController : MonoBehaviour
{
    [SerializeField] private GameObject luzPecera;
    [SerializeField] private Pet pet;
    [SerializeField] private CareController careController;
    [SerializeField] private float tiempoLuzApagada = 3f; // Tiempo mínimo que la luz permanecerá apagada
    
    private bool isSleeping = false;
    private bool isTimerRunning = false;

    private void Start()
    {
        // Suscribirse al evento de cambio de stats
        pet.Stats.statsEvent.AddListener(CheckSleepingState);
    }

    private void OnDestroy()
    {
        // Desuscribirse del evento al destruir el objeto
        pet.Stats.statsEvent.RemoveListener(CheckSleepingState);
    }
    
    // También podemos monitorear directamente cuando se presiona el botón de dormir
    private void Update()
    {
        // Si el temporizador está corriendo, no hacemos nada más
        if (isTimerRunning)
            return;
            
        // Verificar si la acción actual es dormir (Stat.SleepLevel)
        Animator animator = pet.GetComponent<Animator>();
        int currentAction = animator.GetInteger("ActionState");
        
        // El valor 1 corresponde a Stat.SleepLevel según el enum Stat en Action.cs
        if (currentAction == 1 && !isSleeping) // Si está durmiendo y no estaba durmiendo antes
        {
            // Desactivar la luz de la pecera y comenzar el temporizador
            luzPecera.SetActive(false);
            isSleeping = true;
            StartCoroutine(MantenerLuzApagada());
        }
        else if (currentAction != 1 && isSleeping && !isTimerRunning) // Si ya no está durmiendo pero estaba durmiendo antes
        {
            // Activar la luz de la pecera solo si no hay un temporizador activo
            luzPecera.SetActive(true);
            isSleeping = false;
        }
    }

    private IEnumerator MantenerLuzApagada()
    {
        // Indicar que el temporizador está corriendo
        isTimerRunning = true;
        
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(tiempoLuzApagada);
        
        // Después del tiempo, verificamos si el personaje sigue durmiendo
        Animator animator = pet.GetComponent<Animator>();
        int currentAction = animator.GetInteger("ActionState");
        
        // Si ya no está durmiendo, activamos la luz
        if (currentAction != 1)
        {
            luzPecera.SetActive(true);
            isSleeping = false;
        }
        
        // Indicar que el temporizador ha terminado
        isTimerRunning = false;
    }

    private void CheckSleepingState()
    {
        // Este método se llama cuando cambian las stats, pero podemos dejarlo vacío
        // ya que ahora manejamos todo en Update para mayor precisión
    }
}