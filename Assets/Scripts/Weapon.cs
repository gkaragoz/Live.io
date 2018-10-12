using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum WeaponType {
        Gun,
        Shotgun
    }

    public WeaponType weaponType;
    public float projectileLifeTime = 2f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public GameObject FX;

    private float _fireRateCooldown;

	void Start () {
        switch (weaponType) {
            case WeaponType.Gun:
            break;
            case WeaponType.Shotgun:
            break;
            default:
            break;
        }
    }

    void Update() {
        _fireRateCooldown -= Time.deltaTime;    
    }

    public void Fire() {
        if (_fireRateCooldown <= 0) {
            Projectile projectile = Instantiate(projectilePrefab, firePoint.position, transform.root.rotation).GetComponent<Projectile>();

            Vector2 direction = (firePoint.position - transform.position).normalized;
            projectile.SetFX(FX);
            projectile.SetSpeed(20f);
            projectile.SetLifeTime(projectileLifeTime);
            projectile.SetDirection(direction);

            _fireRateCooldown = fireRate;
        }
    }
    
}

