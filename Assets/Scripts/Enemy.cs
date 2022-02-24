using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _diedEffect;
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Die()
    {
        Instantiate(_diedEffect, transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
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
