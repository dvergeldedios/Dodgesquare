using UnityEngine;
using System.Collections.Generic;

public class FallingObjectSpawner : MonoBehaviour 
{
    public GameObject TemplateFallingObject;

    private float _spawnInterval = 2f;
    private float _timeSinceLastSpawn;
    private float _spawnIntervalReduction;
    // private List<FallingObject> _fallingObjects = new List<FallingObject>();

    void Update()
    {
        //spawn interval stuff, 
        _spawnIntervalReduction += Time.deltaTime * 0.04f;
        _spawnInterval = Mathf.Max(0.25f, 1.5f - _spawnIntervalReduction);


        // clear game objects that don't exist from the list each update
        // _fallingObjects.RemoveAll(fo => fo.Obj == null);

        //countdown until next spawn
        _timeSinceLastSpawn += Time.deltaTime;

        // check if there is 
        if (_timeSinceLastSpawn >= _spawnInterval)
        {
            SpawnFallingObject();
            _timeSinceLastSpawn = 0f;
        }
    }
    
    void SpawnFallingObject() 
    {
        // spawn at random coords
        float randomXSpawnPos = Random.Range(-7.2f, 6.7f);
        Vector2 spawnPos = new Vector2(randomXSpawnPos, 5);

        // calculate speeds, make sure they don't exceed 10 
        float newMinSpeed = Mathf.Clamp(2f + _spawnIntervalReduction, 3f, 15f);
        float newMaxSpeed = Mathf.Clamp(8f + _spawnIntervalReduction, 5f, 15f);


        FallingObject newObject = new FallingObject(TemplateFallingObject, spawnPos, newMinSpeed, newMaxSpeed, 210f, 330f);

        // _fallingObjects.Add(newObject);
    }
}