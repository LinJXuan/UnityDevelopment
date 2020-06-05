using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveRight : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private RpgScript playerState;
    private CheckEnemy checkEnemy;

    public void OnPointerDown(PointerEventData eventData)
    {
        checkEnemy.IsMoving(true,-2);
        playerState.setState(-2);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkEnemy.IsMoving(false,0);
        playerState.setState(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerState = GameObject.Find("RPG-Character").GetComponent<RpgScript>();
        checkEnemy = GameObject.Find("RPG-Character").GetComponent<CheckEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
