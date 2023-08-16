using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActor : MonoBehaviour
{
    [SerializeField]
    protected int hp = 3;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected GameObject deadFx;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    private float deathTime = 3;

    protected IEnumerator fire;
    protected List<GameObject> collisionOthers;
    private IEnumerator immortalTime;

    public bool dead
    {
        get 
        { 
            return hp < 1; 
        }
    }

    protected virtual void Init()
    {
        collisionOthers = new List<GameObject>();
        immortalTime = ImmortalTime();
        StartCoroutine(immortalTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ImmortalTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            collisionOthers.Clear();
        }
    }

    protected void Death()
    {
        if (fire != null)
        {
            StopCoroutine(fire);
        }
        StopCoroutine(immortalTime);
        foreach (Collider col in GetComponentsInChildren<Collider>())
        {
            col.enabled = false;
        }
        enabled = false;

        animator.Play("Death");
        Instantiate(deadFx).transform.position = transform.position;
        Destroy(gameObject, deathTime);
    }
}
