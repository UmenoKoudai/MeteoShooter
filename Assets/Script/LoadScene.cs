using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] GameObject _StageSelect;
    [SerializeField] GameObject _Help;
    [SerializeField] GameObject _title;
    public static int m_score;
    
    public void MoveScene(string _scnename)
    {
        SceneManager.LoadScene(_scnename);
    }

    public void StageSelect()
    {
        _StageSelect.gameObject.SetActive(true);
        _title.gameObject.SetActive(false);

    }

    public void Help()
    {
        _Help.gameObject.SetActive(true);
        _title.gameObject.SetActive(false);
    }

    public void Returen()
    {
        _Help.gameObject.SetActive(false);
        _StageSelect.gameObject.SetActive(false);
        _title.gameObject.SetActive(true);
    }
}
