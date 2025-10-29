using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public Slider foodLevelSlider;
    public Slider sleepLevelSlider;
    public Slider happinessLevelSlider;
    public Slider cleanlinessLevelSlider;
    public Pet pet;
    public Aquarium aquarium;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pet.Stats.statsEvent.AddListener(UpdateFoodLevel);
        pet.Stats.statsEvent.AddListener(UpdateSleepLevel);
        pet.Stats.statsEvent.AddListener(UpdateHappinessLevel);
        pet.Stats.statsEvent.Invoke();
        
        aquarium.Stats.aquariumEvent.AddListener(UpdateCleanlinessLevel);
        aquarium.Stats.aquariumEvent.Invoke();
    }

    private void UpdateFoodLevel()
    {
        foodLevelSlider.value = pet.Stats.HungerLevel;
    }

    private void UpdateSleepLevel()
    {
        sleepLevelSlider.value = pet.Stats.SleepLevel;
    }

    private void UpdateHappinessLevel()
    {
        happinessLevelSlider.value = pet.Stats.HappinessLevel;
    }

    private void UpdateCleanlinessLevel()
    {
        cleanlinessLevelSlider.value = aquarium.Stats.CleanlinessLevel;
    }
}
