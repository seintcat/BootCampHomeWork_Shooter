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
    [SerializeField]
    private RectTransform handle;

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
        SizeResetByAnchor(background);
        background.anchorMin = Vector2.zero;
        background.anchorMax = Vector2.zero;
        background.offsetMin = Vector2.zero;
        background.offsetMax = new Vector2(wrapper.rect.width, wrapper.rect.height);

        SizeResetByAnchor(handle);
        handle.anchorMin = Vector2.zero;
        handle.anchorMax = Vector2.zero;
        handle.offsetMin = Vector2.zero;
        handle.offsetMax = new Vector2(wrapper.rect.width / 2, wrapper.rect.height / 2);
    }

    private void SizeResetByAnchor(RectTransform rect)
    {
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = new Vector2(1, 1);
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }
}
