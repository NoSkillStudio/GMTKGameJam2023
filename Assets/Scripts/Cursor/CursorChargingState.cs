using UnityEngine;

public class CursorChargingState : CursorBaseState
{
    private Charge charge;
    public override void EnterState(CursorStateManager manager)
    {
        charge = FindObjectOfType<Charge>();
    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CursorStateManager manager)
    {
        if (!charge.isCharging)
        {
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorRunningState>());
        }
    }

    public override void ExitState(CursorStateManager manager)
    {

    }
}
