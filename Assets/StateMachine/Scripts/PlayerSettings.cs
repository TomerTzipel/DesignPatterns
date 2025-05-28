using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float DashSpeed { get; private set; }
    [field:SerializeField] public float DashDuration {  get; private set; }
    [field: SerializeField] public float JumpSpeed { get; private set; }
    [field: SerializeField] public float JumpDuration { get; private set; }
}
