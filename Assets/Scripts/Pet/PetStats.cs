using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Stats/Pet", fileName = "PetStats")]
public class PetStats : ScriptableObject
{
    public int hungerLevel;
    public int sleepLevel;
    public int happinessLevel;
    public string name;
    public Mood mood;
    
    public UnityEvent statsEvent;

    private void OnEnable()
    {
        statsEvent ??= new UnityEvent();
    }
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