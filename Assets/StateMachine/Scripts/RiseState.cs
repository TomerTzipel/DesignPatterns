using System.Collections;
using UnityEngine;

public class RiseState : State
{
    public override void InitializeTransitions(PlayerController controller)
    { }
    
    public override void EnterState(PlayerController controller)
    {
        Debug.Log("Entering Rise State");
        controller.StartCoroutine(StateDuration(controller, controller.Settings.JumpDuration / 2f));
    }

    public override void StateUpdate(PlayerController controller)
    {
        controller.transform.Translate(Time.deltaTime * controller.Settings.JumpSpeed * Vector2.up);
    }

    public override void ExitState(PlayerController controller)
    {
        Debug.Log("Exiting Rise State");
    }

    protected override IEnumerator StateDuration(PlayerController controller, float duration)
    {
        yield return base.StateDuration(controller, duration);
        controller.ChangeState(controller.FallState);
    }
}
