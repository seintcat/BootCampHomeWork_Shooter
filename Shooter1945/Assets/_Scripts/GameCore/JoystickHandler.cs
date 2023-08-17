using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JoystickHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform wrapper;
    [SerializeField]
    private RectTransform background;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        background.anchorMin = Vector2.zero;
        background.anchorMax = new Vector2(1, 1);
        background.offsetMin = Vector2.zero;
        background.offsetMax = Vector2.zero;

        background.anchorMin = Vector2.zero;
        background.anchorMax = Vector2.zero;
        background.offsetMin = Vector2.zero;
        background.offsetMax = new Vector2(wrapper.rect.width, wrapper.rect.height);
    }
}
