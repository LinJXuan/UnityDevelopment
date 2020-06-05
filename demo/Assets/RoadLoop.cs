using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoop : MonoBehaviour
{
    public List<Transform> roadlist = new List<Transform>();
    public List<Transform> arrivePoslist = new List<Transform>();
    public List<Transform> walllist = new List<Transform>();
    public void changeroad(Transform arrivepos,int position)
    {
        int index = arrivePoslist.IndexOf(arrivepos);
        Debug.Log(index);
        if (index >= 0)
        {
            int lastindex = index - 1;
            if (lastindex < 0)
            {
                lastindex = arrivePoslist.Count - 1;
            }

            if (position > 0)
            {
                roadlist[index].position = roadlist[lastindex].position - new Vector3(-50f, 0, 0);
                walllist[index].position = walllist[lastindex].position - new Vector3(-50f, 0, 0);
            }
            else
            {
                roadlist[index].position = roadlist[lastindex].position + new Vector3(-50f, 0, 0);
                walllist[index].position = walllist[lastindex].position + new Vector3(-50f, 0, 0);
            }

        }
    }

}
