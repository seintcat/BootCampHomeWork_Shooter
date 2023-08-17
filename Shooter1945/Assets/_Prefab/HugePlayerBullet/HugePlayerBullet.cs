using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugePlayerBullet : Bullet
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
        rb.velocity = transform.forward * 10;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerExit(Collider other)
    {
        WallOutDestroyer.WallTriggerExit(other, gameObject);
    }
}
