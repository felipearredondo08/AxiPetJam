//using UnityEditor.Animations;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private PetStats stats;
    private Animator _animator;
    [SerializeField] private int lowLevel = 35;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu("DecreaseRandomStat")]
    public void DecreaseRandomStat()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                Stats.HappinessLevel -= 10;
                break;
            case 1:
                Stats.HungerLevel -= 10;
                break;
            case 2:
                Stats.SleepLevel -= 10;
                break;
        }

        Stats.statsEvent.Invoke();
    }

    public PetStats Stats => stats;

    public void CallToAction(Action action)
    {
        switch (action.Stat)
        {
            case Stat.HappinessLevel: //Playing
                Stats.HappinessLevel += action.StatPoints;
                //Temporal animation
                print("Action: " + action.Stat);
                break;
            case Stat.HungerLevel: //Eating
                Stats.HungerLevel += action.StatPoints;
                //Temporal animation
                print("Action: " + action.Stat);
                break;
            case Stat.SleepLevel: //Sleeping
                Stats.SleepLevel += action.StatPoints;
                //Temporal animation
                print("Action: " + action.Stat);
                break;
        }

        Stats.statsEvent.Invoke();
    }

    public void SetMood()
    {
        int lowCount = 0;

        if (stats.HungerLevel <= lowLevel) lowCount++;
        if (stats.SleepLevel <= lowLevel) lowCount++;
        if (stats.HappinessLevel <= lowLevel) lowCount++;

        if (lowCount == 3)
        {
            stats.Mood = Mood.Angry;
            // _animator.SetInteger("MoodState", ((int)stats.Mood));
            // Debug.Log((int)stats.Mood);
            print("Mood: " + stats.Mood);
        }
        else if (lowCount == 2)
        {
            stats.Mood = Mood.Sad;
            //  _animator.SetInteger("MoodState", ((int)stats.Mood));
            print("Mood: " + stats.Mood);
            //Animation State
        }
        else if (stats.SleepLevel <= lowLevel)
        {
            stats.Mood = Mood.Tired;
            print("Mood: " + stats.Mood);
            //Animation State
        }
        else if (stats.HungerLevel <= lowLevel)
        {
            stats.Mood = Mood.Hungry;
            print("Mood: " + stats.Mood);
            //Animation State
        }
        else if (stats.HappinessLevel <= lowLevel)
        {
            stats.Mood = Mood.Bored;
            print("Mood: " + stats.Mood);
            //Animation State
        }
        else
        {

            stats.Mood = Mood.Happy;
            print("Mood: " + stats.Mood);
            //Animation State
        }
           _animator.SetInteger("MoodState", ((int)stats.Mood)); 
    }
}