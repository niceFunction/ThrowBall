using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionEffect;
    [SerializeField, Range(1, 8)]
    private float _destroyParticleTimer;

    private void OnDestroy()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(_explosionEffect, _destroyParticleTimer);
    }
}
