using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player model;
        
        [Header("Shooting")]
        [SerializeField] private Bullet bulletRef;
        [SerializeField] private Transform bulletPivot;
        [SerializeField] private float shootingInterval = 0.6f;
        
        private Rigidbody2D _rb2d;
        private Vector2 _screenBounds;
        private Vector3 _playerScale;
        private float _startTime;
        private float _colliderBounds;
        private bool _isShooting;
        
        public bool Shooting => _isShooting;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _playerScale = transform.localScale;
            _colliderBounds = GetComponent<CircleCollider2D>().bounds.extents.x;
            CalculateScreenBounds();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                // Rotate left
                RotateWeapon(Vector2.left);
            }
            
            if (Input.GetKey(KeyCode.X))
            {
                // Rotate right
                RotateWeapon(Vector2.right);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

            var duration = Time.time - _startTime;
            if (duration >= shootingInterval && _isShooting)
            {
                _isShooting = false;
            }
            
            var moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Move(moveDirection);
            ClampPositionToScreen();
        }

        private void RotateWeapon(Vector2 direction)
        {
            bulletPivot.Rotate(direction);
        }
        
        private void Shoot()
        {
            _isShooting = true;
            _startTime = Time.time;
            var bulletObj = Instantiate(bulletRef, bulletPivot.position, Quaternion.identity);
            bulletObj.TempIgnoreCollider();
            bulletObj.StartMoving(bulletPivot.forward);
        }

        private void Move(Vector2 direction)
        {
            transform.Translate(direction * model.MovementSpeed * Time.deltaTime);
        }
        
        private void ClampPositionToScreen()
        {
            var position = transform.position;
            // Clamp the X and Y position within the screen boundaries.
            position.x = Mathf.Clamp(position.x, -_screenBounds.x + _colliderBounds, _screenBounds.x - _colliderBounds);
            position.y = Mathf.Clamp(position.y, -_screenBounds.y + _colliderBounds, _screenBounds.y - _colliderBounds);

            // Set the clamped position back to the player's position.
            transform.position = position;
        }
        
        private void CalculateScreenBounds()
        {
            float screenHeight = Screen.height;
            float screenWidth = Screen.width;
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, Camera.main.transform.position.z));
        }
    }
}