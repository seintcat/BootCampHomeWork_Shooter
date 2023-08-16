using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    private Enemy[] enemyList;
    private List<Transform> particles;
    private int nextIndex;

    private void Awake()
    {
        trail.emitting = true;
        particles = new List<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startSound != null)
        {
            AudioManager.PlayOneShot(startSound);
        }
        enemyList = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        if (enemyList == null || enemyList.Length < 1)
        {
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
        if (nextIndex < enemyList.Length)
        {
            if (enemyList[nextIndex] == null || enemyList[nextIndex].dead)
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
        foreach(Transform t in particles)
        {
            t.transform.SetParent(transform);
        }
        _collider.enabled = false;
        animator.Play("Death");
        Invoke("EndSelf", 1f);
    }
}
