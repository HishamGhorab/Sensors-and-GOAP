using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : Action_Base
{
    List<System.Type> SupportedGoals = new List<System.Type>(new System.Type[] {typeof(Goal_Attack)});
    private Goal_Attack AttackGoal;

    private int attackCounter = 0;
    private float meleeAttackCooldown = 3;
    private float meleeAttackTime;

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

        AttackGoal = (Goal_Attack) LinkedGoal;
        meleeAttackTime = Time.time + meleeAttackCooldown;

        Debug.Log("entered action");
    }

    public override void OnDeactivated()
    {
        base.OnDeactivated();

        attackCounter = 0;
    }

    public override void OnTick()
    {
        if (Time.time >= meleeAttackTime)
        {
            meleeAttackTime = Time.time + meleeAttackCooldown;
            
            //if looking at player
            
            
            //stop moving
            //freeze player
            //attack
            
            //leave

            Debug.Log("Attack happened " + attackCounter);
            attackCounter++;
        }
    }
}