using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ItemController : ItemBase
{
    [SerializeField] int _score;
    [SerializeField] int _hp;
    [SerializeField] float _damage;
    [SerializeField] GameObject _particle;
    [SerializeField] GameObject _audio;
    [SerializeField] Text _Hpgauge;

    public int HP
    {
        get
        {
            return _hp;
        }
    }

    private void Update()
    {
        _Hpgauge.text = $"{_hp}";
        ItemDestroy(_hp);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _hp--;
        }
    }

    public override void Activate()
    {
        Instantiate(_particle, transform.position, transform.rotation);
        Instantiate(_audio, transform.position, transform.rotation);
        FindObjectOfType<GameManager>().AddScore(_score);
    }
    public override void Damage()
    {
        FindObjectOfType<GameManager>().DamageGauge(_damage);
    }
}
