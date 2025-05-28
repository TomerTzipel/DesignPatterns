
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAction
{
    Walk,Jump,Dash,Stop
}
public abstract class State
{
    protected Dictionary<PlayerAction, State> _transitions;

    public State()
    {
        _transitions = new Dictionary<PlayerAction, State>();
    }

    public abstract void InitializeTransitions(PlayerController controller);
    public abstract void EnterState(PlayerController controller);
    public abstract void StateUpdate(PlayerController controller);
    public abstract void ExitState(PlayerController controller);
    public State CheckTransitions(PlayerAction action)
    {
        if(_transitions.ContainsKey(action)) return _transitions[action];
        return null;
    }

    protected virtual IEnumerator StateDuration(PlayerController controller,float duration)
    {
        yield return new WaitForSeconds(duration);
    }

}
