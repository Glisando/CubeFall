using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource _bgMusic;

    [Header("Clips")]
    [SerializeField] private AudioClip _bg;
    [SerializeField] private AudioClip _death;
    [SerializeField] private AudioClip _gameOver;
    [SerializeField] private AudioClip _iceBreak;
    [SerializeField] private AudioClip _land;
    [SerializeField] private AudioClip _start;

    private AudioSource _audio;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        Player.OnPlayerDeath += BGGameOverClip;
        ChangeBgClip(_bg);
    }

    void BGGameOverClip()
    {
        _bgMusic.clip = _gameOver;
        _bgMusic.loop = false;
        _bgMusic.Play();
    }

    private void ChangeBgClip(AudioClip clip)
    {
        _bgMusic.clip = clip;
        _bgMusic.loop = true;
        _bgMusic.Play();
    }

    public void PlayIceBreak()
    {
        _audio.PlayOneShot(_iceBreak);
    }

    #region getters

    public AudioClip GetBG()
    {
        return _bg;
    }
    public AudioClip GetDeath()
    {
        return _death;
    }
    public AudioClip GetGameOver()
    {
        return _gameOver;
    }
    public AudioClip GetIceBreak()
    {
        return _iceBreak;
    }
    public AudioClip GetLand()
    {
        return _land;
    }
    public AudioClip GetStar()
    {
        return _start;
    }

    #endregion

    private void OnDisable()
    {
        Player.OnPlayerDeath -= BGGameOverClip;
    }
}
