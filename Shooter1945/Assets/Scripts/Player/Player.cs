using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int hp = 10;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerModel model;

    private IEnumerator fire;

    // Start is called before the first frame update
    void Start()
    {
        fire = Fire();
        StartCoroutine(fire);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += InputManager.moving * Time.deltaTime * speed;
    }

    private IEnumerator Fire()
    {
        while(true)
        {
            if (InputManager.shoot)
            {
                model.Shoot();
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}
