using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour, IDamagable
{
    public static Action OnPlayerDeath;

    [SerializeField] private int _hp = 1;

    private Transform _transform;
    private AudioSource _audio;
    private bool _isControlEnabled { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _audio = GetComponent<AudioSource>();

        _isControlEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isControlEnabled)
        {
            CheckLoseConditions();
        }
    }

    private void CheckLoseConditions()
    {
        if (_transform.position.y < -6)
        {
            PlayerDeath();
        }
        else if (_hp < 1)
        {
            PlayerDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
    }

    private void PlayerDeath()
    {
        _audio.PlayOneShot(SoundManager.instance.GetDeath());
        OnPlayerDeath();
        _isControlEnabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CommonPlatform common) == true)
        {
            _audio.PlayOneShot(SoundManager.instance.GetLand());
        }
    }
}
