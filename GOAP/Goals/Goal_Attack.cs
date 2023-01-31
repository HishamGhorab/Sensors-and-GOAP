using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Attack : Goal_Base
{
    [SerializeField] int AttackPriority = 70;
    int currentPriority = 0;
    
    public override int CalculatePriority()
    {
        return currentPriority;
    }

    public override bool CanRun()
    {
        return true;
    }

    public override void OnTickGoal()
    {
        currentPriority = 0;

        // no targets
        if (Sensors.ActiveTargets == null || Sensors.ActiveTargets.Count == 0)
            return;
        
        foreach (var candidate in Sensors.ActiveTargets.Values)
        {
            if (Vector3.Distance(candidate.RawPosition, linkedAi.transform.position)
                <= linkedAi.ProximityDetectionRange)
            {
                currentPriority = AttackPriority;
            }
        }
    }
}
