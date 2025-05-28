using UnityEngine;

public class IdleState : State
{
    public override void InitializeTransitions(PlayerController controller)
    {
        _transitions.Add(PlayerAction.Walk, controller.WalkState);
        _transitions.Add(PlayerAction.Jump, controller.RiseState); 
        _transitions.Add(PlayerAction.Dash, controller.DashState);
    }

    public override void EnterState(PlayerController controller)
    {
        Debug.Log("Entering Idle State");
    }

    public override void StateUpdate(PlayerController controller) { }

    public override void ExitState(PlayerController controller)
    {
        Debug.Log("Exiting Idle State");
    }  
}
