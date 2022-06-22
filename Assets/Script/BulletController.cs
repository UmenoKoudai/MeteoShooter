using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int _movespeed;
    public float _timer;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _movespeed;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (transform.position.y >= 12f || transform.position.y <= -20f || _timer >= 5f)
        {
            Destroy(gameObject);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Target" )
        {
            Destroy(gameObject);
        }
        
    }
}
