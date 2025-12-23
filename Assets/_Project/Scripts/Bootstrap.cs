using UnityEngine;
using UnityEngine.Audio;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private DestinationMarker _destinationMarker;
    [SerializeField] private GameObject _prefabCharacter;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _audioSoundSource;

    private void Awake()
    {
        AudioHandler audioHandler = new(_audioMixer, _audioSoundSource);

    }
}

