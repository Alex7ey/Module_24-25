using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.TextCore.Text;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private DestinationMarker _destinationMarker;
    [SerializeField] private ManagerControllers _managerControllers;// название по лучше бы придумать
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private MedkitSpawner _medkitSpawner;

    private void Awake()
    {
        Character character = Instantiate(_characterPrefab, _spawnPoint.position, _spawnPoint.rotation);
        ViewCharacter viewCharacter = character.GetComponent<ViewCharacter>();

        AudioHandler audioHandler = new(_audioMixer, _audioSource);

        InitializeComponents(viewCharacter, character);
    }

    private void InitializeComponents(ViewCharacter viewCharacter, Character character)
    {
        viewCharacter.Initialize(character);
        _healthBar.Initialize(character);
        _destinationMarker.Initialize(character);
        _virtualCamera.Follow = character.transform;
        _medkitSpawner.Initialize(character.transform);
        _managerControllers.Initialize(new PointClickMovementController(character), new NavMeshAgentJumpController(character, character.GetComponent<NavMeshAgent>()));
    }
}
