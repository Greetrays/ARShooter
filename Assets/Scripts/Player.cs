using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 100;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Debug.Log("Вы проиграли!");
        }
    }
}
