using UnityEngine;

public class CursorOpeningState : CursorBaseState
{
    private App[] apps;
    private App target;
    private float speed;
    private float timer = 1f;
    private float time = 0f;
    private bool isOpening;

    public override void EnterState(CursorStateManager manager)
    {
        apps = Object.FindObjectsOfType<App>();
        target = Choice(apps);
    }

    public override void UpdateState(CursorStateManager manager)
    {
        time += Time.deltaTime;

        if (isOpening)
        {
            manager.SetPos(Vector2.MoveTowards(
                manager.cursor.transform.position,
                target.transform.position,
                speed * Time.deltaTime
            ));

            if (Vector3.Distance(manager.cursorTransform.position, target.transform.position) <= 0.25f)
            {
                target.Open();
                isOpening = false;
                manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
            }
        }

        if (time >= timer)
        {
            time = 0f;
            target = Choice(apps);
            isOpening = !isOpening;
            timer = isOpening ? 1f : 0.75f;
        }
    }

    public override void ExitState(CursorStateManager manager)
    {
        time = 0f;
    }

    private App Choice(App[] apps)
    {
        return apps[Random.Range(0, apps.Length - 1)];
    }
}
