using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private State _currentState;
    private RocketInputs _input;
    [field: SerializeField] public PlayerSettings Settings { get; private set; }

    public IdleState IdleState { get; private set; } = new IdleState();
    public WalkState WalkState { get; private set; } = new WalkState(); 
    public RiseState RiseState { get; private set; } = new RiseState();
    public FallState FallState { get; private set; } = new FallState();
    public DashState DashState { get; private set; } = new DashState();

    public float IdleDirection { get; private set; } = 1f;
    public float MoveDirection { get; private set; } = 0f;

    void Awake()
    {
        _input = new RocketInputs();
        IdleState.InitializeTransitions(this);
        WalkState.InitializeTransitions(this);
        RiseState.InitializeTransitions(this);
        FallState.InitializeTransitions(this);
        DashState.InitializeTransitions(this);

        _currentState = IdleState;
        _currentState.EnterState(this);
    }
    private void OnEnable()
    {
        _input.Player.Move.Enable();
        _input.Player.Jump.Enable();
        _input.Player.Dash.Enable();

        _input.Player.Move.performed += OnMoveInput;
        _input.Player.Move.canceled += OnMoveInput;
        _input.Player.Jump.performed += OnJumpInput;
        _input.Player.Dash.performed += OnDashInput;
    }
    private void OnDisable()
    {
        _input.Player.Move.performed -= OnMoveInput;
        _input.Player.Move.canceled -= OnMoveInput;
        _input.Player.Jump.performed -= OnJumpInput;
        _input.Player.Dash.performed -= OnDashInput;
        _input.Player.Move.Disable();
        _input.Player.Jump.Disable();
        _input.Player.Dash.Disable();
    }

    void Update()
    {
        _currentState.StateUpdate(this);
    }

    public void ChangeState(State newState)
    {
        _currentState.ExitState(this);
        _currentState = newState;
        _currentState.EnterState(this);
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        MoveDirection = context.action.ReadValue<float>();
        State result;

        if (MoveDirection != 0)
        {
            IdleDirection = MoveDirection;
            result = _currentState.CheckTransitions(PlayerAction.Walk);
            if (result != null) ChangeState(result);
        }
        else
        {
            result = _currentState.CheckTransitions(PlayerAction.Stop);
            if (result != null) ChangeState(result);
        }      
    }
    private void OnJumpInput(InputAction.CallbackContext context)
    {
        State result = _currentState.CheckTransitions(PlayerAction.Jump);
        if(result != null) ChangeState(result);
    }
    private void OnDashInput(InputAction.CallbackContext context)
    {
        State result = _currentState.CheckTransitions(PlayerAction.Dash);
        if (result != null) ChangeState(result);
    }
}
