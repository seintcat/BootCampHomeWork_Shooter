using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Vector3 moving = new Vector3();
    public static bool shoot = false;

    [SerializeField]
    private bool useJoystick = false;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private JoystickHandler handler;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (useJoystick)
        {
            moving = new Vector3(joystick.Horizontal, joystick.Vertical, 0).normalized;
        }
        else
        {
            moving = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shoot = true;
                Player.FireOn();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                shoot = false;
            }
        }
    }

    public void Init()
    {
        handler.gameObject.SetActive(true); 
        handler.Init();
    }

    public void ButtonDown()
    {
        shoot = true;
        Player.FireOn();
    }
    public void ButtonUp()
    {
        shoot = false;
    }
}
