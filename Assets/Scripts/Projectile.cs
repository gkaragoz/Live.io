using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private GameObject _FX;
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

    private void DestroyItselfImmediately() {
        CameraShaker.Instance.ShakeOnce(Random.Range(1f, 2f), 5f, 0.1f, 1f);
        Instantiate(_FX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void DestroyItself() {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0f) {
            DestroyItselfImmediately();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Obstacle")) {
            DestroyItselfImmediately();
        }
    }

    public void SetFX(GameObject FX) {
        _FX = FX;
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
