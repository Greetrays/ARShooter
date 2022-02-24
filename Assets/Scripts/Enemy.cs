using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _diedEffect;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Die()
    {
        Instantiate(_diedEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            ChangeHealth(bullet.Damage);
        }
    }

    private void ChangeHealth(int healthChangeValue)
    {
        _currentHealth -= healthChangeValue;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
