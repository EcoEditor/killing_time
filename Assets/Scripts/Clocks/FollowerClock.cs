using System;
using UnityEngine;

namespace Gameplay.Clocks
{
    public class FollowingClock : ClockBase
    {
        private Rigidbody2D _rb2d;
        private Vector2 _moveDirection;
        private Player _target;

        protected override void Awake()
        {
            base.Awake();
            _rb2d = GetComponent<Rigidbody2D>();
            _target = FindObjectOfType<Player>();
        }

        private void Update()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            // calculate direction to target pickup and start moving toward it
            _moveDirection = new Vector2(
                _target.transform.position.x - transform.position.x,
                _target.transform.position.y - transform.position.y);
            _moveDirection.Normalize();
            _rb2d.velocity = Vector2.zero;
            float impulseForce = model.Speed;
            _rb2d.AddForce(_moveDirection * impulseForce, 
                ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                Debug.Log("direction from the follower clock" + _moveDirection);
                _target.BounceBack(_moveDirection);
            }
        }
    }
}