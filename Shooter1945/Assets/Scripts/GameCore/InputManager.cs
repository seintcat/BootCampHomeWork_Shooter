using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 moving = new Vector3();
    public static bool shoot = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moving = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shoot = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            shoot = false;
        }
    }
}
