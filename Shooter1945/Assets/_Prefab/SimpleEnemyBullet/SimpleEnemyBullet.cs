using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        EndSelf();
    }

    private void OnTriggerExit(Collider other)
    {
        WallOutDestroyer.WallTriggerExit(other, gameObject);
    }
}
