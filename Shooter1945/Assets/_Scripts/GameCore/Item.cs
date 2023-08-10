using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Vector2Int spawnTimeMinMax;
    [SerializeField]
    private float spawnWidthMinMax;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected List<GameObject> model;
    [SerializeField]
    protected List<GameObject> fx;

    [HideInInspector]
    public int index;

    private Vector3 spawnPos;
    private IEnumerator itemFall;

    public static void PlayerDeath()
    {
        Item item = FindObjectOfType<Item>();
        Instantiate(item.fx[item.index]).transform.position = item.transform.position;
        Destroy(item.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        ItemStarting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ItemFall()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimeMinMax.x, spawnTimeMinMax.y));
        index = Random.Range(0, model.Count);
        rb.angularVelocity = Vector3.up * 10;
        model[index].SetActive(true);
        rb.velocity = Vector3.down * 1.5f;
        if(itemFall != null)
        {
            StopCoroutine(itemFall);
            itemFall = null;
        }
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            return;
        }
        Instantiate(fx[index]).transform.position = transform.position;
        ItemReset();
    }

    private void OnTriggerExit(Collider other)
    {
        ItemReset();
    }

    private void ItemReset()
    {
        if (!model[index].activeSelf)
        {
            return;
        }
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(spawnPos.x + Random.Range(-spawnWidthMinMax, spawnWidthMinMax), spawnPos.y, spawnPos.z);
        model[index].SetActive(false);
        ItemStarting();
    }

    private void ItemStarting()
    {
        if(itemFall != null)
        {
            return;
        }
        itemFall = ItemFall();
        StartCoroutine(itemFall);
    }
}
