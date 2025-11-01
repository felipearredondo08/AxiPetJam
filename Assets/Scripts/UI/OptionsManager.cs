using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Button musicButton;
    public Button soundButton;
    private SoundManager _soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _soundManager = FindFirstObjectByType<SoundManager>();
        musicButton.onClick.AddListener(SwitchMusic);
        soundButton.onClick.AddListener(SwitchSound);
    }

    // Update is called once per frame

    public void SwitchMusic()
    {
        _soundManager.SwitchActiveMusic("musica acuario");
    }

    public void SwitchSound()
    {
        _soundManager.SwitchActiveSounds();
    }
}
