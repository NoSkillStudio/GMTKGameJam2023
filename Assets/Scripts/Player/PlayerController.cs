using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // если на игроке нет Rigidbody2D, скрипт добавит
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _stunTime = 3f;
    private float _speed;

    [SerializeField] private float _startSpeed;
    public SpriteRenderer spriteRenderer { get; private set; }
    public Vector2 _axis;
    private Rigidbody2D _rb;

    private Animator animator;
    private Vector2 screenBounds;

    [SerializeField] private float offset;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _startSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        CheckBoundaries();

        _axis = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (_axis.x == -1)
            spriteRenderer.flipX = true;
        else if (_axis.x == 1)
            spriteRenderer.flipX = false;

        animator.SetFloat("AxisX", Mathf.Abs(_axis.x));
        if(Mathf.Abs(_axis.x) == 0)
        animator.SetFloat("AxisX", Mathf.Abs(_axis.y));
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _axis * _speed * Time.fixedDeltaTime);
    }

    private void CheckBoundaries()
    {

        if (transform.position.x < -screenBounds.x + offset)
        {
            transform.position = new Vector2(-screenBounds.x + offset, transform.position.y);
        }
        else if (transform.position.x > screenBounds.x - offset)
        {
            transform.position = new Vector2(screenBounds.x - offset, transform.position.y);
        }

        if (transform.position.y < -screenBounds.y + offset)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y + offset);
        }
        else if (transform.position.y > screenBounds.y - offset)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y - offset);
        }
    }
    public void StopSpeed() => _speed = 0;

    public void SetNormalSpeed() => _speed = _startSpeed;

    public void Stun()
    {
        StopSpeed();
        Invoke(nameof(SetNormalSpeed), _stunTime);
    }
}
