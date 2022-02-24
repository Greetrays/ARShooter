using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;

    private float CurrentTimeLife;
    public int Damage => _damage;

    private void OnValidate()
    {
        if (_timeLife <= 0)
        {
            _timeLife = 3;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
        CurrentTimeLife += Time.deltaTime;

        if (CurrentTimeLife >= _timeLife)
        {
            CurrentTimeLife = 0;
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
