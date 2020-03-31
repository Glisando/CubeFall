using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Platform : MonoBehaviour
{
    protected float _speed;
    protected SpriteRenderer _renderer;
    protected Transform _transform;
    protected Rigidbody2D _rigidbody;

    protected bool _isMovementEnabled;
    // Start is called before the first frame update
    protected void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();

        StartMenu.OnStart += DestroyMyself;

        _isMovementEnabled = true;
        _speed = ConfigurationUtils.PlatformSpeed;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (_isMovementEnabled == true)
        {
            Movement();
        }
    }

    protected void Movement()
    {
        if (_transform.position.y > 6)
        {
            Destroy(gameObject);
        }

        _rigidbody.velocity = Vector2.up * _speed;
    }

    void DestroyMyself()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        StartMenu.OnStart -= DestroyMyself;
    }
}
