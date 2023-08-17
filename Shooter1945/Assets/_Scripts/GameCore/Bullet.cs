using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Dictionary<GameObject, List<GameObject>> bulletPool = new Dictionary<GameObject, List<GameObject>>();

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

    public virtual void Init()
    {

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
        if(!rb.isKinematic)
        {
            rb.velocity = Vector3.zero;
        }
        TrailRenderer trail = gameObject.GetComponentInChildren<TrailRenderer>();
        if(trail != null)
        {
            trail.Clear();
            trail.emitting = false;
        }
        gameObject.SetActive(false);
    }

    public static GameObject Pooling(GameObject prefab)
    {
        if (!bulletPool.ContainsKey(prefab))
        {
            bulletPool.Add(prefab, new List<GameObject>());
        }

        GameObject instance;
        if (bulletPool[prefab].Count < 1)
        {
            instance = Instantiate(prefab);
            bulletPool[prefab].Add(instance);
            return instance;
        }
        foreach (GameObject obj in bulletPool[prefab])
        {
            if(!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        instance = Instantiate(prefab);
        bulletPool[prefab].Add(instance);
        return instance;
    }
}
