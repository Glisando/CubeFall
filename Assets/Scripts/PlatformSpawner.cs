using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Platforms")]
    [Tooltip("Usual platform without any power")]
    [SerializeField] private GameObject _normalPlatform;

    [Tooltip("Breakable, spike and moving platforms")]
    [SerializeField] private List<GameObject> _poweredPlatforms;

    [Header("Spawn settings")]
    [SerializeField] private int _chanceToSpawnPowered = 4;
    [SerializeField] private float _platformSpawnTime = 2f;
    [SerializeField] private float _minXSpawnPos = -2.3f;
    [SerializeField] private float _maxXSpawnPos = 2.3f;
    [SerializeField] private Transform _parent;

    private GameObject _platformToSpawn;
    private Vector2 _newPlatformPosition;

    private float _platformTimer = 0f;
    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _newPlatformPosition = transform.position;
        StartMenu.OnStart += SpawnFirstPlatform;

        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        _platformTimer += Time.deltaTime;

        CheckSpawnTimer();
    }

    private void CheckSpawnTimer()
    {
        if (_platformTimer > _platformSpawnTime)
        {
            _platformTimer %= _platformSpawnTime;

            // chance to spawn powered platform
            if (UnityEngine.Random.Range(0, _chanceToSpawnPowered) == 1)
            {
                _platformToSpawn = _poweredPlatforms[UnityEngine.Random.Range(0, _poweredPlatforms.Count)];
            }
            else
            {
                _platformToSpawn = _normalPlatform;
            }

            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        _newPlatformPosition.x = UnityEngine.Random.Range(_minXSpawnPos, _maxXSpawnPos);

        GameObject tmp = Instantiate(_platformToSpawn, _newPlatformPosition, Quaternion.identity);
        tmp.transform.parent = _parent;
    }

    private void SpawnFirstPlatform()
    {
        GameObject.Instantiate(_normalPlatform, new Vector2(0, -2), Quaternion.identity);
    }

    private void OnDisable()
    {
        StartMenu.OnStart -= SpawnFirstPlatform;
    }
}
