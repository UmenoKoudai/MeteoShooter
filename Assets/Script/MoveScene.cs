using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    //public static int m_score;
    //GameObject _gm;
    // Start is called before the first frame update
    void Start()
    {
        //_gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string _scnename)
    {
        SceneManager.LoadScene(_scnename);
    }
    //private void Reset()
    //{
    //    m_score = 0;
    //    var GM = _gm.GetComponent<GameManager>();
    //    return(GM);
    //}
}
