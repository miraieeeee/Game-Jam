using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]  //Çok havalı.
public class PlayerMovement : MonoBehaviour
{
    [Range(0,250)]
    public float Velocity;

    [Range(100, 10000)]
    public float JumpSpeed;

    public float hAxis;
    public bool Jump;
    public PlayerAnim playerCandle;
    public bool isDead;
    public bool Jewel;
    public bool endgame;
    public GameObject ObJewel;

    public Rigidbody2D rb2d;

    public Vector3 spawmLoc;
    public GameObject Obj;

    public Vector3[] exit;
    Vector2 JumpEvent(float x, float y, Rigidbody2D z)
    {
        float SpeedWithAirFriction = (y != 0) ? z.velocity.x : 1;
        float aa = (((SpeedWithAirFriction / (z.velocity.y + 1)) * Time.deltaTime * x) + (7000 - (SpeedWithAirFriction / (z.velocity.y + 1)) * Time.deltaTime * x)) - 6920;
        Vector2 result = Vector2.up * aa;
        return result;
    }

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        spawmLoc.x = -220f;
        spawmLoc.y = -37f;

        gameObject.transform.position = spawmLoc;

        Obj = gameObject;
        isDead = false;
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal") * Velocity * Time.deltaTime;

        if (rb2d.velocity.x < -16)
        {
            rb2d.velocity += new Vector2(Velocity * Time.deltaTime, 0);
        }
        else if (rb2d.velocity.x > 16)
        {
            rb2d.velocity -= new Vector2(Velocity * Time.deltaTime, 0);
        }

        rb2d.velocity += new Vector2(hAxis, 0);

        if (Input.GetKeyDown(KeyCode.W) && Jump)
        {
            rb2d.velocity = JumpEvent(JumpSpeed, hAxis, rb2d);
        }

        if (isDead)
        {
            Instantiate(ObJewel, new Vector3(Obj.transform.position.x, Obj.transform.position.y, Obj.transform.position.z), Quaternion.identity);
            Obj.transform.position = spawmLoc;
            isDead = false;
            Jewel = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Jump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
                isDead = true;
        }

        if (collision.gameObject.tag == "Jewel")
        {
            Destroy(collision.gameObject);
            Jewel = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            isDead = true;
        }

        if (collision.gameObject.tag == "Enter")
        {
            int random = Mathf.FloorToInt(Random.Range(0, exit.Length - 1));
            Obj.transform.position = new Vector3(exit[random].x, exit[random].y, Obj.transform.position.z); 
        }

        if (collision.gameObject.name == "finish")
        {
            SceneManager.LoadScene("start");
            endgame = true;
        }
    }
}