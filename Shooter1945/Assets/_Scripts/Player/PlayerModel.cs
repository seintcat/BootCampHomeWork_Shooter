using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerModel : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> bullets;

    [HideInInspector]
    public int level;

    public List<Transform> gunPos;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Shoot();

    protected Transform SimpleBulletMake(int prefIndex, int gunPosIndex)
    {
        Transform trans = Bullet.Pooling(bullets[prefIndex]).transform;
        trans.position = gunPos[gunPosIndex].position;
        trans.rotation = gunPos[gunPosIndex].rotation;
        Bullet bullet = trans.gameObject.GetComponent<Bullet>();
        if (bullet == null)
        {
            bullet = trans.gameObject.GetComponentInChildren<Bullet>();
        }
        if (bullet == null)
        {
            bullet = trans.gameObject.GetComponentInParent<Bullet>();
        }
        bullet.Init();
        return trans;
    }
}
