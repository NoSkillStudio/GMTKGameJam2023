using System.Collections.Generic;
using UnityEngine;

public class CursorOpeningState : CursorBaseState
{
    private App[] apps;
    private App target;
    private float speed = 5f;

    public override void EnterState(CursorStateManager manager)
    {
        apps = Object.FindObjectsOfType<App>();
        target = Utilities.Choice<App>(apps);
    }

    public override void UpdateState(CursorStateManager manager)
    {
        manager.SetPos(Vector2.MoveTowards(
            manager.cursor.transform.position,
            target.transform.position,
            speed * Time.deltaTime
        ));

        if (Vector3.Distance(manager.cursorTransform.position, target.transform.position) <= 0.25f)
        {
            target.Open();
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
        }
    }

    public override void ExitState(CursorStateManager manager) {}
}
