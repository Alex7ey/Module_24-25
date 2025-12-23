using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _timeBeforeExplosion;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioClip _explosionSound;

    private Explosion _explosion;

    public void Detected()
    {
        _explosion.Explode();
    }

    private void Awake()
    {
        InitializeControllers();
    }

    private void InitializeControllers()
    {
        _explosion = new(_timeBeforeExplosion, transform, _detectionRadius, _explosionEffect, _damage, this, _explosionSound);
    }

    private void OnDrawGizmos()
    {
        ShowRadiusDetection();
    }

    private void ShowRadiusDetection()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _detectionRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable _))
        {
            _explosion.Explode();
        }
    }
}
