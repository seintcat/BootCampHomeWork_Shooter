using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerLightningBullet : Bullet
{
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private TrailRenderer trail;
    [SerializeField]
    Collider _collider;
    [SerializeField]
    Animator animator;

    private List<Enemy> enemyList;
    private List<Transform> particles;
    private int nextIndex;
    private IEnumerator enumerator;

    private void Awake()
    {
        particles = new List<Transform>();
        enemyList = new List<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Init()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
        _collider.enabled = true;
        trail.emitting = true;
        if(!animator.enabled )
        {
            animator.enabled = true;
        }
        animator.Play("Idle");
        if (startSound != null)
        {
            AudioManager.PlayOneShot(startSound);
        }
        if(enemyList != null)
        {
            enemyList.Clear();
        }
        Enemy[] enemyArray = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy enemy in enemyArray)
        {
            if (enemy.gameObject.activeSelf && !enemy.dead)
            {
                enemyList.Add(enemy);
            }
        }
        if (enemyList == null || enemyList.Count < 1)
        {
            this.StopAllCoroutines();
            EndSelf();
            return;
        }

        nextIndex = 0;
        particles.Add(Instantiate(particle).transform);
        particles[particles.Count - 1].transform.position = transform.position;
        Invoke("NextEnemy", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        NextEnemy();
    }

    private void NextEnemy()
    {
        if (nextIndex < enemyList.Count)
        {
            if (enemyList[nextIndex] == null || enemyList[nextIndex].dead || !enemyList[nextIndex].gameObject.activeSelf)
            {
                nextIndex++;
                NextEnemy();
                return;
            }
            particles.Add(Instantiate(particle).transform);
            particles[particles.Count - 1].transform.position = transform.position;
            transform.position = enemyList[nextIndex].transform.position;
            nextIndex++;
            return;
        }

        // Death
        _collider.enabled = false;
        trail.emitting = false;
        this.StopAllCoroutines();
        if (gameObject.activeSelf)
        {
            animator.Play("Death");
        }

        enumerator = EndThis(1f);
        StartCoroutine(enumerator);
    }

    private IEnumerator EndThis(float time)
    {
        yield return new WaitForSeconds(time);
        if (particles != null && particles.Count > 0)
        {
            foreach (Transform t in particles)
            {
                Destroy(t.gameObject);
            }
            particles.Clear();
        }
        EndSelf();
    }

    private void OnDisable()
    {

    }
}
