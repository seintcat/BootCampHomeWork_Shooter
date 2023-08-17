using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFire : MonoBehaviour
{
    [SerializeField]
    private PlayerMine playerMine;

    private IEnumerator enumerator;

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
        SetActiveFalse();
    }

    private void OnEnable()
    {
        playerMine.gameObject.SetActive(true);
        if(enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
    }

    private IEnumerator MakeDisable()
    {
        yield return new WaitForSeconds(0.5f);
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetActiveFalse()
    {
        if (gameObject.activeSelf)
        {
            enumerator = MakeDisable();
            StartCoroutine(enumerator);
        }
    }
}
