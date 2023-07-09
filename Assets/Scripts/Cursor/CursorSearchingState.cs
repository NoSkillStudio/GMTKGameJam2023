using UnityEngine;

public class CursorSearchingState : CursorBaseState
{

    public override void EnterState(CursorStateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CursorStateManager manager, App app)
    {
        Explorer explorer = app.GetComponent<Explorer>();
        explorer.StartSearch();
        manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
    }

    public override void UpdateState(CursorStateManager manager)
    {

    }

    public override void ExitState(CursorStateManager manager)
    {

    }
}
