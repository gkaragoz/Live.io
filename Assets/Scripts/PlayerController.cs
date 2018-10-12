using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public Weapon weapon;

    private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate() {
        Aim();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 targetVelocity = new Vector2(horizontal, vertical);
        _rb.velocity = targetVelocity * speed;

        if (Input.GetMouseButton(0))
            Fire();
    }

    void Aim() {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 lookAtDirection = Input.mousePosition - objectPos;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg));
    }

    void Fire() {
        if (weapon != null)
            weapon.Fire();
    }
}
