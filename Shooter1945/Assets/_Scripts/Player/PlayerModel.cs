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
        Transform bullet = Instantiate(bullets[prefIndex]).transform;
        bullet.position = gunPos[gunPosIndex].position;
        bullet.rotation = gunPos[gunPosIndex].rotation;

        return bullet;
    }
}
