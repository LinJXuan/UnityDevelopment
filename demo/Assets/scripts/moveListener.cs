using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveListener : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private int state;
    public void setState(int i)
    {
        state = i;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(state);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject.Find("RPG-Character").GetComponent<RpgScript>().setState(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
