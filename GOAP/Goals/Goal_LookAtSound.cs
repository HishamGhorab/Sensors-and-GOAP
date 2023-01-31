using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_LookAtSound : Goal_Base
{
    [SerializeField] int LookPriority = 60;
    
    [SerializeField] float MinAwarenessToLook = 1f;
    [SerializeField] float MinAwarenessToStopLook = 1f;
    
    //[SerializeField] float AwarenessToStopChase = 1f;

    DetectableTarget CurrentTarget;
    int CurrentPriority = 0;

    public Vector3 LookPosition => CurrentTarget != null ? CurrentTarget.transform.position : transform.position;

    public override void OnTickGoal()
    {
        CurrentPriority = 0;

        // no targets
        if (Sensors.ActiveTargets == null || Sensors.ActiveTargets.Count == 0)
            return;

        if (CurrentTarget != null)
        {
            // check if the current is still sensed
            foreach (var candidate in Sensors.ActiveTargets.Values)
            {
                if (candidate.Detectable == CurrentTarget)
                {
                    CurrentPriority = candidate.Awareness < MinAwarenessToLook ? 0 : LookPriority;
                    return;
                }
            }

            // clear our current target
            CurrentTarget = null;
        }

        // acquire a new target if possible
        foreach (var candidate in Sensors.ActiveTargets.Values)
        {
            // found a target to acquire
            if (candidate.Awareness >= MinAwarenessToLook)
            {
                CurrentTarget = candidate.Detectable;
                CurrentPriority = LookPriority;
                return;
            }
        }
    }
    
    public override void OnGoalDeactivated()
    {
        base.OnGoalDeactivated();
        
        CurrentTarget = null;
    }

    public override int CalculatePriority()
    {
        return CurrentPriority;
    }

    public override bool CanRun()
    {
        // no targets
        if (Sensors.ActiveTargets == null || Sensors.ActiveTargets.Count == 0)
            return false;

        // check if we have anything we are aware of
        foreach(var candidate in Sensors.ActiveTargets.Values)
        {
            if (candidate.Awareness >= 1)
            {
                return true;
            }
        }

        return false;
    }
}
