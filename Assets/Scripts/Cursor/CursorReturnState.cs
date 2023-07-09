using UnityEngine;

public class CursorReturnState : CursorBaseState
{
    private Vector3 target;
    private GameObject app;
    private PlayerCollision player;

    private float speed = 4f;
    public override void EnterState(CursorStateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        player = FindObjectOfType<PlayerCollision>();
        player.DontGrab();
        target = transform.GetComponent<App>().SpawnPoint;
        transform.GetComponent<Transform>().position = manager.transform.position;
        app = transform.gameObject;
    }


    public override void UpdateState(CursorStateManager manager)
    {
        try
        {
            manager.SetPos(Vector2.MoveTowards(
                manager.cursor.transform.position,
                target,
                speed * Time.deltaTime
            ));
            app.transform.position = manager.transform.position;
        }
        catch
        {
            // ���� ��������� � ������� ����������
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
            return;
        }


        if (Vector3.Distance(manager.cursorTransform.position, target) <= 0.25f)
        {
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
        }
    }
    public override void ExitState(CursorStateManager manager)
    {

    }

}