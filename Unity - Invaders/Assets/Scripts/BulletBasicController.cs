using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasicController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private int _damage = 5;
    private Vector2 _moveDirection;
    private float _moveSpeed;

    public int Damage { get { return _damage; } }
    public Vector2 MoveDirection { get { return _moveDirection; } }
    public float MoveSpeed { get { return _moveSpeed; } }

	void Start ()
    {
        _rb = gameObject.AddComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _rb.gravityScale = 0;
        _rb.drag = 1;
	}
	
	void FixedUpdate ()
    {
        _rb.AddForce(_moveDirection * _moveSpeed);
    }

    public void SetBulletParams(Vector2 directionVector, float speed)
    {
        _moveDirection = directionVector;
        _moveSpeed = speed;
    }
}
