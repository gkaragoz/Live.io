using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private float _speed;
    private float _lifeTime;
    private Vector2 _direction;
    private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Update() {
        DestroyItself();
    }

    void FixedUpdate () {
        _rb.velocity = _direction * _speed;
	}

    private void DestroyItself() {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0f) {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed) {
        _speed = speed;
    }

    public void SetDirection(Vector2 direction) {
        _direction = direction;
    }

    public void SetLifeTime(float lifeTime) {
        _lifeTime = lifeTime;
    }
}
