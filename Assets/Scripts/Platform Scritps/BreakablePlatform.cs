using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BreakablePlatform : Platform
{
    private Animator _animator;
    private bool _isBreaking = false;
    private AudioSource _audio;

    private void Start()
    {
        base.Start();

        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player;

        bool isPlayer = collision.gameObject.TryGetComponent<Player>(out player);

        if (isPlayer == true && _isBreaking == false)
        {
            _isBreaking = true;
            _animator.SetBool("Break", true);
        }
    }

    public void DestroyPlatform()
    {
        SoundManager.instance.PlayIceBreak();
        Destroy(gameObject);
    }
}
