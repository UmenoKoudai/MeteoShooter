using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int _movespeed;
    [SerializeField] BulletController _bulletPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] public float _intarval;
    [SerializeField] Transform _addmuzzle1;
    [SerializeField] Transform _addmuzzle2;
    [SerializeField] Transform m_crosshair;
    public Vector2 _move = default;
    int _bulletspeed = 15;
    public int _Power;
    float _time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(_move * _movespeed, ForceMode2D.Force);
        var Bullet = _bulletPrefab.GetComponent<BulletController>();
        Bullet._movespeed = _bulletspeed;
        Vector2 dir = m_crosshair.position - transform.position;
        transform.up = dir;
        AudioSource Shot = GetComponent<AudioSource>();
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    _move = Vector2.left;
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    _move = Vector2.right;
        //}
        //if(_rb.velocity.magnitude >= _rv)
        //{
        //    _rb.velocity = Vector3.zero;
        //}
        if (_Power <= 0 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            Shot.Play();
            _time = 0;
        }
        
        else if (_Power == 1 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            _time = 0;
            _bulletspeed = 15;
            _intarval = .2f;
            Shot.Play();
        }
        
        else if (_Power == 2 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
            _bulletspeed = 15;
            _intarval = .2f;
            Shot.Play();
        }
        else if (_Power >= 3 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
            _bulletspeed = 20;
            _intarval = .1f;
            Shot.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Power")
        {
            _Power += 1;
            Debug.Log("パワーアップ");
        }
    }
}
