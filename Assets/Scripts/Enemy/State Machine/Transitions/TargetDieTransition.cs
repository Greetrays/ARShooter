using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
   /* private void Update()
    {
        Debug.Log(Target);
        if (Target == null)
        {
            NeedTransit = true;
            Debug.Log(1);
        }
    }*/
    public override void Init(Player target)
    {
        base.Init(target);
        Target.Died += OnDied;
    }

    private void OnDied()
    {
        NeedTransit = true;
    }
}
