using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public static Action OnStart;

    [SerializeField] private GameObject _player;
    [SerializeField] private List<Sprite> _playerSkins;
    [SerializeField] private Image _currentSkin;

    private int _skinIndex;
    // Start is called before the first frame update
    void Start()
    {
        _skinIndex = 0;
        _currentSkin.sprite = _playerSkins[_skinIndex];
    }

    public void NextSkin()
    {
        _skinIndex = (_skinIndex + 1) % _playerSkins.Capacity;
        _currentSkin.sprite = _playerSkins[_skinIndex];
    }

    public void PreviousSkin()
    {
        int newIndex = _skinIndex - 1;
        _skinIndex = newIndex < 0 ? _playerSkins.Capacity - 1 : newIndex;
        _currentSkin.sprite = _playerSkins[_skinIndex];
    }

    public void StartButton()
    {
        OnStart();
        GameObject player = Instantiate(_player, transform.position, Quaternion.identity);

        player.GetComponent<SpriteRenderer>().sprite = _playerSkins[_skinIndex];
        gameObject.SetActive(false);
    }
}
