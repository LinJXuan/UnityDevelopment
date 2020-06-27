using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgScript : MonoBehaviour {
    private Animator anim;
    public float speed = 5;
    private bool isRight = true;
    private bool isLeft = false;
    private bool isPlaying = false;
    private bool isAlive = true;
    private bool isGetWeapon2 = false;
    private bool isGetWeapon3 = false;
    private bool isGetShield1 = false;
    private bool isGetShield2 = false;
    private bool isGetShield3 = false;
    public int attackRange = 4;
    public int attackDamage;
    //使用状态控制人物动作
    public enum State { dead, stop, left, right, skillOne, skillTwo, skillThree, skillFour }
    public State currentState = State.stop;

    private int enemyLayer;

    private float barUpLength = 3f;
    public Slider healthSlider;
    public GameObject weaponAex;
    public GameObject weaponSword;
    public GameObject weaponHammer;
    public GameObject Shield1;
    public GameObject Shield2;
    public GameObject Shield3;
    public Button consume1;
    public Button consume2;
    public Button consume3;
    public Button consume4;
    public Button consume5;
    public Button consume6;
    private GameObject tempObj;

    private GameObject btnSWeapon;
    private GameObject btnSShield;
    private int[] weapon = new int[3] { 1, 0, 0 };
    private int[] shield = new int[3] { 0, 0, 0 };
    private int weaponState = 0; //0是剑，1是大锤，2是斧头
    private int shieldState = 0;
    public Vector3 enemyDeathPosition;
    public bool dropWeaponAex = false;
    public bool dropWeaponHammer = false;
    public bool dropShield1 = false;
    public bool dropShield2 = false;
    public bool dropShield3 = false;
    private Player player;
    //突刺攻击有关
    private ArrayList enemys = new ArrayList ();
    private float spurLength = 5;
    //投掷距离
    private float throwLength = 10;
    //投掷范围
    private float throwRange = 3;
    //圣光范围
    private float lightRange = 3;

    //攻击间隔
    public float wCD = 2;
    public float eCD = 3;
    public float rCD = 4;
    private float wTime = 2;
    private float eTime = 3;
    private float rTime = 4;

    //冷却图片
    public Image wCdImg;
    public Image eCdImg;
    public Image rCdImg;
    private CheckEnemy checkEnemy;
    void Start () {
        
        consume1.image.sprite = Resources.Load<Sprite> ("sword");
        switchWeapon (true, false, false);
        switchShield (false, false, false);
        btnSWeapon = GameObject.Find ("switchWeapon");
        btnSShield = GameObject.Find ("switchShield");
        btnSWeapon.GetComponent<Button> ().onClick.AddListener (clickSWeapon);
        btnSShield.GetComponent<Button> ().onClick.AddListener (clickSShield);
        player = Player.getInstance ();
        attackDamage = player.getAttack ();
        anim = GetComponent<Animator> ();
        enemyLayer = LayerMask.GetMask ("Enemy");
        healthSlider.value = GetComponent<PlayerHealth> ().playerHp;
        checkEnemy = GetComponent<CheckEnemy> ();
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;
        consume1.GetComponent<Image> ().color = UnityEngine.Color.yellow;
    }

    // Update is called once per frame
    void Update () {
        attackDamage = player.getAttack();

        //技能CD
        wTime += Time.deltaTime;
        wCdImg.fillAmount = 1 - wTime / wCD;
        eTime += Time.deltaTime;
        eCdImg.fillAmount = 1 - eTime / eCD;
        rTime += Time.deltaTime;
        rCdImg.fillAmount = 1 - rTime / rCD;

        healthSlider.value = GetComponent<PlayerHealth> ().playerHp;
        //shieldSlider.value=GetComponent<PlayerHealth>().playerShield;

        if (currentState == State.dead) {
            anim.SetBool ("dead", true);
        }

        if (!isAlive) {
            currentState = State.dead;
            return;
        }

        if (currentState == State.left) {
            if (!isLeft) {
                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;
                isLeft = true;
                isRight = false;
                print ("转向====> " + transform.rotation);
            }
            anim.SetBool("Walk",true);
            transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime); 
        }

        if (currentState == State.right) {
            if (!isRight) {
                Quaternion playerRotation = transform.localRotation;
                playerRotation.y = -playerRotation.y;
                transform.rotation = playerRotation;
                isRight = true;
                isLeft = false;
                print ("转向====> " + transform.rotation);
            }
            anim.SetBool("Walk",true);
            transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime);
        }

        if(currentState == State.stop)
        {
             
            anim.SetBool("Walk",false);
        }
       
        if(currentState == State.skillOne)
        {
            anim.SetTrigger("Q Trigger");
        }

        if(currentState ==State.skillTwo && wTime >= wCD)
        {
            anim.SetTrigger("W Trigger");
            wTime = 0;
        }

        if (currentState == State.skillThree && eTime >= eCD)
        {
            anim.SetTrigger("E Trigger");
            eTime = 0;
        }

        if (currentState == State.skillFour && rTime >= rCD)
        {
            anim.SetTrigger("R Trigger");
            rTime = 0;
        }

        if (currentState != State.left && currentState != State.right) {
            currentState = State.stop;
        }
        Vector3 worldPos = new Vector3 (transform.position.x, transform.position.y + barUpLength, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint (worldPos);
        //血条位置
        healthSlider.transform.position = new Vector3 (screenPos.x, screenPos.y - 20f, screenPos.z);
        //拾取并切换武器
        if ((int) transform.position.x == (int) enemyDeathPosition.x) {

            if (dropWeaponAex) {
                weapon[2] = 1;
                switchWeapon (false, false, true); //切换成斧头
                weaponState = 2;
                isGetWeapon3 = true;
                consume3.image.sprite = Resources.Load<Sprite> ("aex");
                dropWeaponAex = false;
            }
            if (dropWeaponHammer) {
                weapon[1] = 1;
                switchWeapon (false, true, false); //切换成大锤
                dropShield1 = false;
                isGetWeapon2 = true;
                consume2.image.sprite = Resources.Load<Sprite> ("hammer");
                weaponState = 1;
            }
            if (dropShield1) {
                shield[0] = 1;
                switchShield (true, false, false); //切换成盾牌1
                dropShield1 = false;
                isGetShield1 = true;
                consume4.image.sprite = Resources.Load<Sprite> ("shieldOne1");
                shieldState = 1;
            }
            if (dropShield2) {
                shield[1] = 1;
                switchShield (false, true, false); //切换成盾牌2
                dropShield2 = false;
                isGetShield2 = true;
                consume5.image.sprite = Resources.Load<Sprite> ("shieldOne2");
                shieldState = 2;
            }
            if (dropShield3) {
                shield[2] = 1;
                switchShield (true, false, false); //切换成盾牌3
                dropShield3 = false;
                isGetShield3 = true;
                consume6.image.sprite = Resources.Load<Sprite> ("shieldOne3");
                shieldState = 3;
            }

        }

    }
    public void click1 () {
        switchWeapon (true, false, false); //切换成剑
        consume1.GetComponent<Image> ().color = UnityEngine.Color.yellow;
        consume2.GetComponent<Image> ().color = UnityEngine.Color.white;
        consume3.GetComponent<Image> ().color = UnityEngine.Color.white;
        weaponState = 0;
    }
    public void click2 () {
        if (isGetWeapon2) {
            switchWeapon (false, true, false); //切换成大锤
            consume1.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume2.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume3.GetComponent<Image> ().color = UnityEngine.Color.white;
            weaponState = 1;
        }
    }
    public void click3 () {
        if (isGetWeapon3) {
            switchWeapon (false, false, true); //切换成斧头
            consume1.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume2.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume3.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            weaponState = 2;
        }
    }
    public void click4(){
        if (isGetShield1) {
            switchShield (true, false, false); //切换成盾1
            consume4.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.white;
            shieldState = 1;
        }
    }
    public void click5(){
        if (isGetShield2) {
            switchShield (false, true, false); //切换成盾2
            consume4.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.white;
            shieldState = 2;
        }
    }
    public void click6(){
        if (isGetShield3) {
            switchShield (false, false, true); //切换成盾3
            consume4.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            shieldState = 3;
        }
    }
    public void switchWeapon (bool Sword, bool Hammer, bool Aex) {
        print ("切换武器");
        weaponAex.SetActive (Aex);
        weaponHammer.SetActive (Hammer);
        weaponSword.SetActive (Sword);
        if (Sword) { //设置高亮
            consume1.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume2.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume3.GetComponent<Image> ().color = UnityEngine.Color.white;
        }
        if (Hammer) {
            consume1.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume2.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume3.GetComponent<Image> ().color = UnityEngine.Color.white;
        }
        if (Aex) {
            consume1.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume2.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume3.GetComponent<Image> ().color = UnityEngine.Color.yellow;
        }

    }
    public void switchShield (bool shieldone, bool shieldtwo, bool shieldthree) {
        print ("切换盾牌");
        Shield1.SetActive (shieldone);
        Shield2.SetActive (shieldtwo);
        Shield3.SetActive (shieldthree);
        if (shieldone) { //设置高亮
            consume4.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.white;
        }
        if (shieldtwo) {
            consume4.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.yellow;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.white;
        }
        if (shieldthree) {
            consume4.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume5.GetComponent<Image> ().color = UnityEngine.Color.white;
            consume6.GetComponent<Image> ().color = UnityEngine.Color.yellow;
        }
    }
    public void FootR ()

    {

    }
    public void FootL () {

    }

    public void setState (int i) {
        if (isPlaying) {
            //直接返回
            return;
        }

        checkEnemy.resetdTime ();
        switch (i) {
            case -3:
                currentState = State.dead;
                break;
            case -1:
                currentState = State.left;
                break;
            case -2:
                currentState = State.right;
                break;
            case 0:
                currentState = State.stop;
                break;
            case 1:
                currentState = State.skillOne;
                break;
            case 2:
                currentState = State.skillTwo;
                break;
            case 3:
                currentState = State.skillThree;
                break;
            case 4:
                currentState = State.skillFour;
                break;

        }
    }
    void clickSWeapon () {
        if (weapon[1] == 1 && weapon[2] == 0) {
            switch (weaponState) {
                case 0:
                    switchWeapon (false, true, false);
                    weaponState = 1;
                    break;
                case 1:
                    switchWeapon (true, false, false);
                    weaponState = 0;
                    break;
            }

        }
        if (weapon[1] == 0 && weapon[2] == 1) {
            switch (weaponState) {
                case 0:
                    switchWeapon (false, false, true);
                    weaponState = 2;
                    break;
                case 2:
                    switchWeapon (true, false, false);
                    weaponState = 0;
                    break;
            }

        }
        if (weapon[1] == 1 && weapon[2] == 1) {
            switch (weaponState) {
                case 0:
                    switchWeapon (false, true, false);
                    weaponState = 1;
                    break;
                case 1:
                    switchWeapon (false, false, true);
                    weaponState = 2;
                    break;
                case 2:
                    switchWeapon (true, false, false);
                    weaponState = 0;
                    break;
            }

        }

    }
    void clickSShield () {
        if (shield[0] == 1 && shield[1] == 1 && shield[2] == 0) {
            switch (shieldState) {
                case 1:
                    switchShield (false, true, false);
                    shieldState = 2;
                    break;
                case 2:
                    switchShield (true, false, false);
                    shieldState = 1;
                    break;
            }
        }
        if (shield[0] == 1 && shield[1] == 0 && shield[2] == 1) {
            switch (shieldState) {
                case 1:
                    switchShield (false, false, true);
                    shieldState = 3;
                    break;
                case 3:
                    switchShield (true, false, false);
                    shieldState = 1;
                    break;
            }
        }
        if (shield[0] == 0 && shield[1] == 1 && shield[2] == 1) {
            switch (shieldState) {
                case 2:
                    switchShield (false, false, true);
                    shieldState = 3;
                    break;
                case 3:
                    switchShield (false, true, false);
                    shieldState = 2;
                    break;
            }
        }
        if (shield[0] == 0 && shield[1] == 1 && shield[2] == 1) {
            switch (shieldState) {
                case 2:
                    switchShield (false, false, true);
                    shieldState = 3;
                    break;
                case 3:
                    switchShield (false, true, false);
                    shieldState = 2;
                    break;
            }
        }
        if (shield[0] == 1 && shield[1] == 1 && shield[2] == 1) {
            switch (shieldState) {
                case 1:
                    switchShield (false, true, false);
                    shieldState = 2;
                    break;
                case 2:
                    switchShield (false, false, true);
                    shieldState = 3;
                    break;
                case 3:
                    switchShield (true, false, false);
                    shieldState = 1;
                    break;
            }
        }

    }

    public void playerIsAlive (bool alive) {
        isAlive = alive;
    }

    void AnimatorEventFinishCallBack () {
        isPlaying = false;
        currentState = State.stop;
    }

    void AnimatorEventBeginCallBack () {
        isPlaying = true;
        currentState = State.stop;
    }

    void QHit () {
        Hit ();
    }

    void WHit () {
        throwSkill ();
    }

    void EHit () {
        holyLightSkill ();
    }

    void RHit () {
        spurSkill ();
    }

    public void Hit () {
        Ray attackRay = new Ray ();
        attackRay.origin = transform.position;
        attackRay.direction = transform.forward;
        if (Physics.Raycast (attackRay, out RaycastHit attackHit, attackRange, enemyLayer)) {
            EnemyController EnemyController = attackHit.collider.gameObject.GetComponent<EnemyController> ();
            EnemyController.TakeDamage (attackDamage);
        }
    }
    void DeadFinshCallBack () {
        isPlaying = false;
    }

    public void setMaxHpUi (int maxHp) {
        healthSlider.maxValue = maxHp;
    }

    public void spurSkill () {
        Vector3 spurAttack = gameObject.transform.localPosition;
        Vector3 finalPosition = gameObject.transform.localPosition;
        spurAttack.x += transform.forward.x * spurLength / 2;
        finalPosition.x += transform.forward.x * spurLength;
        Collider[] colliders = Physics.OverlapSphere (spurAttack, spurLength / 2);
        if (colliders.Length == 0) {
            return;
        }
        for (int i = 0; i < colliders.Length; i++) {
            print (colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController> ();
            if (controller != null) {
                //攻击伤害为150%
                controller.TakeDamage (attackDamage + attackDamage / 2);
            }
        }
        gameObject.transform.localPosition = finalPosition;
    }

    public void throwSkill () {
        Vector3 throwAttack = gameObject.transform.localPosition;
        throwAttack.x += transform.forward.x * throwRange / 2;
        Collider[] colliders = Physics.OverlapSphere (throwAttack, throwRange);
        if (colliders.Length == 0) {
            return;
        }
        for (int i = 0; i < colliders.Length; i++) {
            print (colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController> ();
            if (controller != null) {
                //攻击伤害为2000%
                controller.TakeDamage (attackDamage * 2);
            }
        }
    }

    public void holyLightSkill () {
        Vector3 holyLightAttack = gameObject.transform.localPosition;
        Collider[] colliders = Physics.OverlapSphere (holyLightAttack, lightRange);
        if (colliders.Length == 0) {
            return;
        }
        for (int i = 0; i < colliders.Length; i++) {
            print (colliders[i].gameObject.name);
            EnemyController controller = colliders[i].gameObject.GetComponent<EnemyController> ();
            if (controller != null) {
                //攻击伤害为300%
                controller.TakeDamage (attackDamage * 3);
            }
        }
    }
}