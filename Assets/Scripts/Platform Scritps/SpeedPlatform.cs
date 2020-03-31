using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlatform : Platform
{
    private float _slideSpeed = 1.5f;

    private void Start()
    {
        base.Start();
        _renderer.flipX = Random.value < 0.5f ? true : false;
        _slideSpeed = _renderer.flipX == true ? _slideSpeed : -_slideSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        IMovable obj;

        if (collision.gameObject.TryGetComponent<IMovable>(out obj) == true)
        {

            obj.Slide(_slideSpeed);
        }
    }
}
