using UnityEngine;

public class CursorIdleState : CursorBaseState
{
    private float timer = 2f;
    private float time = 0f;

    public override void EnterState(CursorStateManager manager) {}

    public override void UpdateState(CursorStateManager manager)
    {
        time += Time.deltaTime;
        if (time >= timer)
        {
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorRunningState>());
        }
    }

    public override void ExitState(CursorStateManager manager)
    {
        time = 0f;
    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        throw new System.NotImplementedException();
    }
}
