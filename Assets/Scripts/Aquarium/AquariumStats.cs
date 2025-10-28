using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Aquarium", menuName = "Stats/Aquarium")]
public class AquariumStats : ScriptableObject
{
    public int cleanlinessLevel;
    public UnityEvent aquariumEvent;
    public bool sendMessage;
    
    private void OnEnable()
    {
        aquariumEvent ??= new UnityEvent();
    }
}