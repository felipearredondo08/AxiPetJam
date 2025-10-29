using System;
using System.Threading.Tasks;
using UnityEngine;

public class CareController : MonoBehaviour
{
    public Pet pet;
    public Aquarium aquarium;
    public PlayerStats playerStats;
    
    private bool _isDecreaseStatsReady = true;
    [SerializeField] private float cooldownStatsTimer = 2f;
    private bool _isDecreaseCleanlinessReady = true;
    [SerializeField] private float cooldownDirtyAquaTimer = 4f;
    private bool _isSetMoodReady = true;
    [SerializeField] private float cooldownMoodTimer = 3f;
    [SerializeField] private float cooldownActionTimer = 10f;

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

    [ContextMenu("Play")]
    public void Play()
    {
        pet.CallToAction(play);
    }
    
    [ContextMenu("Eat")]
    public void Eat()
    {
        pet.CallToAction(eat);
    }
    
    [ContextMenu("Sleep")]
    public void Sleep()
    {
        pet.CallToAction(sleep);
    }
    
    [ContextMenu("Clean")]
    public void Clean()
    {
        aquarium.CleanAquarium();
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