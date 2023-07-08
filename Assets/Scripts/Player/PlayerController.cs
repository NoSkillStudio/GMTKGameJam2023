using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // если на игроке нет Rigidbody2D, скрипт добавит
public class PlayerController : MonoBehaviour
{
    private float _speed;

    [SerializeField] private float _startSpeed;
    private SpriteRenderer _renderer;
    private Vector2 _axis;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _startSpeed;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckBoundaries();
        _axis.x = Input.GetAxisRaw("Horizontal");
        _axis.y = Input.GetAxisRaw("Vertical");

        if (_axis.x < 0)
            _renderer.flipX = false;
        else if (_axis.x < 0)
            _renderer.flipX = true;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _axis * _speed * Time.fixedDeltaTime);
    }

    private void CheckBoundaries()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }
        else if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        }
        else if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }
    }
    public void StopSpeed() => _speed = 0;

    public void SetNormalSpeed() => _speed = _startSpeed;
}
