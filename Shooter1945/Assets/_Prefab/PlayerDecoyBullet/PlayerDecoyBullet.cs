using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerDecoyBullet : Bullet
{
    [SerializeField]
    private Transform model;

    private IEnumerator raycastCheck;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        raycastCheck = RayCasting();
        StartCoroutine(raycastCheck);
        rb.velocity = transform.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {
        model.Rotate(new Vector3(0, 0, 3));
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            rb.velocity = Vector3.Lerp(Vector3.zero, rb.velocity, 0.96f);
            rb.velocity += (target.position - transform.position).normalized * 3 * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = transform.forward * 2;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(-90, 0, 0)), Time.fixedDeltaTime);
        }
    }

    private IEnumerator RayCasting()
    {
        while (target == null)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 3, 1 << LayerMask.NameToLayer("Enemy"));
            if (
                hits.Length > 0 &&
                transform.position.y < hits[0].transform.position.y
              )
            {
                target = hits[0].transform;
            }
            yield return new WaitForSeconds(1);
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawSphere(transform.position, 3);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        EndSelf();
    }

    private void OnTriggerExit(Collider other)
    {
        WallOutDestroyer.WallTriggerExit(other, gameObject);
    }
}
