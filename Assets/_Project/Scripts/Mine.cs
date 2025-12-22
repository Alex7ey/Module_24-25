using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _timeBeforeExplosion;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioClip _explosionSound;

<<<<<<< HEAD
=======
//<<<<<<< Updated upstream:Assets/_Project/Scripts/Mine.cs
>>>>>>> parent of e325804 (123)
    private RadiusDetectionController _radiusDetectionController;
    private ExplosionController _explosionController;

    public void Detected()
    {
        _explosionController.Explode();
    }

    private void Awake()
    {
        InitializeControllers();
    }

    private void InitializeControllers()
    {
        _radiusDetectionController = new(this, _detectionRadius, transform);
        _explosionController = new(_timeBeforeExplosion, transform, _detectionRadius, _explosionEffect , _damage, this);

        _radiusDetectionController.Enable();
    }

<<<<<<< HEAD
    private void Update()
    {
        _radiusDetectionController.Update(Time.deltaTime);
    }
=======
//    private void Update()
//    {
//        _radiusDetectionController.Update(Time.deltaTime);
//=======
    //private Explosion _explosion;

//    private void Awake()
//    {
//        _explosionController = new(_timeBeforeExplosion, transform, _detectionRadius, _explosionEffect, _damage, this, _explosionSound);
////>>>>>>> Stashed changes:Assets/_Project/Scripts/Mine/Mine.cs
//    }
>>>>>>> parent of e325804 (123)

    private void OnDrawGizmos()
    {
        ShowRadiusDetection();
    }

    private void ShowRadiusDetection()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _detectionRadius);
    }
<<<<<<< HEAD
=======

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable _))
        {
            _explosionController.Explode();
        }
    }
>>>>>>> parent of e325804 (123)
}
