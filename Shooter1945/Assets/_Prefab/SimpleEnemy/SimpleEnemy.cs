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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    public override void EnemyInit()
    {
        fire = Fire();
        base.EnemyInit();
        transform.rotation = Quaternion.LookRotation(Vector3.down, -Vector3.forward);
        rb.velocity = Vector3.down * 1;
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(fireMinMax.x, fireMinMax.y));
            Transform _bullet = ObjectPoolingManager.Pooling(bullet).transform;
            _bullet.position = firePos[0].position;
            _bullet.rotation = transform.rotation;
            _bullet.GetComponent<Bullet>().Init();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checking
        if (collisionOthers.Exists(x => x.gameObject == collision.gameObject))
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

        CheckBullet(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckBullet(other.gameObject);
    }

    private void CheckBullet(GameObject obj)
    {
        Bullet bullet = obj.GetComponent<Bullet>();
        if (bullet != null)
        {
            ScoreManager.ScoreUp(hitScore);
            hpNow -= bullet.damage;
            if (hpNow < 1)
            {
                ScoreManager.ScoreUp(deathScore);
                Death();
                return;
            }
            rb.velocity = Vector3.down * 1;
        }
    }
}
