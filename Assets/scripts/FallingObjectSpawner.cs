using UnityEngine;
using System.Collections.Generic;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject TemplateFallingObject;

    private float _spawnInterval;
    private float _timeSinceLastSpawn;
    private float _reductionRate;
    private float _minSpeedBase;
    private float _minSpeedCap;
    private float _maxSpawnInterval;

    private float _maxMinSpeed;
    private float _maxMaxSpeed;

    void Start()
    {
        // get difficulty
        int diff = PlayerPrefs.GetInt("difficulty", 1);
        // easy
        if (diff == 0) 
        {
            _spawnInterval = 2f;
            _reductionRate = 0.0225f;
            _minSpeedBase = 2f; // max at 7
            _minSpeedCap = 4f; // max at 8
            _maxSpawnInterval = 0.25f; // 4 max per sec

            _maxMinSpeed = 8.5f;
            _maxMaxSpeed = 9.5f;
        }

        // hard
        else if (diff == 2) 
        {
            _spawnInterval = 1.75f;
            _reductionRate = 0.029f;
            _minSpeedBase = 4f; // max at 13
            _minSpeedCap = 6f; // max at 14
            _maxSpawnInterval = 0.195f; // 5.something max per sec

            _maxMinSpeed = 12f;
            _maxMaxSpeed = 13f;
        }
        else // medium
        {
            _spawnInterval = 2f;
            _reductionRate = 0.0275f;
            _minSpeedBase = 3f; // max at 10
            _minSpeedCap = 5f; // max at 11
            _maxSpawnInterval = 0.225f; // 4.something max per sec

            _maxMinSpeed = 10f;
            _maxMaxSpeed = 11f;
        }
    }

    void Update()
    {
        _spawnInterval -= Time.deltaTime * _reductionRate;
        // make sure spawn interval never drops 0.25s
        _spawnInterval = Mathf.Max(_maxSpawnInterval, _spawnInterval);

        // make min and max speed caps increase over time and wall them at a certain point
        // reduction rate being used to increase the min and max speed by multiplying it by the time elapsed and adding it to the min base and cap
        _minSpeedBase = Mathf.Min(_maxMinSpeed, _minSpeedBase + (Time.deltaTime * _reductionRate));
        _minSpeedCap = Mathf.Min(_maxMaxSpeed, _minSpeedCap + (Time.deltaTime * _reductionRate));

        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= _spawnInterval)
        {
            SpawnFallingObject();
            _timeSinceLastSpawn = 0f;
        }
    }

    void SpawnFallingObject()
    {
        // calc random spawn point (x value)
        float randomX = Random.Range(-7.2f, 6.7f);
        Vector2 spawnPos = new Vector2(randomX, 5f);

        new FallingObject(TemplateFallingObject, spawnPos, _minSpeedBase, _minSpeedCap, 210f, 330f);
    }
}
