using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<float> spawnPos;
    [SerializeField]
    private Vector2Int spawnTimeMinMax = new Vector2Int(5, 8);
    [SerializeField]
    private List<GameObject> enemyList;

    private List<IEnumerator> spawners;

    public static void PlayerDeath()
    {
        GameObject obj = FindObjectOfType<EnemySpawner>().gameObject;
        if(obj != null)
        {
            Destroy(obj);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawners = new List<IEnumerator>();
        foreach (float pos in spawnPos)
        {
            spawners.Add(Spawn(pos, spawnTimeMinMax.x, spawnTimeMinMax.y));
        }
        foreach (IEnumerator job in spawners)
        {
            StartCoroutine(job);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(float offset, int minTime, int maxTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range((float)minTime, (float)maxTime));
            GameObject enemy = Instantiate(enemyList[Random.Range(0, enemyList.Count)]);
            Vector3 pos =  transform.position;
            pos.x += offset;
            enemy.transform.position = pos;
        }
    }
}
