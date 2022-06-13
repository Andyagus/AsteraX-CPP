using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour {
    public int lifeTime = 2;
    private float bulletSpeed = 20f;


	static private Transform bulletAnchor;
	static Transform BulletAnchor
    {
        get
        {
            if(bulletAnchor == null)
            {
                var anchor = new GameObject("Bullet Anchor");
                bulletAnchor = anchor.transform;
            }
                return bulletAnchor;
        }
    }

    void Start()
    {
        var bulletRb = GetComponent<Rigidbody>();
        transform.SetParent(BulletAnchor, true);
        Invoke("DestroyMe", lifeTime);
        bulletRb.velocity = transform.forward * bulletSpeed;

    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
