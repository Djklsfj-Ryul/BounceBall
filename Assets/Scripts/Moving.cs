using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Rigidbody2D rigid;
    int Player = 3;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    float bounce = 15f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.velocity = Vector2.zero;
        Vector2 Jump = new Vector2(0, bounce);

        if (collision.gameObject.tag == "WALL")
        {
            rigid.AddForce(Jump, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "TARGET")
        {
            Player--;
            Debug.Log(Player);
            if (Player == 0)
            {
                Debug.Log("GAME CLEAR");
                Destroy(gameObject);
            }
        }
    }
}
