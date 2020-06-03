using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveListener : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private int state;
    private RpgScript playerState;

    public void setState(int i)
    {
        state = i;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("move state ===>" + state);
        playerState.setState(state);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerState.setState(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerState = GameObject.Find("RPG-Character").GetComponent<RpgScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
