using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Item : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public State state = State.OnGround;
    public ItemType type;
    public float Damage;
    public PlayerTeam team = PlayerTeam.Null;
    public float Speed;

    Vector2 attackVelocity;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        
    }
    private void Awake()
    {
        switch (type)
        {
            case ItemType.Stone:
                Damage = 20;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (state == State.OnAttack)
        {
            Attack();
        }
       
    }
   public void Attack()
    {
        transform.position += new Vector3(attackVelocity.x*Speed*Time.deltaTime , attackVelocity.y*Speed*Time.deltaTime , 0);
    }
    public void AttackVelocity(Vector2 vel)
    {
        attackVelocity = vel;
        attackVelocity = Vector3.Normalize(attackVelocity);
        state = State.OnAttack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == State.OnAttack)
        {
            
            if (collision.tag == "Wall")
            {
                state = State.OnGround;
                team = PlayerTeam.Null;
            }
        }
        
    }

    public enum ItemType
    {
        Stone,
    }

    public enum State
    {
        OnGround,OnPlayer,OnAttack
    }


}
