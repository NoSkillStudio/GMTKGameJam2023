using UnityEngine;

public class CursorReturnState : CursorBaseState
{
    private Vector3 target;
    private Vector3 appPos;



    private float speed = 4f;
    public override void EnterState(CursorStateManager manager)
    {

    }

    public override void EnterState(CursorStateManager manager, App transform)
    {
        
        transform.GetComponent<Transform>().position = manager.transform.position;
        target = transform.GetComponent<App>().SpawnPoint;
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
        }
        catch
        {
            // утка выбросила в корзину приложение
            manager.SwitchToState(ScriptableObject.CreateInstance<CursorAgroState>());
            return;
        }
    }
    public override void ExitState(CursorStateManager manager)
    {

    }

}