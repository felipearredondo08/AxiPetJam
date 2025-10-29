using UnityEngine;

public class Aquarium : MonoBehaviour
{
    [SerializeField] private Sprite background;
    [SerializeField] private AquariumStats stats;

    public AquariumStats Stats => stats;

    [ContextMenu("CleanAquarium")]
    public void CleanAquarium()
    {
        stats.CleanlinessLevel = 100;
        stats.aquariumEvent.Invoke();
    }

    [ContextMenu("DirtyAquarium")]
    public void DirtyAquarium()
    {
        if (stats.CleanlinessLevel >= 10)
        {
            stats.CleanlinessLevel -= 10;
            stats.aquariumEvent.Invoke();
        }
    }
}