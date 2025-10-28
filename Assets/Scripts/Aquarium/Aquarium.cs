using UnityEngine;

public class Aquarium : MonoBehaviour
{
    private Sprite background;
    private AquariumStats stats;

    public void CleanAquarium()
    {
        stats.cleanlinessLevel = 100;
    }

    public void DirtyAquarium()
    {
        if (stats.cleanlinessLevel == 0)
        {
            return;
        }
        else if (stats.cleanlinessLevel >= 5)
        {
            stats.cleanlinessLevel -= 5;
        }
    }
}