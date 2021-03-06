using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    [SerializeField] int _HP;
    [SerializeField] Text _Hpgauge;
    [SerializeField] int _score;
    [SerializeField] GameObject _particle;
    [SerializeField] GameObject _audio;
    GameObject _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        _Hpgauge.text = $"{_HP}";
        if (_HP <= 0)
        {
            Instantiate(_particle, transform.position, transform.rotation);
            Instantiate(_audio, transform.position, transform.rotation);
            _gm.GetComponent<GameManager>().AddScore(_score);
            Destroy(gameObject);
        }
        if(transform.position.y <= -20f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _HP--;
            
        }
    }
}
