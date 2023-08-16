using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // death score +10
        EndSelf();
    }

    private void OnTriggerExit(Collider other)
    {
        WallOutDestroyer.WallTriggerExit(other, gameObject);
    }
}
