using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int hp = 3;
    [SerializeField]
    protected int collisionDamage = 1;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected List<Transform> firePos;

    protected IEnumerator fire;

    protected void Init()
    {
        if(fire != null)
        {
            StartCoroutine(fire);
        }
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
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
