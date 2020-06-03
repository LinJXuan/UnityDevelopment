using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class skillListener : MonoBehaviour, IPointerUpHandler,IPointerClickHandler
{
    private int state;
    private RpgScript playerState;

    public void setState(int i)
    {
        state = i;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
