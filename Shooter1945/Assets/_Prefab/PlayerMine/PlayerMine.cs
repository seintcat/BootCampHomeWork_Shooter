using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Bullet
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private Animator _animator;

    private IEnumerator enumerator;

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
        if(enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
        _collider.isTrigger = false;
        rb.angularVelocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        enumerator = TimeOver(5f);
        StartCoroutine(enumerator);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collider.isTrigger = true;
        _animator.Play("Fire");

        Invoke("SetActiveFalse", 0.5f);
    }

    public void Fire()
    {
        Instantiate(deadFx).transform.position = transform.position;
    }

    public IEnumerator TimeOver(float time)
    {
        yield return new WaitForSeconds(time);

        if(!_collider.isTrigger)
        {
            _collider.isTrigger = true;
            _animator.Play("Fire");
            Invoke("SetActiveFalse", 0.5f);
        }
    }

    private void OnDisable()
    {
        SetActiveFalse();
    }

    private void SetActiveFalse()
    {
        if (parent.gameObject.activeSelf)
        {
            parent.gameObject.SetActive(false);
        }
    }
}
