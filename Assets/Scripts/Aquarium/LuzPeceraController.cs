using UnityEngine;

public class LuzPeceraController : MonoBehaviour
{
    [SerializeField] private GameObject luzPecera;
    [SerializeField] private Pet pet;

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

    private void CheckSleepingState()
    {
        // Verificar si la acción actual es dormir (Stat.SleepLevel)
        Animator animator = pet.GetComponent<Animator>();
        int currentAction = animator.GetInteger("ActionState");
        
        // El valor 1 corresponde a Stat.SleepLevel según el enum Stat en Action.cs
        if (currentAction == 1) // Si está durmiendo
        {
            // Desactivar la luz de la pecera
            luzPecera.SetActive(false);
        }
        else
        {
            // Activar la luz de la pecera
            luzPecera.SetActive(true);
        }
    }
}