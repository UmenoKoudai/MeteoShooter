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
    GameObject _p;
    public BoxCollider2D col;
    float _timer;
    int _hp = 100;
    public static int m_score;
    int _hiscore;
    public int _Power;
    bool _end = true;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GameObject.Find("Canon");
        _ca = GameObject.Find("Create area");
        _p = GameObject.Find("Canon");
    }
  
    // Update is called once per frame
    void Update()
    {
        var PC = _pc.GetComponent<PlayerController>();
        var CA = _ca.GetComponent<CreateAreaController>();
        var P = _p.GetComponent<PlayerController>();
        if(_end)
        {
            _timer += Time.deltaTime;
            float Timer = 60 - _timer;
            _tt.text = $"{Timer.ToString("f2")}";
            _cs.text = $"スコア:{m_score.ToString("000")}";
            _bs.text = $"ハイスコア:{_hiscore.ToString("000")}";
            P._Power = _Power;
            if (Timer <= 0)
            {
                _GameClear.gameObject.SetActive(true);
                PC._intarval = 999999;
                CA._interval = 999999;
                PC._move = Vector2.zero;
                col.enabled = false;
                _end = false;
            }
            if (_hp <= 0)
            {
                _GameOver.gameObject.SetActive(true);
                PC._intarval = 999999;
                CA._interval = 999999;
                PC._move = Vector2.zero;
                col.enabled = false;
                _end = false;
            }
            if (_hiscore <= m_score)
            {
                _hiscore = m_score;
            }
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
        else if (collision.gameObject.tag == "target6")
        {
            Debug.Log("ダメージ6");
            _hp -= 6;
            DamageGauge(0.06f);
        }
        else if (collision.gameObject.tag == "target7")
        {
            Debug.Log("ダメージ7");
            _hp -= 7;
            DamageGauge(0.07f);
        }
        else if (collision.gameObject.tag == "target10")
        {
            Debug.Log("ダメージ10");
            _hp -= 10;
            DamageGauge(0.1f);
        }
        else if (collision.gameObject.tag == "target12")
        {
            Debug.Log("ダメージ12");
            _hp -= 12;
            DamageGauge(0.12f);
        }
        else if (collision.gameObject.tag == "target50")
        {
            Debug.Log("ダメージ50");
            _hp -= 50;
            DamageGauge(0.5f);
        }
        else if (collision.gameObject.tag == "target70")
        {
            Debug.Log("ダメージ70");
            _hp -= 70;
            DamageGauge(0.7f);
        }
        if (collision.gameObject.tag == "Power")
        {
            _Power++;
            Debug.Log("パワーアップ");
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
    public void Reset()
    {
        m_score = 0;
    }
}
