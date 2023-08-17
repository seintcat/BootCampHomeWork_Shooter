using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActor : MonoBehaviour
{
    [SerializeField]
    protected int maxHp = 3;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected GameObject deadFx;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    private float deathTime = 1.5f;

    protected IEnumerator fire;
    protected List<GameObject> collisionOthers;
    protected int hpNow;
    private IEnumerator immortalTime;

    public bool dead
    {
        get 
        { 
            return maxHp < 1; 
        }
    }

    protected virtual void Init()
    {
        foreach (Collider col in GetComponentsInChildren<Collider>())
        {
            col.enabled = true;
        }
        enabled = true;
        hpNow = maxHp;
        collisionOthers = new List<GameObject>();
        immortalTime = ImmortalTime();
        StartCoroutine(immortalTime);
        rb.angularVelocity = Vector3.zero;
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

        if(animator != null)
        {
            animator.Play("Death");
        }
        Instantiate(deadFx).transform.position = transform.position;

        SetActiveFalse(this, deathTime);
    }

    public static void SetActiveFalse(GameActor obj, float deathTime)
    {
        obj.Invoke("_SetActiveFalse", deathTime);
    }
    private void _SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
