using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _diedEffect;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _reward;

    private int _currentHealth;

    public event UnityAction<int, Enemy> Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void Die()
    {
        Instantiate(_diedEffect, transform.position, Quaternion.identity);
        Died?.Invoke(_reward, this);
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
