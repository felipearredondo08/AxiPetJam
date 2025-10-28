using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public Slider foodLevelSlider;
    public Slider sleepLevelSlider;
    public Slider happinessLevelSlider;
    public Slider cleanlinessLevelSlider;
    public PetStats petStats;
    public AquariumStats aquariumStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        petStats.statsEvent.AddListener(UpdateFoodLevel);
        petStats.statsEvent.AddListener(UpdateSleepLevel);
        petStats.statsEvent.AddListener(UpdateHappinessLevel);
        petStats.statsEvent.Invoke();
        
        aquariumStats.aquariumEvent.AddListener(UpdateCleanlinessLevel);
        aquariumStats.aquariumEvent.Invoke();
    }

    private void UpdateFoodLevel()
    {
        foodLevelSlider.value = petStats.hungerLevel;
    }

    private void UpdateSleepLevel()
    {
        sleepLevelSlider.value = petStats.sleepLevel;
    }

    private void UpdateHappinessLevel()
    {
        happinessLevelSlider.value = petStats.happinessLevel;
    }

    private void UpdateCleanlinessLevel()
    {
        cleanlinessLevelSlider.value = aquariumStats.cleanlinessLevel;
    }
    
    [ContextMenu("ChangeCleanlinessLevel")]
    public void ChangeCleanlinessLevel()
    {
        Debug.Log("Cambiando el nivel de limpieza en el juego...");
        aquariumStats.cleanlinessLevel = 50; 
        aquariumStats.aquariumEvent.Invoke();
    }
    
}
