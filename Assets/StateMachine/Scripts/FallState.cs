using UnityEngine;
using System.Collections;

public class FallState : State
{
    public override void InitializeTransitions(PlayerController controller)
    { }


    public override void EnterState(PlayerController controller)
    {
        Debug.Log("Entering Fall State");
        controller.StartCoroutine(StateDuration(controller, controller.Settings.JumpDuration / 2f));
    }

    public override void StateUpdate(PlayerController controller)
    {
        controller.transform.Translate(Time.deltaTime * controller.Settings.JumpSpeed * Vector2.down);
    }

    public override void ExitState(PlayerController controller)
    {
        Debug.Log("Exiting Fall State");
    }
    protected override IEnumerator StateDuration(PlayerController controller, float duration)
    {
        yield return base.StateDuration(controller, duration);

        if(controller.MoveDirection == 0) controller.ChangeState(controller.IdleState);
        else controller.ChangeState(controller.WalkState);

    }
}
