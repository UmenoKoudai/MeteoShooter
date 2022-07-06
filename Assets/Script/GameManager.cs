using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class scoredata
    {
        public int score;
    }

    
    //private struct scoredata
    //{
    //    public int score;
    //}
    [SerializeField] Image _garbage;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _timeText;
    [SerializeField] Text _clearScore;
    [SerializeField] Text _bestScore;
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _gameClear;
    GameObject _canon;
    GameObject _createArea;
    public BoxCollider2D col;
    float _timer;
    int _hp = 100;
    public static int _score;
    int _hiscore;
    public int _Power;
    bool _end = true;
    scoredata sco2 = new scoredata();/// <summary>scoredata�^�̕ϐ����쐬</summary>
    // Start is called before the first frame update
    public void Awake()
    {
        _score = 0;
    }

    void Start()
    {
        _canon = GameObject.Find("Canon");
        _createArea = GameObject.Find("Create area");
        //JSON�`���ŕۑ������n�C�X�R�A�f�[�^���Ăяo��sco2�ϐ��ɑ��
        sco2 = OnLoad();
        //sco2�ɑ�������O��̃n�C�X�R�A���n�C�X�R�A�̕ϐ��ɑ��
        _hiscore = sco2.score;
        
    }
  
    // Update is called once per frame
    void Update()
    {
        var pC = _canon.GetComponent<PlayerController>();
        var cA = _createArea.GetComponent<CreateAreaController>();

        pC._power = _Power;
        if (_end)
        {
            _timer += Time.deltaTime;
            float Timer = 60 - _timer;
            _timeText.text = $"{Timer.ToString("f2")}";
            _clearScore.text = $"�X�R�A:{_score.ToString("000")}";
            _bestScore.text = $"�n�C�X�R�A:{_hiscore.ToString("000")}";
            if (Timer <= 0)
            {
                _gameClear.gameObject.SetActive(true);
                pC._intarval = 999999;
                cA._interval = 999999;
                pC._move = Vector2.zero;
                col.enabled = false;
                _end = false;
                //sco2 = OnLoad();
                //_hiscore = sco2.score;
            }
            if (_hp <= 0)
            {
                _gameOver.gameObject.SetActive(true);
                pC._intarval = 999999;
                cA._interval = 999999;
                pC._move = Vector2.zero;
                col.enabled = false;
                _end = false;
                //OnSave(sco2);

            }
            if (_hiscore <= _score)
            {
                _hiscore = _score;
                //�n�C�X�R�A���X�V���ꂽ��sco2�Ƀn�C�X�R�A����
                sco2.score = _hiscore;
                //�X�V�����n�C�X�R�A��JSON�`���̃t�H���_�ɕۑ�
                OnSave(sco2);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "target1")
        //{
        //    Debug.Log("�_���[�W1");
        //    _hp -= 1;
        //    DamageGauge(0.01f);
        //}
        //else if (collision.gameObject.tag == "target2")
        //{
        //    Debug.Log("�_���[�W2");
        //    _hp -= 2;
        //    DamageGauge(0.02f);
        //}
        //else if (collision.gameObject.tag == "target5")
        //{
        //    Debug.Log("�_���[�W5");
        //    _hp -= 5;
        //    DamageGauge(0.05f);
        //}
        //else if (collision.gameObject.tag == "target6")
        //{
        //    Debug.Log("�_���[�W6");
        //    _hp -= 6;
        //    DamageGauge(0.06f);
        //}
        //else if (collision.gameObject.tag == "target7")
        //{
        //    Debug.Log("�_���[�W7");
        //    _hp -= 7;
        //    DamageGauge(0.07f);
        //}
        //else if (collision.gameObject.tag == "target10")
        //{
        //    Debug.Log("�_���[�W10");
        //    _hp -= 10;
        //    DamageGauge(0.1f);
        //}
        //else if (collision.gameObject.tag == "target12")
        //{
        //    Debug.Log("�_���[�W12");
        //    _hp -= 12;
        //    DamageGauge(0.12f);
        //}
        //else if (collision.gameObject.tag == "target50")
        //{
        //    Debug.Log("�_���[�W50");
        //    _hp -= 50;
        //    DamageGauge(0.5f);
        //}
        //else if (collision.gameObject.tag == "target70")
        //{
        //    Debug.Log("�_���[�W70");
        //    _hp -= 70;
        //    DamageGauge(0.7f);
        //}
        if (collision.gameObject.tag == "Power")
        {
            var audio = GetComponent<AudioSource>();
            _Power++;
            audio.Play();
            Debug.Log("�p���[�A�b�v");
        }
    }
    public void DamageGauge(float dm)
    {
        _garbage.GetComponent<Image>().fillAmount += dm;
    }
    public void AddScore(int _score)
    {
        GameManager._score += _score;
        this._scoreText.text = $"{GameManager._score.ToString("000")}g";
    }
    
    //�n�C�X�R�A�f�[�^��JSON�`���ŕۑ�
    private void OnSave(scoredata sco)
    {
        StreamWriter writer;
        string json = JsonUtility.ToJson(sco);
        Debug.Log(json);
        writer = new StreamWriter(Application.persistentDataPath + "/.json");
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    //�n�C�X�R�A�f�[�^���Ăяo��
    private scoredata OnLoad()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.persistentDataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<scoredata>(datastr);
    }
}
