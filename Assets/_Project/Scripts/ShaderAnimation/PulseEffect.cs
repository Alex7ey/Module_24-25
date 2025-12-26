using System.Collections;
using UnityEngine;

public class PulseEffect
{
    private readonly Material _material;
    private readonly MonoBehaviour _coroutineRunner;

    private const string ShaderColorKey = "_ColorValue";
    private const string ShaderScaleKey = "_ScaleFactor";

    public PulseEffect(Material material, MonoBehaviour coroutineRunner)
    {
        _material = material;
        _coroutineRunner = coroutineRunner;
    }

    public Coroutine StartPulseAnimation(float minValue = 1, float maxValue = 2, float animationSpeed = 2)
    {
        return _coroutineRunner.StartCoroutine(ProcessAnimation(minValue, maxValue, animationSpeed));
    }

    private IEnumerator ProcessAnimation(float minValue, float maxValue, float animationSpeed)
    {
        float elapsedTime = 0;

        while (true)
        {
            elapsedTime += Time.deltaTime * animationSpeed;

            float percent = Mathf.PingPong(elapsedTime, 1);
            float value = Mathf.Lerp(minValue, maxValue, percent);

            ApplyMaterialValues(value, percent);

            yield return null;
        }
    }

    private void ApplyMaterialValues(float value, float percent)
    {
        _material.SetFloat(ShaderScaleKey, value);
        _material.SetFloat(ShaderColorKey, percent);
    }
}
