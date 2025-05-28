using UnityEngine;

using System.Collections;
public class DashState : State
{
    public override void InitializeTransitions(PlayerController controller)
    { }

    public override void EnterState(PlayerController controller)
    {
        Debug.Log("Entering Dash State");
        controller.StartCoroutine(StateDuration(controller, controller.Settings.DashDuration));
    }

    public override void StateUpdate(PlayerController controller)
    {
        controller.transform.Translate(Time.deltaTime * controller.Settings.DashSpeed * controller.IdleDirection * Vector2.right);
    }

    public override void ExitState(PlayerController controller)
    { 
        Debug.Log("Exiting Dash State"); 
    }

    protected override IEnumerator StateDuration(PlayerController controller, float duration)
    {
        yield return base.StateDuration(controller, duration);

        if (controller.MoveDirection == 0) controller.ChangeState(controller.IdleState);
        else controller.ChangeState(controller.WalkState);
    }

}
