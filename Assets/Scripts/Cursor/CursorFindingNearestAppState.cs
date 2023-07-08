using UnityEngine;

public class CursorFindingNearestAppState : CursorBaseState
{
    private App[] apps;
    private App target;

    private App nearestApp;
    private float nearestAppDistance;
    private float currentDistance;

    private float speed = 4f;

    private float timer = 2f;
    private float time = 0f;

    public override void EnterState(CursorStateManager manager)
    {
        apps = Object.FindObjectsOfType<App>();
        target = Choice(apps, manager);
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
            // ���� ��������� � ������� ����������
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
            return;
        }

        if (Vector3.Distance(manager.cursorTransform.position, target.transform.position) <= 0.25f)
        {
            time += Time.deltaTime;
            if (time >= timer)
            {
                clickSound.Play();
                target.transform.SetParent(manager.gameObject.transform, true);
                manager.SwitchToState(ScriptableObject.CreateInstance<CursorReturnState>(), target);
            }
        }
    }

    public override void ExitState(CursorStateManager manager)
    {

    }

    private App Choice(App[] apps, CursorStateManager cursorStateManager)
    {
        //try
        //{
        //    //return apps[idx];
        nearestApp = null;
        nearestAppDistance = Mathf.Infinity;

        for (int idx = 0; idx < apps.Length; idx++)
        {
            currentDistance = Vector2.Distance(cursorStateManager.transform.position, apps[idx].GetComponent<Transform>().transform.position);

            if (currentDistance <= nearestAppDistance)
            {
                nearestApp = apps[idx];
                nearestAppDistance = currentDistance;
            }
        }

        return nearestApp;
        //}
        //catch
        //{
        //    Debug.Log("null");
        //    return null;
        //}

    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        throw new System.NotImplementedException();
    }
}