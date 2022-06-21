using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image _garbage;
    [SerializeField] Text _sc;
    [SerializeField] Text _tt;
    [SerializeField] Text _cs;
    [SerializeField] Text _bs;
    [SerializeField] GameObject _GameOver;
    [SerializeField] GameObject _GameClear;
    GameObject _pc;
    GameObject _ca;
    public BoxCollider2D col;
    float _timer;
    int _hp;
    public static int m_score;
    int _hiscore;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GameObject.Find("Canon");
        _ca = GameObject.Find("Create area");
    }
  
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        float Timer = 60-_timer;
        _tt.text = $"{Timer.ToString("f2")}";
        _cs.text = $"{m_score.ToString("f2")}";
        var PC = _pc.GetComponent<PlayerController>();
        var CA = _ca.GetComponent<CreateAreaController>();
        if(Timer <= 0)
        {
            _GameClear.gameObject.SetActive(true);
            PC._intarval = 999999;
            CA._interval = 999999;
            PC._move = Vector2.zero;
            col.enabled = false;
        }
        if(_hp <= 0)
        {
            _GameOver.gameObject.SetActive(true);
            PC._intarval = 999999;
            CA._interval = 999999;
            PC._move = Vector2.zero;
            col.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "target1")
        {
            Debug.Log("ダメージ1");
            _hp -= 1;
            DamageGauge(0.01f);
        }
        else if (collision.gameObject.tag == "target2")
        {
            Debug.Log("ダメージ2");
            _hp -= 2;
            DamageGauge(0.02f);
        }
        else if (collision.gameObject.tag == "target5")
        {
            Debug.Log("ダメージ5");
            _hp -= 5;
            DamageGauge(0.05f);
        }
        else if (collision.gameObject.tag == "target50")
        {
            Debug.Log("ダメージ50");
            _hp -= 50;
            DamageGauge(0.5f);
        }
    }
    void DamageGauge(float dm)
    {
        _garbage.GetComponent<Image>().fillAmount += dm;
    }
    public void AddScore(int _score)
    {
        m_score += _score;
        _sc.text = $"{m_score.ToString("000")}g";
    }
}
