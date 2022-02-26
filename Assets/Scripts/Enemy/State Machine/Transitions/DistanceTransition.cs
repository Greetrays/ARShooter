using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, Target.transform.position) < 2)
        {
            NeedTransit = true;
        }
    }
}
