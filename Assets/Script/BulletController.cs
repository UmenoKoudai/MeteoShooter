using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int _movespeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.up * _movespeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 12f || transform.position.y <= -20f)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Target" || collision.gameObject.tag == "Plate" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
