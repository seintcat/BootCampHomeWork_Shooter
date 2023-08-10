using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField]
    private Vector2Int fireMinMax;

    // Start is called before the first frame update
    void Start()
    {
        fire = Fire();
        Init();
        transform.rotation = Quaternion.LookRotation(Vector3.down, -Vector3.forward);
        rb.velocity = Vector3.down * 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(fireMinMax.x, fireMinMax.y));
            Transform _bullet = Instantiate(bullet).transform;
            _bullet.position = firePos[0].position;
            _bullet.rotation = transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checking
        if(collisionOthers.Exists(x => x.gameObject == collision.gameObject))
        {
            return;
        }
        collisionOthers.Add(collision.gameObject);

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Death();
            return;
        }

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if(bullet != null)
        {
            hp -= bullet.damage;
            if(hp < 1)
            {
                Death();
                return;
            }
            rb.velocity = Vector3.down * 1;
        }
    }
}
