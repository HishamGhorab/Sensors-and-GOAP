using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_LookAtSound : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_LookAtSound) });
    Goal_LookAtSound LookAtSoundGoal;
    
    public override List<System.Type> GetSupportedGoals()
    {
        return SupportedGoals;
    }

    public override float GetCost()
    {
        return 0f;
    }

    public override void OnActivated(Goal_Base _linkedGoal)
    {
        base.OnActivated(_linkedGoal);
        
        LookAtSoundGoal = (Goal_LookAtSound)LinkedGoal;
        
        

        
    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();

        LookAtSoundGoal = null;
    }
    
    public override void OnTick()
    {
        Debug.Log("Rotate please");
        Agent.RotateToDirection(LookAtSoundGoal.LookPosition);
    }   
}
