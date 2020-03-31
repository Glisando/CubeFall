using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseButton;

    private bool _isPaused;
    // Start is called before the first frame update
    void Start()
    {
        _isPaused = false;

        StartMenu.OnStart += EnablePauseButton;
        Player.OnPlayerDeath += DisablePauseButton;
    }

    public void PauseButton()
    {
        if (_isPaused == true)
        {
            Time.timeScale = 1;
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            _isPaused = true;
        }
    }

    void EnablePauseButton()
    {
        _pauseButton.SetActive(true);
    }

    void DisablePauseButton()
    {
        _pauseButton.SetActive(false);
    }

    private void OnDisable()
    {
        StartMenu.OnStart -= EnablePauseButton;
        Player.OnPlayerDeath -= DisablePauseButton;
    }
}
