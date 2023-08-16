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
        switch (level)
        {
            case 0:
                SimpleBulletMake(0, 0);
                break; 
            case 1:
                SimpleBulletMake(1, 0);
                SimpleBulletMake(0, 1);
                SimpleBulletMake(0, 2);
                break;
            case 2:
                SimpleBulletMake(2, 0);
                break;
            default:
                level--;
                Shoot();
                break;
        }
    }
}
