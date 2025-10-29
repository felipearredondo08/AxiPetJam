using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Aquarium", menuName = "Stats/Aquarium")]
public class AquariumStats : ScriptableObject
{
    [SerializeField] private int cleanlinessLevel;
    public UnityEvent aquariumEvent;
    [SerializeField] private int maxCleanlinessLevel = 100;

    public int CleanlinessLevel
    {
        get => cleanlinessLevel;
        set => cleanlinessLevel = Mathf.Clamp(value, 0, maxCleanlinessLevel);
    }

    private void OnEnable()
    {
        aquariumEvent ??= new UnityEvent();
    }
}