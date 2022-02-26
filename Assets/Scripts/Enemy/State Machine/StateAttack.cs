using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateAttack : State
{
    [SerializeField] float _delay;

    private float _elepsedTime;

    private void OnEnable()
    {
        EnemyAnimator.Play(SlimeAnimator.State.Attack);
    }

    private void Update()
    {
        int damage = GetComponent<Enemy>().Damage;
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            Target.TakeDamage(damage);
            _elepsedTime = 0;
        }
    }
}
