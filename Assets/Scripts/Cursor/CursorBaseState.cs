using UnityEngine;

public abstract class CursorBaseState : ScriptableObject
{
    public AudioSource clickSound;
    public abstract void EnterState(CursorStateManager manager);
    public abstract void EnterState(CursorStateManager manager, App transform);
    public abstract void UpdateState(CursorStateManager manager);
    public abstract void ExitState(CursorStateManager manager);
}
