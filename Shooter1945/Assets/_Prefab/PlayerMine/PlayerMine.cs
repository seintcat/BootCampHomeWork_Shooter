using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Bullet
{
    [SerializeField]
    private MineFire parent;
    [SerializeField]
    private Collider _collider;
    [SerializeField]
    private Animator _animator;

    private IEnumerator timeOver;

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
        if(timeOver != null)
        {
            StopCoroutine(timeOver);
            timeOver = null;
        }
        _collider.isTrigger = false;
        rb.angularVelocity = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        timeOver = TimeOver(5f);
        StartCoroutine(timeOver);
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
        parent.SetActiveFalse();
    }
}
