using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Stats/Pet", fileName = "PetStats")]
public class PetStats : ScriptableObject
{
    [SerializeField] private int hungerLevel;
    [SerializeField] private int sleepLevel;
    [SerializeField] private int happinessLevel;
    [SerializeField] private string name;
    [SerializeField] private Mood mood;
    [SerializeField] private int maxHungerLevel = 100;
    [SerializeField] private int maxSleepLevel = 100;
    [SerializeField] private int maxHappinessLevel = 100;
    
    public UnityEvent statsEvent;
    
    
    private void OnEnable()
    {
        statsEvent ??= new UnityEvent();
    }

    public int HungerLevel
    {
        get => hungerLevel;
        set => hungerLevel = Mathf.Clamp(value, 0, maxHungerLevel);
    }

    public int SleepLevel
    {
        get => sleepLevel;
        set => sleepLevel =  Mathf.Clamp(value, 0, maxSleepLevel);
    }

    public int HappinessLevel
    {
        get => happinessLevel;
        set => happinessLevel = Mathf.Clamp(value, 0, maxHappinessLevel) ;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public Mood Mood
    {
        get => mood;
        set => mood = value;
    }
}