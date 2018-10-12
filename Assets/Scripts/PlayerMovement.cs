using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runSpeed = 20;

    private Rigidbody2D _rb;
    private float _horizontal;
    private float _vertical;
    private float _moveLimiter = 0.7f;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void Update () {
        _horizontal = Input.GetAxisRaw("Horizontal");	
        _vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (_horizontal != 0 && _vertical != 0)
            _rb.velocity = new Vector2((_horizontal * runSpeed) * _moveLimiter, (_vertical * runSpeed) * _moveLimiter);
        else
            _rb.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed);
    }
}
