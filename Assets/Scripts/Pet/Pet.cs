using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private PetStats stats;
    private Animator _animator;
    private SoundManager _soundManager;
    [SerializeField] private int lowLevel = 35;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _soundManager = FindFirstObjectByType<SoundManager>();
    }

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
                print("Action: " + action.Stat);
                _soundManager.Play("axi-jugando");
                break;
            case Stat.HungerLevel: //Eating
                Stats.HungerLevel += action.StatPoints;
                print("Action: " + action.Stat);
                //Falta sonido
                //_soundManager.Play("axi-comiendo");
                break;
            case Stat.SleepLevel: //Sleeping
                Stats.SleepLevel += action.StatPoints;
                print("Action: " + action.Stat);
                _soundManager.Play("axi-roncando");
                break;
        }
        Stats.statsEvent.Invoke();
        _animator.SetInteger("ActionState", ((int)action.Stat)); 
    }

    public void StopAction()
    {
        _animator.SetInteger("ActionState", 10);
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
            // Debug.Log((int)stats.Mood);
            print("Mood: " + stats.Mood);
            _soundManager.Play("axi-enojado");
        }
        else if (lowCount == 2)
        {
            stats.Mood = Mood.Sad;
            print("Mood: " + stats.Mood);
            _soundManager.Play("axi-diciendo no");
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
            _soundManager.Play("axi-feliz");
            //Animation State
        }
        _animator.SetInteger("MoodState", (int)stats.Mood); 
    }
}