using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundController : MonoBehaviour
{
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _musicButton;

    [SerializeField] private Color _play;
    [SerializeField] private Color _stop;

    public void ToggleSound(string key)
    {
        AudioHandler.ToggleVolume(key);
        CheckVolume();
    }

    private void IsVolumeOn(string key, Button button)
    {
        if (AudioHandler.IsSoundOn(key))
        {
            SetButtonColor(_play, button);
            return;
        }
        SetButtonColor(_stop, button);
    }

    private void SetButtonColor(Color color, Button button) => button.image.color = color;

    private void CheckVolume()
    {
        IsVolumeOn("Music", _musicButton);
        IsVolumeOn("Sound", _soundButton);
    }
}
