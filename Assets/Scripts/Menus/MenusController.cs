using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    // Start is called before the first frame update
    void Awake()
    {
        Player.OnPlayerDeath += EnableGameOverUI;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void EnableGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverUI;
    }
}
