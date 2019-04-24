using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float MaxHp = 100;
    public float Hp;
    public int PlayerNumber;
    public int StarCnt = 10;
    public PlayerTeam team;
    public static bool IsBoss = false;
    public GameObject UI;
    public float AgonyTime = 3;

    public int gettedStar = 0;


    public static List<int> controllerNum = new List<int>()
    {
        0,1,2,3,4,5,6,7,8
    };
    int ctrNum = 1;

    List<Vector3> UIPos = new List<Vector3>()
    {
           new Vector3(50,0,0),new Vector3(Screen.width/2,0,0)
    };


    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    float triggerAgonyTime = 0;
    Vector2 attackVelocity;
    private int CoinCnt = 0;

    private bool isInvincible = false;
    private bool isHoldItem = false;
    private PlayerState state = PlayerState.Normal;


    float x;           //controller x
    float y;           //controller y


    bool isControllerOK = false;

    GameObject attackItem;

    // Start is called before the first frame update
    void Start()
    {
        Awake();

        Hp = MaxHp;
        state = PlayerState.Normal;
        switch (PlayerNumber)
        {
            case 1: team = PlayerTeam.P1; m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("takoController"); break;
            case 2: team = PlayerTeam.P2; m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("robotController"); break;
            case 3: team = PlayerTeam.P3; m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("GreenMonsterController"); break;
            case 4: team = PlayerTeam.P4; m_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("StoneManController"); break;

            default:
                break;
        }
        UI = transform.GetChild(0).GetChild(0).gameObject;

    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == PlayerState.Normal)
        {
            Move();
            HoldOnItem();
            Attack();
            if (Hp == 0)
            {
                state = PlayerState.Dead;
                m_rigidbody2D.velocity = Vector2.zero;
                if (gettedStar != 0 && team != PlayerTeam.Boss)
                {
                    int dropstar = 0;
                    if (gettedStar == 1)
                    {
                        dropstar = 1;
                        gettedStar -= dropstar;

                    }
                    else
                    {
                        dropstar = Mathf.FloorToInt(gettedStar / 2);
                        gettedStar -= dropstar;
                    }


                }
            }
        }
        else if (state == PlayerState.Dead && !IsBoss)
        {
            triggerAgonyTime += Time.deltaTime;
            Hp += MaxHp / AgonyTime * Time.deltaTime;
            if (triggerAgonyTime >= AgonyTime)
            {
                state = PlayerState.Normal;
                triggerAgonyTime = 0;
            }
        }

        if (gettedStar == StarCnt && transform.localScale.x <= 6 && !IsBoss)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            team = PlayerTeam.Boss;
            Hp = MaxHp;

        }
        if (transform.lossyScale.x > 6)
        {
            IsBoss = true;
        }
        if (transform.localScale.x >= 5 && m_boxcollier2D.size.x > 0.6f)
        {
            m_boxcollier2D.size /= 2;
        }
        if (team == PlayerTeam.Boss && UI.transform.localScale.x <= 1.5)
        {
            UI.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        
        m_animator.SetFloat("Hp", Hp);



        Hp = Mathf.Clamp(Hp, 0, MaxHp);


        if (isControllerOK)
        {
            print(PlayerNumber + "   " + ctrNum);

        }
        



    }



    void Move()
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        if (!isControllerOK)
        {
            x = Input.GetAxis(controllerNum[ctrNum].ToString() + "Horizontal");
            y = Input.GetAxis(controllerNum[ctrNum].ToString() + "Vertical");
            if (x == 0 && y == 0)
            {
                ctrNum++;
                if (ctrNum == controllerNum.Count)
                {
                    ctrNum = 1;
                }
            }
            else
            {
                if (PlayerNumber == 1&&controllerNum.Count==9)
                {
                    ctrNum = controllerNum[ctrNum];
                    controllerNum.Remove(ctrNum);
                    isControllerOK = true;
                }
                if (PlayerNumber == 2 && controllerNum.Count == 8)
                {
                    ctrNum = controllerNum[ctrNum];
                    controllerNum.Remove(ctrNum);
                    isControllerOK = true;
                }
                if (PlayerNumber == 3 && controllerNum.Count == 7)
                {
                    ctrNum = controllerNum[ctrNum];
                    controllerNum.Remove(ctrNum);
                    isControllerOK = true;
                }
                if (PlayerNumber == 4 && controllerNum.Count == 6)
                {
                    ctrNum = controllerNum[ctrNum];
                    controllerNum.Remove(ctrNum);
                    isControllerOK = true;
                }
            }
        }
        else
        {
            x = Input.GetAxis(ctrNum.ToString() + "Horizontal");
            y = Input.GetAxis(ctrNum.ToString() + "Vertical");
            m_rigidbody2D.velocity = new Vector2(x * maxSpeed, y * maxSpeed);
        }













        if (Mathf.Abs(x) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(x) == 1 ? 180 : 0, rot.z);
        }



        if (m_rigidbody2D.velocity != Vector2.zero)
        {
            m_animator.SetBool("ismove", true);

        }
        else
        {
            m_animator.SetBool("ismove", false);
        }
        if (m_rigidbody2D.velocity != Vector2.zero)
        {
            attackVelocity = m_rigidbody2D.velocity;
        }
    }

    void OnFinishedInvincibleMode()
    {

    }
    void HoldOnItem()
    {
        if (attackItem != null)
        {
            attackItem.transform.position = transform.position + new Vector3(0, 2, 0);

        }
    }
    void Attack()
    {
        if (attackItem != null && attackItem.GetComponent<Item>().state == Item.State.OnPlayer)
        {
            if (Input.GetButtonDown(ctrNum.ToString()+"Fire"))
            {
                attackItem.GetComponent<Item>().AttackVelocity(attackVelocity);
                attackItem = null;
            }
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "PointStar" && gettedStar < StarCnt)
        {
            gettedStar++;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Item")
        {
            switch (collision.gameObject.GetComponent<Item>().state)
            {
                case Item.State.OnGround:
                    if (Input.GetButtonDown(ctrNum.ToString()+"HoldOn") && attackItem == null)
                    {
                        attackItem = collision.gameObject;
                        collision.gameObject.GetComponent<Item>().team = team;
                        collision.gameObject.GetComponent<Item>().state = Item.State.OnPlayer;
                    }
                    break;

                case Item.State.OnAttack:
                    if (collision.gameObject.GetComponent<Item>().team != team)
                    {
                        if (state == PlayerState.Normal)
                        {
                            Hp -= collision.gameObject.GetComponent<Item>().Damage;
                        }

                        Destroy(collision.gameObject);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public enum PlayerTeam
    {
        P1, P2, P3, P4, Boss, Team, Null
    }


    enum PlayerState
    {
        Normal, Damaged, Dead
    }
}
