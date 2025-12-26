using UnityEngine;

public class MineView : MonoBehaviour
{
    private Mine _mine;
    private Material _material;
    private Coroutine _coroutine;
    private PulseEffect _pulseEffect;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _mine = GetComponent<Mine>();
        _pulseEffect = new(_material, this);
    }

    private void Update()
    {
        if (_mine.IsExploding && _coroutine == null)
            _coroutine = _pulseEffect.StartPulseAnimation();
    }
}


