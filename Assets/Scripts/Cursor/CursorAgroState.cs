using UnityEngine;

public class CursorAgroState : CursorBaseState
{
    private PlayerCollision player;
    private PlayerController playerController;
    private float speed = 4f;

    public override void EnterState(CursorStateManager manager)
    {
        player = FindObjectOfType<PlayerCollision>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public override void UpdateState(CursorStateManager manager)
    {
        manager.SetPos(Vector3.MoveTowards(
            manager.cursorTransform.position,
            player.transform.position,
            speed * Time.deltaTime
        ));

        if (Vector3.Distance(manager.cursorTransform.position, player.transform.position) <= 0.5f)
        {
            playerController.Stun();
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorFindingNearestAppState>());
        }
    }

    public override void ExitState(CursorStateManager manager)
    {

    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        throw new System.NotImplementedException();
    }
}
