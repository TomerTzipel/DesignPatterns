using UnityEngine;

public class WalkState : State
{
    public override void InitializeTransitions(PlayerController controller)
    {
        _transitions.Add(PlayerAction.Stop, controller.IdleState);
        _transitions.Add(PlayerAction.Jump, controller.RiseState);
        _transitions.Add(PlayerAction.Dash, controller.DashState);
    }

    public override void EnterState(PlayerController controller)
    { 
        Debug.Log("Entering Walk State"); 
    }


    public override void StateUpdate(PlayerController controller)
    {
        controller.transform.Translate(Time.deltaTime * controller.Settings.MoveSpeed * controller.MoveDirection * Vector2.right);
    }

    public override void ExitState(PlayerController controller)
    { 
        Debug.Log("Exiting Walk State"); 
    }
}
