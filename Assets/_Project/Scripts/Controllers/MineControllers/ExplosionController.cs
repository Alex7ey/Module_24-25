using System.Collections;
<<<<<<< HEAD
=======
//<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/MineControllers/ExplosionController.cs
//=======
//using Unity.VisualScripting;
//>>>>>>> Stashed changes:Assets/_Project/Scripts/Mine/Explosion.cs
>>>>>>> parent of e325804 (123)
using UnityEngine;

public class ExplosionController
{
    private readonly int _damage;
<<<<<<< HEAD
=======
//<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/MineControllers/ExplosionController.cs
>>>>>>> parent of e325804 (123)
    private readonly float _radiusExplode;
    private readonly float _timeBeforeExplosion;

    private readonly Transform _transform;
    private readonly ParticleSystem _particleEffect;
    private readonly MonoBehaviour _coroutineRunner;

    private bool _isExploding;
<<<<<<< HEAD
=======
//=======
    //private readonly MonoBehaviour _coroutineRunner;

//>>>>>>> Stashed changes:Assets/_Project/Scripts/Mine/Explosion.cs
>>>>>>> parent of e325804 (123)
    private bool _isDestroyed;
    private AudioClip _explosionAudioClip;

<<<<<<< HEAD
    public ExplosionController(float timeBeforeExplosion, Transform transform, float radiusExplode, ParticleSystem particleEffect, int damage, MonoBehaviour coroutineRunner)
=======
    ////<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/MineControllers/ExplosionController.cs
    //    public ExplosionController(float timeBeforeExplosion, Transform transform, float radiusExplode, ParticleSystem particleEffect, int damage, MonoBehaviour coroutineRunner)
    //=======
    public ExplosionController(float timeBeforeExplosion, Transform transform, float radiusExplode, ParticleSystem particleEffect, int damage, MonoBehaviour coroutineRunner, AudioClip explosionAudioClip)
//>>>>>>> Stashed changes:Assets/_Project/Scripts/Mine/Explosion.cs
>>>>>>> parent of e325804 (123)
    {
        _timeBeforeExplosion = timeBeforeExplosion;
        _transform = transform;
        _radiusExplode = radiusExplode;
        _particleEffect = particleEffect;
        _damage = damage;
        _coroutineRunner = coroutineRunner;
<<<<<<< HEAD
=======
//<<<<<<< Updated upstream:Assets/_Project/Scripts/Controllers/MineControllers/ExplosionController.cs
>>>>>>> parent of e325804 (123)
    }

    public void Explode() => _coroutineRunner.StartCoroutine(ProcessExplosionCountdown());

    private IEnumerator ProcessExplosionCountdown()
    {
        if (_isExploding == false && _isDestroyed == false)
        {
            _isExploding = true;
            yield return new WaitForSeconds(_timeBeforeExplosion);

            ExecuteExplosion();
            _isDestroyed = true;

            yield break;
        }
<<<<<<< HEAD
=======
////=======
//        _explosionAudioClip = explosionAudioClip;
    }

    public void Explode()
    {
        if (_isDestroyed)
            return;

        _coroutineRunner.StartCoroutine(ProcessExplosionCountdown());
    } 

    //private IEnumerator ProcessExplosionCountdown()
    //{
    //    yield return new WaitForSeconds(_timeBeforeExplosion);

    //    ExecuteExplosion();
    //    _isDestroyed = true;

    //    yield break;
    //}

    private void ExecuteExplosion()
    {
        PlayExplossionEffect();
        PlayExplosionSound();
        DealDamage();
        DisableObject();
//>>>>>>> Stashed changes:Assets/_Project/Scripts/Mine/Explosion.cs
>>>>>>> parent of e325804 (123)
    }

    private void PlayExplossionEffect()
    {
        _particleEffect.transform.position = _transform.position;
        _particleEffect.Play();
    }

    private void PlayExplosionSound() => AudioHandler.PlaySound(_explosionAudioClip);

    private void DisableObject() => _transform.gameObject.SetActive(false);

    private void DealDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radiusExplode);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}
