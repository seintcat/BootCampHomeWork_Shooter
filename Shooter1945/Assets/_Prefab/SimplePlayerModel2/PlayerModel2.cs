using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModel2 : PlayerModel
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Image bar;
    [SerializeField]
    private int shootInterval;

    private int shootValue;

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
                break;
            case 2:
                canvas.SetActive(true);
                shootValue++;
                bar.fillAmount = (float)shootValue / shootInterval;
                if(shootValue >= shootInterval)
                {
                    shootValue = 0;
                    SimpleBulletMake(2, 0);
                }
                break;
            default:
                level--;
                Shoot();
                break;
        }
    }
}
