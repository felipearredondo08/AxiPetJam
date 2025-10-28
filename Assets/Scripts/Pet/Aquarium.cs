using UnityEngine;

public class Aquarium : MonoBehaviour
{
    private Sprite background;
    private int cleanlinessLevel;

    public void CleanAquarium()
    {
        cleanlinessLevel = 100;
    }

    public void DirtyAquarium()
    {
        if (cleanlinessLevel == 0)
        {
            return;
        }
        else if (cleanlinessLevel >= 5)
        {
            cleanlinessLevel -= 5;
        }
    }
}