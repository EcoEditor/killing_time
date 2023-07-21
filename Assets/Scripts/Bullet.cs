using System;
using Gameplay;
using UnityEngine;

/// <summary>
/// A bullet
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float launchVelocity = 20;

    // saved for efficiency
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Starts the bullet moving in the given direction
    /// </summary>
    /// <param name="direction">movement direction</param>
    public void StartMoving(Vector2 direction)
    {
        _rb2d.velocity = direction * launchVelocity;
    }

    /// <summary>
    /// Stops the bullet
    /// </summary>
    public void StopMoving()
    {
        _rb2d.velocity = Vector2.zero;
    }

    /// <summary>
    /// Update is called every frame
    /// </summary>
    void Update()
    {
        // if a bullet is active and not moving,
        // return it to the pool
        if (gameObject.activeInHierarchy &&
            _rb2d.velocity.magnitude <= 0f)
        {
            Debug.Log($"bullet velocity is {_rb2d.velocity.magnitude}");
            //ObjectPool.ReturnBullet(gameObject);
        }
    }

    /// <summary>
    /// Called when the bullet becomes invisible
    /// </summary>
    void OnBecameInvisible()
    {
        // return to the pool
        //ObjectPool.ReturnBullet(gameObject);
    }

    /// <summary>
    /// Processes trigger collisions with other game objects
    /// </summary>
    /// <param name="other">information about the other collider</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // if colliding with a bullet, return both to pool
        if (other.gameObject.CompareTag("Bullet"))
        {
            ObjectPool.ReturnObject(other.gameObject);
            //ObjectPool.ReturnBullet(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().DecreaseHealth();
            // if colliding with enemy return both to 
            // their respective pools
            //ObjectPool.ReturnEnemy(other.gameObject);
            //ObjectPool.ReturnBullet(gameObject);
        }
    }
}
