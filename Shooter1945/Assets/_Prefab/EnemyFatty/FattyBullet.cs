using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        rb.velocity = transform.forward * 1.5f;
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
