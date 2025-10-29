using UnityEngine;

[CreateAssetMenu(fileName = "ActionSO", menuName = "Action")]
public class Action : ScriptableObject
{
    [SerializeField] private Stat stat;
    [SerializeField] private int statPoints;

    public Stat Stat => stat;

    public int StatPoints => statPoints;
}

public enum Stat
{
    HungerLevel, 
    SleepLevel,
    HappinessLevel,
}