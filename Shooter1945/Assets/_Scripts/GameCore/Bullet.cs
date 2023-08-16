using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected GameObject deadFx;
    [SerializeField]
    protected AudioClip startSound;

    public static void PlayerDeath()
    {
        Bullet[] bullets = FindObjectsByType<Bullet>(FindObjectsSortMode.None);
        foreach (Bullet b in bullets)
        {
            b.EndSelf();
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

    protected void EndSelf()
    {
        Instantiate(deadFx).transform.position = transform.position;
        Destroy(gameObject);
    }
}
