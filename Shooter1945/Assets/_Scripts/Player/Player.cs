using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : GameActor
{
    public static Player instance;

    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private float shieldTime = 10f;
    [SerializeField]
    private PlayerModel model;
    [SerializeField]
    private Image hpImage;
    [SerializeField]
    GameObject shield;
    [SerializeField]
    private Animator shieldAnimator;

    private int maxHp;
    private IEnumerator shieldOff;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        HPUI.hpNow = 1;
        maxHp = hp;
        animator = GetComponentInChildren<Animator>();
        base.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.Lerp(Vector3.zero, rb.velocity, 0.96f);
        rb.velocity += InputManager.moving * Time.fixedDeltaTime * speed;
    }

    public static void FireOn()
    {
        if (instance.fire != null)
        {
            instance.StopCoroutine(instance.fire);
            instance.fire = null;
        }

        instance.fire = instance.Fire();
        instance.StartCoroutine(instance.fire);
    }
    private IEnumerator Fire()
    {
        while(true)
        {
            model.Shoot();
            yield return new WaitForSeconds(fireRate);

            if (!InputManager.shoot)
            {
                StopCoroutine(fire);
                fire = null;
                yield return null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            switch (other.GetComponent<Item>().index)
            {
                case 0:
                    hp = maxHp;
                    SetHP();
                    break;
                case 1:
                    model.level++;
                    break;
                case 2:
                    shield.SetActive(true);
                    if (shieldOff != null)
                    {
                        if (shieldAnimator.GetCurrentAnimatorStateInfo(0).IsName("Off"))
                        {
                            shieldAnimator.Play("Spawn");
                        }
                        StopCoroutine(shieldOff);
                    }
                    shieldOff = null;
                    shieldOff = ShieldOff();
                    StartCoroutine(shieldOff);
                    break;
            }
            return;
        }

        hp = 0;
        SetHP();
        PlayerDeath();
        WallOutDestroyer.WallTriggerExit(other, gameObject, deadFx);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checking
        if (collisionOthers.Exists(x => x.gameObject == collision.gameObject))
        {
            return;
        }
        collisionOthers.Add(collision.gameObject);

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null && shieldOff == null)
        {
            hp -= enemy.collisionDamage;
        }

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null && shieldOff == null)
        {
            hp -= bullet.damage;
        }

        SetHP();

        if (hp < 1)
        {
            PlayerDeath();
            Death();
        }
    }

    private void SetHP()
    { 
        HPUI.hpNow = Mathf.Clamp( ((float)hp / maxHp), 0f, 1f);
    }

    private void PlayerDeath()
    {
        FxHandler.playerDeath = true;
        StopCoroutine(fire);
        EnemySpawner.PlayerDeath();
        Enemy.PlayerDeath();
        Bullet.PlayerDeath();
        Item.PlayerDeath();
    }

    private IEnumerator ShieldOff()
    {
        yield return new WaitForSeconds(shieldTime - 1f);
        shieldAnimator.Play("Off");
        yield return new WaitForSeconds(1f);
        shield.SetActive(false);
        StopCoroutine(shieldOff);
        shieldOff = null;
    }
}
