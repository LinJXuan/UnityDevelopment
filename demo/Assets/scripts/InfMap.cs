using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfMap : MonoBehaviour
{
    /*
     * 无限地图
     */
    public Transform Player;
    private Vector3 initPosition;
    public List<Transform> roadlist = new List<Transform>();
    public List<Transform> walllist = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        initPosition = Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        infMap();
    }
        public void infMap()
    {
        int lastIndex = roadlist.Count - 1;
        if (Player.position.x - initPosition.x >= 50f)
        {
            roadlist[0].position = roadlist[lastIndex].position + new Vector3(50f, 0, 0);
            walllist[0].position = walllist[lastIndex].position + new Vector3(50f, 0, 0);

            initPosition = Player.position;
            Transform t = roadlist[0];
            roadlist.RemoveAt(0);
            roadlist.Insert(lastIndex, t);
            t = walllist[0];
            walllist.RemoveAt(0);
            walllist.Insert(lastIndex, t);
        }
        else if (Player.position.x-initPosition.x<=-50)
        {
            roadlist[lastIndex].position = roadlist[0].position - new Vector3(50f, 0, 0);
            walllist[lastIndex].position = walllist[0].position - new Vector3(50f, 0, 0);

            initPosition = Player.position;
            Transform t = roadlist[lastIndex];
            roadlist.RemoveAt(lastIndex);
            roadlist.Insert(0, t);
            t = walllist[0];
            walllist.RemoveAt(lastIndex);
            walllist.Insert(0, t);
        }
    }
}
