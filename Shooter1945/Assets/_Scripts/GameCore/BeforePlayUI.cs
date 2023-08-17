using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforePlayUI : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private List<GameObject> gameObjects;
    [SerializeField]
    private Player player;
    [SerializeField]
    private EnemySpawner spawner;
    [SerializeField]
    private Item item;
    [SerializeField]
    private GameObject starting;
    [SerializeField]
    private InputManager inputManager;

    public static int modelIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(int index)
    {
        modelIndex = index;
        gameObject.SetActive(false);
        starting.SetActive(true);
        Invoke("GameStart", 3f);
    }
    private void GameStart()
    {
        starting.SetActive(false);
        PlayerModel model = Instantiate(models[modelIndex]).GetComponent<PlayerModel>();
        if (player.model != null)
        {
            Destroy(player.model.gameObject);
        }
        player.model = model;
        model.transform.position = player.transform.position;
        model.transform.SetParent(player.transform);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);

        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
        spawner.Init();
        item.ItemReset();
        item.Init();
        player.PlayerStart();
        inputManager.Init();
    }
}
