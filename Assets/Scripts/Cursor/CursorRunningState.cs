using UnityEngine;

public class CursorRunningState : CursorBaseState
{
    Vector3 target = Vector3.zero;
    private float speed = 5f;
    private float timer = 1f;
    private float time = 0f;
    private float totalTime = 0f;
    private bool isMoving = true;

    public override void EnterState(CursorStateManager manager) {}

    public override void UpdateState(CursorStateManager manager)
    {
        time += Time.deltaTime;
        totalTime += Time.deltaTime;

        if (isMoving)
        {
            manager.SetPos(Vector2.MoveTowards(
                manager.cursor.transform.position,
                target,
                speed * Time.deltaTime
            ));
        }

        if (time >= timer)
        {
            time = 0f;
            target = manager.cursor.transform.position + RandomVector2();
            isMoving = !isMoving;
            timer = isMoving ? 1f : 0.75f;
        }

        if (totalTime >= 7f)
        {
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorOpeningState>());
        }
    }

    public override void ExitState(CursorStateManager manager)
    {
        time = 0f;
        totalTime = 0f;
    }

    private Vector3 RandomVector2()
    {
        return new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0).normalized * 1000000;
    }
}
