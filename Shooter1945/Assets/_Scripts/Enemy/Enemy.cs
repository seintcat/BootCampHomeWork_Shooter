using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : GameActor
{
    public int collisionDamage = 1;

    [SerializeField]
    protected List<Transform> firePos;
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected int hitScore;
    [SerializeField]
    protected int deathScore;

    public static void PlayerDeath()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach(Enemy e in enemies)
        {
            e.Death();
        }
    }

    protected override void Init()
    {
        if (fire != null)
        {
            StartCoroutine(fire);
        }
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            WallOutDestroyer.WallTriggerExit(other, gameObject);
            return;
        }
    }
}
