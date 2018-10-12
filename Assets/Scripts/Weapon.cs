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

    public void Fire() {
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, transform.root.rotation).GetComponent<Projectile>();

        Vector2 direction = (firePoint.position - transform.position).normalized;
        projectile.SetSpeed(20f);
        projectile.SetLifeTime(projectileLifeTime);
        projectile.SetDirection(direction);
    }
    
}

