using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Rigidbody2D _rb;

    private float _moveSpeed = 30f;
    private float _shootTimer;
    private float _shootCooldown = 0.2f;

    public float MoveSpeed { get { return _moveSpeed; } }

	void Start ()
    {
        _rb = gameObject.AddComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _rb.gravityScale = 0;
        _rb.drag = 5;
	}
	
    void Update()
    {
        if(_shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform, false);
            bullet.GetComponent<BulletBasicController>().SetBulletParams(Vector2.up, 50);
            _shootTimer = _shootCooldown;
        }

        if (_shootTimer > 0)
        {
            _shootTimer -= Time.deltaTime;
        }
    }

	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        _rb.AddForce(movement * _moveSpeed);
	}
}
