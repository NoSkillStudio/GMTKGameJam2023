using UnityEngine;

public class CursorOpeningState : CursorBaseState
{
    private App[] apps;
    private App target;
    private float speed = 5f;

    public override void EnterState(CursorStateManager manager)
    {
        apps = Object.FindObjectsOfType<App>();
        target = Choice(apps);
        if (target == null)
        {
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
        }
        clickSound = manager.GetComponent<AudioSource>();
    }

    public override void UpdateState(CursorStateManager manager)
    {
        try
        {
            manager.SetPos(Vector2.MoveTowards(
                manager.cursor.transform.position,
                target.transform.position,
                speed * Time.deltaTime
            ));
        }
        catch
        {
            // утка выбросила в корзину приложение
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
            return;
        }

        if (Vector3.Distance(manager.cursorTransform.position, target.transform.position) <= 0.25f)
        {
            clickSound.Play();
            target.Open();
            if (target.window == WindowSpawner.Window.Explorer/* && Random.Range(0, 2) == 0*/)
            {
                manager.SwitchToState(
                    ScriptableObject.CreateInstance<CursorSearchingState>(),
                    target.GetComponent<App>()
                );
            }

            manager.SwitchToState(ScriptableObject.CreateInstance<CursorIdleState>());
        }
    }

    public override void ExitState(CursorStateManager manager) {}

    private App Choice(App[] apps)
    {
        try
        {
            int idx = Random.Range(0, apps.Length);
            return apps[idx];
        }
        catch
        {
            return null;
        }
    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        throw new System.NotImplementedException();
    }
}
