using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFire : MonoBehaviour
{
    [SerializeField]
    private PlayerMine playerMine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        playerMine.Fire();
    }
}
