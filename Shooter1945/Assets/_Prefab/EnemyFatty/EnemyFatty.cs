using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFatty : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
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
            MakeFragment();
            Death();
            return;
        }

        CheckBullet(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckBullet(other.gameObject);
    }

    private void CheckBullet(GameObject _obj)
    {
        Bullet otherBullet = _obj.GetComponent<Bullet>();
        if (otherBullet != null)
        {
            ScoreManager.ScoreUp(hitScore);
            hp -= otherBullet.damage;
            if (hp < 1)
            {
                MakeFragment();
                Death();
                ScoreManager.ScoreUp(deathScore);
                return;
            }
            rb.velocity = Vector3.down * 1;
        }
    }

    private void MakeFragment()
    {
        foreach(Transform pos in firePos)
        {
            Transform _bullet = Bullet.Pooling(bullet).transform;
            _bullet.position = pos.position;
            _bullet.rotation = pos.rotation;
            _bullet.GetComponent<Bullet>().Init();
        }
    }
}
