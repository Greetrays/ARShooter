using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction Died;
    public event UnityAction<int> ChangedHealth;

    public int MaxHealth => _maxHealth;

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
        ChangedHealth?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
            Debug.Log("Вы проиграли!");
        }
    }
}
