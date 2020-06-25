using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ToNextLevel : MonoBehaviour
{
    private string NextScene;
    private Statistic s;
    void Start()
    {   
        s=Statistic.getInstance();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        NextScene=s.getNextScene();
    }

    void OnClick()
    {
        if(s.getMap()+1<5)
        s.setMap(s.getMap()+1);

        SceneManager.LoadScene("scene2");
    }

}
