using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    [SerializeField] private float _speed;
    private void OnEnable()
    {
        EnemyAnimator.Play(SlimeAnimator.State.Walk);
    }
    private void Update()
    {
        Vector3 newDistance = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, _speed);
        gameObject.transform.position = newDistance;
    }
}
