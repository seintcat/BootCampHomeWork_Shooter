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
        PlayerModel model = Instantiate(models[index]).GetComponent<PlayerModel>();
        player.model = model;
        model.transform.position = player.transform.position;
        model.transform.SetParent(player.transform);

        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
        gameObject.SetActive(false);
        player.PlayerStart();
    }
}
