using UnityEngine;

public class MedKitView : MonoBehaviour
{
    private Material _material;
    private PulseEffect _pulseEffect;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;

        _pulseEffect = new(_material, this);
        _pulseEffect.StartPulseAnimation();
    }
}
