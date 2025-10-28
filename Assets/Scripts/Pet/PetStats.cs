using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Pet", fileName = "PetStats")]
public class PetStats : ScriptableObject
{
    public int _hungerLevel;
    public int _sleepLevel;
    public int _happinessLevel;
    public string _name;
    public Mood _mood;
    
}

public enum Mood
{
    Happy, //feli
    Sad, //triste ó llorando
    Tired, //cansado
    Angry, //enojado
    Bored, //aburrido
    Asleep, //dormirdo
    Hungry //hambre
}