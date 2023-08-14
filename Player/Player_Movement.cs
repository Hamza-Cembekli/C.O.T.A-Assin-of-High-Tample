using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Vector2 direction;

   
    public float input;
    public Animator anim;
    public float MoveSpeed;
    public float JumpForce;
    public Rigidbody2D rb;
    
    public LayerMask ground;
    public LayerMask enemy;
    public int jumpble;
    public bool canMove;
    public int direction1;
    private CapsuleCollider2D coll;
    public float nexttimetoattack;
    public float Interval;
    public float nexttimetodash;
    public float Interval_dash;
    public int attacking;


    void Start()
    {
        coll = GetComponent<CapsuleCollider2D>();
        direction1 = 1;
        direction = Vector2.right;
        canMove = true;
        jumpble = 2;
        attacking = 0;
    }


    private bool isGrounded()
    {
        
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);


    }

    void Update()
    {
       

        if (canMove == true)
        {
            input = Input.GetAxis("Horizontal");
        }
        else
        {
            input = 0;
        }

        anim.SetFloat("Move", input);
        if (input < 0)
        {
            direction1 = -1;
            direction = Vector2.left;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (input > 0)
        {
            direction1 = 1;
            direction = Vector2.right;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        rb.velocity = new Vector2(input * MoveSpeed, rb.velocity.y);




        if (isGrounded())
        {

            anim.SetBool("isGrounded", true);
            jumpble = 2;
            anim.SetBool("jumped", false);
            if (Input.GetKeyDown(KeyCode.R)) { anim.SetTrigger("Drink_pot1"); }
            if (Input.GetKeyDown(KeyCode.F)) { anim.SetTrigger("Drink_pot2"); }
            if (Input.GetKeyDown(KeyCode.Mouse1)) { anim.SetTrigger("Spell1"); }
            if (Input.GetKeyDown(KeyCode.Q)) { anim.SetTrigger("Spell2"); }
        }
        else { anim.SetBool("isGrounded", false); }


        if (jumpble > 0)
        {
            





            {
                anim.SetTrigger("Jump");
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + JumpForce);
                jumpble -= 1;
                anim.SetBool("jumped",true);
            }
        }





        if (nexttimetodash > 0)
        {
            nexttimetodash -= Time.deltaTime;

        }
        else if (nexttimetodash <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                anim.SetTrigger("Dash");
                nexttimetodash = Interval_dash;


            }
            /*if (nexttimetoattack > 0)
            {
                nexttimetoattack -= Time.deltaTime;
            nexttimetoattack = Interval;
            }
            else if (nexttimetoattack <= 0)
            {
             
            }*/
            if (attacking == 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    anim.SetTrigger("Attack");
                    canMove = false;
                    attacking++;
                }
            }
            else if (attacking == 1)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    anim.SetTrigger("attack2");
                    attacking++;

                }
            }
            else if ( attacking == 2)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    anim.SetTrigger("attack2_2");
                    attacking++;

                }
            }
            else if ( attacking == 3)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    anim.SetTrigger("attack3");
                    

                }
            }
        }
    }

    public void combobreak()
    {
        attacking = 0;
    }

    public void Attack()
    {
        //arka arkaya iki düþmana vurulmasýný istiycek olursam buradaki kodu deðiþtirmeliyim
        canMove = true;
        RaycastHit2D hits = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y+2f,transform.position.z),new Vector3(direction1,0,0), 2f, enemy);
        hits.collider.gameObject.GetComponent<Box>().TakeDamage();

   }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 direct = transform.TransformDirection(Vector2.right) * 5;
        Gizmos.DrawRay(new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Vector2.right);
    }*/

    public void dash_End()
    {
        
        if (direction == Vector2.right)
        {
            transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        }
        if (direction == Vector2.left)
        {
            transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        }
    }


  

}
