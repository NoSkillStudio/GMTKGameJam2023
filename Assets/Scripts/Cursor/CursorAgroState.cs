using UnityEngine;

public class CursorAgroState : CursorBaseState
{
    private PlayerCollision player;
    private PlayerController playerController;
    private float speed = 3f;

    public override void EnterState(CursorStateManager manager)
    {
        player = FindObjectOfType<PlayerCollision>();
        playerController = FindObjectOfType<PlayerController>();
        clickSound = manager.GetComponent<AudioSource>();
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
            clickSound.Play();
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
