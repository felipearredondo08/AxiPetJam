using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CareController : MonoBehaviour
{
    public Pet pet;
    public Aquarium aquarium;
    public PlayerStats playerStats;
    
    private bool _isDecreaseStatsReady = true;
    [SerializeField] private float cooldownStatsTimer = 16f;
    private bool _isDecreaseCleanlinessReady = true;
    [SerializeField] private float cooldownDirtyAquaTimer = 32f;
    private bool _isSetMoodReady = true;
    [SerializeField] private float cooldownMoodTimer = 3f;
    private bool _isSetActionReady = true;
    [SerializeField] private float cooldownActionTimer = 1f;

    public Action play;
    public Action eat;
    public Action sleep;

    private void Start()
    {
        pet.SetMood();
    }

    private void Update()
    {
        if (_isDecreaseStatsReady)
        {
            _isDecreaseStatsReady = false;
            Invoke(nameof(WrapDecreaseRandomStat), cooldownStatsTimer);
        }
        else if (_isDecreaseCleanlinessReady)
        {
            _isDecreaseCleanlinessReady = false;
            Invoke(nameof(WrapDecreaseRandomCleanliness), cooldownDirtyAquaTimer);
        }

        if (_isSetMoodReady)
        {
            _isSetMoodReady = false;
            Invoke(nameof(WrapSetMood), cooldownMoodTimer);
        }
    }

    public void Play()
    {
        if (_isSetActionReady)
        {
            StartCoroutine(PlayCoolDown());
        }
    }
    
    public void Eat()
    {
        if (_isSetActionReady)
        {
            StartCoroutine(EatCoolDown());
        }
    }
    
    public void Sleep()
    {
        if (_isSetActionReady)
        {
            StartCoroutine(SleepCoolDown());
        }
    }
    
    public void Clean()
    {
        aquarium.CleanAquarium();
    }

    //Perdon por este machetazo pero no hay tiempo
    public IEnumerator PlayCoolDown()
    {
        _isSetActionReady = false;
        pet.CallToAction(play);
        yield return new WaitForSeconds(cooldownActionTimer);
        _isSetActionReady = true;
    }
    
    //Perdon por este machetazo pero no hay tiempo
    public IEnumerator EatCoolDown()
    {
        _isSetActionReady = false;
        pet.CallToAction(eat);
        yield return new WaitForSeconds(cooldownActionTimer);
        _isSetActionReady = true;
    }
    
    //Perdon por este machetazo pero no hay tiempo
    public IEnumerator SleepCoolDown()
    {
        _isSetActionReady = false;
        pet.CallToAction(sleep);
        yield return new WaitForSeconds(cooldownActionTimer);
        _isSetActionReady = true;
    }

    private void WrapSetMood()
    {
        pet.SetMood();
        _isSetMoodReady = true;
    }

    private void WrapDecreaseRandomCleanliness()
    {
        aquarium.DirtyAquarium();
        _isDecreaseCleanlinessReady = true;
    }

    private void WrapDecreaseRandomStat()
    {
        pet.DecreaseRandomStat();
        _isDecreaseStatsReady = true;
    }
}