using UnityEngine;
using TMPro;

public class NombreDisplay : MonoBehaviour
{
    [Header("Referencias")]
    public PetStats petStatsSO;
    public TextMeshProUGUI nombreText;

    void Start()
    {
        // Verificar que tenemos las referencias necesarias
        if (petStatsSO != null && nombreText != null)
        {
            // Mostrar el nombre guardado en el ScriptableObject
            nombreText.text = petStatsSO.Name;
        }
        else
        {
            Debug.LogWarning("⚠️ Faltan referencias en NombreDisplay. Asegúrate de asignar el PetStatsSO y el TextMeshProUGUI.");
        }
    }
}