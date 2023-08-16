using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Bullet
{
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        rb.angularVelocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        Invoke("TimeOver", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        _collider.isTrigger = true;
        _animator.Play("Fire");
        Destroy(gameObject, 0.5f);
    }

    public void Fire()
    {
        Instantiate(deadFx).transform.position = transform.position;
    }

    public void TimeOver()
    {
        if(!_collider.isTrigger)
        {
            _collider.isTrigger = true;
            _animator.Play("Fire");
            Destroy(gameObject, 0.5f);
        }
    }
}
