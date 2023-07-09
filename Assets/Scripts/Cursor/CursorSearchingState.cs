using UnityEngine;

public class CursorSearchingState : CursorBaseState
{

    public override void EnterState(CursorStateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CursorStateManager manager, App app)
    {
        try
        {
            Explorer explorer = app.GetComponent<Explorer>();
            explorer.StartSearch();
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
        }
        catch 
        {
            Debug.Log("Not Explorer");
        }

    }

    public override void UpdateState(CursorStateManager manager)
    {

    }

    public override void ExitState(CursorStateManager manager)
    {

    }
}
