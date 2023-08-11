using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel1 : PlayerModel
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        Transform _bullet;
        switch (level)
        {
            case 0:
                SimpleBulletMake(0, 0);
                break; 
            case 1:
                SimpleBulletMake(1, 0);
                _bullet = SimpleBulletMake(0, 1);
                _bullet.Rotate(new Vector3(0, -45, 0), Space.Self);
                _bullet = SimpleBulletMake(0, 2);
                _bullet.Rotate(new Vector3(0, 45, 0), Space.Self);
                break; 
            //case 2:
            //    break;
            default:
                level--;
                Shoot();
                break;
        }
    }
}
