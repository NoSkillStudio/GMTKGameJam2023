using UnityEngine;

public class CursorStateManager : MonoBehaviour
{
    [HideInInspector] public GameObject cursor;
    [HideInInspector] public Transform cursorTransform;

    private CursorBaseState state;
    private Vector2 screenBounds;

    [SerializeField] private float offset;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            Screen.width,
            Screen.height,
            Camera.main.transform.position.z
        ));
        cursor = gameObject;
        cursorTransform = transform;
        state = ScriptableObject.CreateInstance<CursorIdleState>();
        state.EnterState(this); 
    }

    private void Update()
    {
        state.UpdateState(this);
    }

    public void SwitchToState(CursorBaseState state)
    {
        state.ExitState(this);
        this.state = state;
        state.EnterState(this);
    }

    public void SwitchToState(CursorBaseState state, App transform)
    {
        state.ExitState(this);
        this.state = state;
        state.EnterState(this, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void SetPos(Vector3 newPos)
    {
        transform.position = newPos;

        if (transform.position.x < -screenBounds.x + offset)
        {
            transform.position = new Vector2(screenBounds.x - offset, transform.position.y);
        }
        else if (transform.position.x > screenBounds.x - offset)
        {
            transform.position = new Vector2(-screenBounds.x + offset, transform.position.y);
        }

        if (transform.position.y < -screenBounds.y + offset)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y - offset);
        }
        else if (transform.position.y > screenBounds.y - offset)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y + offset);
        }
    }
}
