using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	
    public float shakeLevel = 3f;// 震动幅度
	public float setShakeTime = 0.5f;	// 震动时间
	public float shakeFps = 45f;	// 震动的FPS
 
	private bool isshakeCamera = false;// 震动标志
	private float fps;
	private float shakeTime = 0.0f;
	private float frameTime = 0.0f;
	private float shakeDelta = 0.005f;
	private Camera selfCamera;
    public Transform playerTransform; // 移动的物体
    public Vector3 deviation; // 偏移量
	private Statistic s;
	private int point;
    int enemyHp=10;
    // Start is called before the first frame update
    void Start()  
    {
		s = Statistic.getInstance();
        deviation = transform.position - playerTransform.position; // 初始物体与相机的偏移量=相机的位置 - 移动物体的偏移量
		point = s.getPoint();
        // enemyHp=GameObject.Find("RPG-enemy R").GetComponent<EnemyHealth>().enemyHp;
        // Debug.Log("hp"+GameObject.Find("RPG-enemy R").GetComponent<EnemyHealth>().enemyAttack);  
    
    }
    //开始震屏
    void OnEnable()
    {
        isshakeCamera = true;
        selfCamera = gameObject.GetComponent<Camera>();
        shakeTime = setShakeTime;
        fps = shakeFps;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }
    //结束震屏
     void OnDisable()
    {
        selfCamera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        isshakeCamera = false;
    }
    // Update is called once per frame
    void Update()
    {
	
     transform.position = playerTransform.position + deviation; // 相机的位置 = 移动物体的位置 + 偏移量
	if(point != s.getPoint())
		{
			point = s.getPoint();
            OnEnable();
		}	
    //震屏效果
    if (isshakeCamera)
		{
			if (shakeTime > 0)
			{
				shakeTime -= Time.deltaTime;
				if (shakeTime <= 0)
				{
					enabled = false;
				}
				else
				{
					frameTime += Time.deltaTime;
 
					if (frameTime > 1.0 / fps)
					{
						frameTime = 0;
						selfCamera.rect = new Rect(shakeDelta * (-1.0f + shakeLevel * Random.value), shakeDelta * (-1.0f + shakeLevel * Random.value), 1.0f, 1.0f);    
                    }
				}
                OnDisable();
            }
            
		}

    }
}
