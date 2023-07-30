using Gameplay;
using Gameplay.Clocks;
using UnityEngine;

/// <summary>
/// A bullet
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float launchVelocity = 20;
    [SerializeField] private CircleCollider2D myCollider;
    public float ownerIgnoreTime = 0.2f;

    // saved for efficiency
    private Rigidbody2D _rb2d;
    private bool _isIgnoringOwnerCollision;
    private float _ignoreTimer = 0f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void TempIgnoreCollider()
    {
        myCollider.enabled = false;
        _isIgnoringOwnerCollision = true;
        _ignoreTimer = ownerIgnoreTime;
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
        if (_isIgnoringOwnerCollision)
        {
            _ignoreTimer -= Time.deltaTime;
            if (_ignoreTimer <= 0f)
            {
                myCollider.enabled = true;
                _isIgnoringOwnerCollision = false;
            }
        }
        
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
        StopMoving();
        gameObject.SetActive(false);
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
            Destroy(gameObject);
            // if colliding with enemy return both to 
            // their respective pools
            //ObjectPool.ReturnEnemy(other.gameObject);
            //ObjectPool.ReturnBullet(gameObject);
        } else if (other.gameObject.CompareTag("Clock"))
        {
            other.GetComponent<ClockBase>().DecreaseHealth();
            Destroy(gameObject);
        }
    }
}
