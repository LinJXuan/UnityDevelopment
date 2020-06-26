using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ToSameLevel : MonoBehaviour
{

    private Statistic s;
    void Start()
    {   
        s=Statistic.getInstance();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        
    }

    void OnClick()
    {
        
        SceneManager.LoadScene("scene2");
    }

}
