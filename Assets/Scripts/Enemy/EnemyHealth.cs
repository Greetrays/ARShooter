using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction Dying;

    private void Start()
    {
        _currentHealth = _maxHealth;
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
            Dying?.Invoke();
        }
    }
}
