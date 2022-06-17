using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiayerController : MonoBehaviour
{
    [SerializeField] int _movespeed;
    [SerializeField] BulletController _bulletPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _intarval;
    [SerializeField] Transform _addmuzzle1;
    [SerializeField] Transform _addmuzzle2;
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
        var Bullet = _bulletPrefab.GetComponent<BulletController>();
        Bullet._movespeed = _bulletspeed;
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(Vector2.left * _movespeed, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector2.right * _movespeed, ForceMode2D.Force);
        }
        if(_Power <= 0 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
        }
        else if(_Power == 1 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
            _bulletspeed = 20;
            _intarval = .1f;
        }
        else if (_Power == 2 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            _time = 0;
            _bulletspeed = 15;
            _intarval = .3f;
        }
        else if (_Power == 3 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            _time = 0;
            _bulletspeed = 20;
            _intarval = .1f;
        }
        else if (_Power == 4 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
            _bulletspeed = 15;
            _intarval = .3f;
        }
        else if (_Power >= 5 && _time >= _intarval && Input.GetButton("Fire1"))
        {
            Instantiate(_bulletPrefab, _addmuzzle1.position, transform.rotation);
            Instantiate(_bulletPrefab, _addmuzzle2.position, transform.rotation);
            Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
            _time = 0;
            _bulletspeed = 50;
            _intarval = .01f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Power")
        {
            _Power++;
        }
    }
}
