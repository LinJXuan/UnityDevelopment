using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMap3: MonoBehaviour {

    private Statistic statistic;
	void Start () {
        statistic=Statistic.getInstance();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        statistic.setMap(3);
        SceneManager.LoadScene("Scene2");//level1为我们要切换到的场景
    }


}
