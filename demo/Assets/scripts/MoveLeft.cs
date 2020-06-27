using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private RpgScript playerState;
    private CheckEnemy checkEnemy;
     //public AudioClip walkSound; 
    //private AudioSource source;

    public void OnPointerDown(PointerEventData eventData)
    {
        //source.PlayOneShot(walkSound, 1F);
        checkEnemy.IsMoving(true,-1);
        playerState.setState(-1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        checkEnemy.IsMoving(false,0);
        playerState.setState(0);
    }

    // Start is called before the first frame update
    void Start()
    {
         //source = GetComponent<AudioSource>();
        playerState = GameObject.Find("RPG-Character").GetComponent<RpgScript>();
        checkEnemy = GameObject.Find("RPG-Character").GetComponent<CheckEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
