using UnityEngine;

public abstract class CursorBaseState : ScriptableObject
{
    public abstract void EnterState(CursorStateManager manager);
    public abstract void UpdateState(CursorStateManager manager);
    public abstract void ExitState(CursorStateManager manager);
}
