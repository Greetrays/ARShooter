using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    public override void Init(Player target)
    {
        base.Init(target);
        Target.Died += OnDied;
    }

    private void OnDied()
    {
        NeedTransit = true;
        Target.Died -= OnDied;
    }
}
