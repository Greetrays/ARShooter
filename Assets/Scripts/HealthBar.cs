using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _healthBar;
    
    private int _maxHealth;

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangeHealth;
    }

    private void Start()
    {
        _maxHealth = _player.MaxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _maxHealth;
    }

    private void OnChangeHealth(int health)
    {
        _healthBar.value = health;
    }
}
