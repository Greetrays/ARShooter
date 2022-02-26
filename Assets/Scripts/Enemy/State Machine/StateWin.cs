using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWin : State
{
    private void OnEnable()
    {
        EnemyAnimator.Play(SlimeAnimator.State.Taunt);
    }
}
