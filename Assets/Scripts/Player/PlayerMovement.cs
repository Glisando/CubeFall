using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _body;

    private bool _isControlEnabled;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        _isControlEnabled = true;

        Player.OnPlayerDeath += DisableControl;

        _moveSpeed = ConfigurationUtils.PlayerSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isControlEnabled == true)
        {
            float vx = CrossPlatformInputManager.GetAxis("Horizontal");

            if (vx != 0)
            {
                _body.velocity = new Vector2(vx * _moveSpeed, _body.velocity.y);
            }
        }
    }

    void DisableControl()
    {
        _isControlEnabled = false;
    }

    void EnableControl()
    {
        _isControlEnabled = true;
    }

    public void Slide(float slideSpeed)
    {
        _body.velocity = new Vector2(slideSpeed, _body.velocity.y);
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= DisableControl;
    }
}
