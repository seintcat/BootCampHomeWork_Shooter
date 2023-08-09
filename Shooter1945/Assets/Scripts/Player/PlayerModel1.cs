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
        Transform _bullet = Instantiate(bullet).transform;
        _bullet.position = gunPos[0].position;
        _bullet.rotation = gunPos[0].rotation;
    }
}
