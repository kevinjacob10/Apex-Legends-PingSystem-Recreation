using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    
    [SerializeField]
    private Transform vfxHitGreen;

    [SerializeField]
    private Transform vfxHitRed;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 40f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BulletTarget>() != null)
        {
            //Hitting the target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            // To hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
