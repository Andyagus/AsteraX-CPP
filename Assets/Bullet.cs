using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody bulletRb;
    //private Vector3 mousePos; 

    private Vector3 aimDirection;
    private int speed = 1000;


    private void Awake()
    {
        //ShipMovement.instance.OnShotFired += BulletInstatiated;
        bulletRb = gameObject.GetComponent<Rigidbody>();
        aimDirection = RotateTurret.instance.aimDirection;
        AddForceToBullet();
        StartCoroutine("DestroyBullet");
        
    }

    private void AddForceToBullet()
    {
        bulletRb.AddForce(aimDirection * speed);

    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
