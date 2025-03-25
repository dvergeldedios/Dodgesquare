// store attributes
// instantiate template object
// compute and apply random speed and angle

using UnityEngine;

public class FallingObject
{
    // Private fields to store speed and angle ranges.
    private float _minSpeed;
    private float _maxSpeed;
    private float _minAngle;
    private float _maxAngle;

    private float _randomAngle;
    private float _angleRad;
    private float _randomSpeed;

    public Vector2 Velocity;
    public GameObject Obj;

    // in the constructor, instantiate the template object, compute and apply random speed and angle, set attributes
    public FallingObject(GameObject prefab, Vector2 spawnPosition, float minSpeed, float maxSpeed, float minAngle, float maxAngle)
    {
        this._minSpeed = minSpeed;
        this._maxSpeed = maxSpeed;
        this._minAngle = minAngle;
        this._maxAngle = maxAngle;
        
        // instantiate falling object template at the specified position.
        Obj = GameObject.Instantiate(prefab, spawnPosition, Quaternion.identity);
        
        // random falling angle (converted to radians)
        _randomAngle = Random.Range(_minAngle, _maxAngle);
        _angleRad = _randomAngle * Mathf.Deg2Rad;

        _randomSpeed = Random.Range(_minSpeed, _maxSpeed);

        // calc horizontal and vertical speed
        Velocity = new Vector2(Mathf.Cos(_angleRad) * _randomSpeed, Mathf.Sin(_angleRad) * _randomSpeed);
        
        // apply velocity to the object rigidbody2D if it exists
        Rigidbody2D rb = Obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Velocity;
        }
    }
}
