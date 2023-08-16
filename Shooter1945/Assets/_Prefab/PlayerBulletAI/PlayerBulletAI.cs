using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletAI : Bullet
{
    private Transform targetNow;
    private IEnumerator find;

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
        rb.angularVelocity = Vector3.up * 10;
        Invoke("EndSelf", 30f);
        if(find != null)
        {
            StopCoroutine(find);
            find = null;
        }
        find = FindNext();
        StartCoroutine(find);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.Lerp(Vector3.zero, rb.velocity, 0.95f);
        if(targetNow != null)
        {
            if(!targetNow.gameObject.activeSelf)
            {
                targetNow = null;
                return;
            }

            rb.velocity += (targetNow.position - transform.position).normalized * 7f;
            if ((targetNow.position - transform.position).magnitude < 1)
            {
                targetNow = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.angularVelocity = Vector3.up * 10;
        rb.velocity = Vector3.zero;
        Instantiate(deadFx).transform.position = transform.position;
        targetNow = null;
    }

    private IEnumerator FindNext()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            if (targetNow != null)
            {
                continue;
            }

            Enemy[] enemyList = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            if(enemyList.Length < 1)
            {
                continue;
            }

            List<Enemy> list = new List<Enemy>();
            foreach (Enemy enemy in enemyList)
            {
                if (enemy != null && !enemy.dead && enemy.gameObject.activeSelf)
                {
                    list.Add(enemy);
                }
            }

            if(list.Count < 1)
            {
                continue;
            }
            targetNow = list[Random.Range(0, list.Count)].transform;
        }
    }
}
