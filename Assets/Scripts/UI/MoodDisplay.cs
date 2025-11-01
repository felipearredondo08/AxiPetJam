using UnityEngine;
using TMPro;

public class MoodDisplay : MonoBehaviour
{
    [Header("Referencias")]
    public PetStats petStats;
    public TextMeshProUGUI moodText;

    private void Start()
    {
        if (petStats == null)
        {
            Debug.LogError("PetStats no asignado en MoodDisplay");
            return;
        }

        if (moodText == null)
        {
            moodText = GetComponent<TextMeshProUGUI>();
            if (moodText == null)
            {
                Debug.LogError("No se encontró un componente TextMeshProUGUI en este GameObject");
                return;
            }
        }

        // Suscribirse al evento de cambio de estadísticas
        petStats.statsEvent.AddListener(UpdateMoodText);
        
        // Actualizar el texto inicial
        UpdateMoodText();
    }

    private void UpdateMoodText()
    {
        if (petStats == null || moodText == null) return;

        // Obtener el estado de ánimo actual
        Mood currentMood = petStats.Mood;
        
        // Convertir el enum a texto y mostrarlo
        string moodString = GetMoodText(currentMood);
        moodText.text = moodString;
    }

    private string GetMoodText(Mood mood)
{
    return mood.ToString();
}
}