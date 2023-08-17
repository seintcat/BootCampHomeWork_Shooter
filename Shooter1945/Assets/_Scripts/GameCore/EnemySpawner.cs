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

    private static List<IEnumerator> spawners;

    private static EnemySpawner instance;

    public static void PlayerDeath()
    {
        foreach (IEnumerator job in spawners)
        {
            instance.StopCoroutine(job);
        }
        instance.gameObject.SetActive(false);
    }
    public void Init()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(spawners != null)
        {
            spawners.Clear();
        }
        spawners = new List<IEnumerator>();
        foreach (float pos in instance.spawnPos)
        {
            spawners.Add(instance.Spawn(pos, instance.spawnTimeMinMax.x, instance.spawnTimeMinMax.y));
        }
        foreach (IEnumerator job in spawners)
        {
            StartCoroutine(job);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

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
            GameObject enemy = ObjectPoolingManager.Pooling(enemyList[Random.Range(0, enemyList.Count)]);
            Vector3 pos =  transform.position;
            pos.x += offset;
            enemy.transform.position = pos;
            enemy.GetComponent<Enemy>().EnemyInit();
        }
    }
}
