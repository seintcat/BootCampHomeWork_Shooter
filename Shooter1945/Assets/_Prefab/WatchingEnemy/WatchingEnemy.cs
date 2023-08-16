using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingEnemy : Enemy
{
    [SerializeField]
    private Vector2Int fireMinMax;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        fire = Fire();
        Init();
        transform.rotation = Quaternion.LookRotation(Vector3.down, -Vector3.forward);
        rb.velocity = Vector3.down * 1;
        playerPos = Player.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPos, Vector3.back);
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
            hp -= bullet.damage;
            if (hp < 1)
            {
                ScoreManager.ScoreUp(deathScore);
                Death();
                return;
            }
            rb.velocity = Vector3.down * 1;
        }
    }
}
