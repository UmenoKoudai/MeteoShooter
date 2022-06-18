using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image _garbage;
    [SerializeField] Text _sc;
    int _hp;
    int m_score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "target1")
        {
            _hp -= 1;
            DamageGauge(0.01f);
        }
        else if (collision.gameObject.tag == "target2")
        {
            _hp -= 2;
            DamageGauge(0.02f);
        }
        else if (collision.gameObject.tag == "target5")
        {
            _hp -= 5;
            DamageGauge(0.05f);
        }
        else if (collision.gameObject.tag == "target50")
        {
            _hp -= 50;
            DamageGauge(0.5f);
        }
    }
    void DamageGauge(float dm)
    {
        _garbage.GetComponent<Image>().fillAmount -= dm;
    }
    public void AddScore(int _score)
    {
        m_score += _score;
        _sc.text = $"{m_score}g";
    }
}
