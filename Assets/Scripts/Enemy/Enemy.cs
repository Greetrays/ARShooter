using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyHealth))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _diedEffect;
    [SerializeField] private int _reward;
    [SerializeField] private int _damage;

    private Player _target;

    public Player Target => _target;

    private EnemyHealth _enemyHealth;

    public int Damage => _damage;

    public event UnityAction<int, Enemy> Died;

    private void OnEnable()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyHealth.Dying += OnDying;
    }
    
    private void OnDisable()
    {
        _enemyHealth.Dying -= OnDying;
    }

    public void TargetInit(Player player)
    {
        _target = player;
    }

    private void OnDying()
    {
        Instantiate(_diedEffect, transform.position, Quaternion.identity);
        Died?.Invoke(_reward, this);
        Destroy(gameObject);
    }
}
