using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chase : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] { typeof(Goal_Chase) });

    Goal_Chase ChaseGoal;

    [SerializeField] private Animator anim;

    private bool canTakeStep = false;

    private float stepTime = 1;
    float newStepTime;

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
        
        // cache the chase goal
        ChaseGoal = (Goal_Chase)LinkedGoal;

        Agent.MoveTo(ChaseGoal.MoveTarget);
        
        anim.SetBool("Walking", true);

        canTakeStep = true;

        newStepTime = Time.time + stepTime;
    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();
        
        anim.SetBool("Walking", false);

        ChaseGoal = null;
    }

    public override void OnTick()
    {
        //Debug.Log(ChaseGoal.MoveTarget);
        Agent.MoveTo(ChaseGoal.MoveTarget);

        /*if (Time.time >= newStepTime)
        {
            canTakeStep = true;
            newStepTime = Time.time + stepTime;
        }
        
        if (canTakeStep)
        {
            Debug.Log("yes take step " + Time.time);
            
            Agent.MoveStep(ChaseGoal.MoveTarget, 0.1f);
            canTakeStep = false;
        }*/
    }    
}
