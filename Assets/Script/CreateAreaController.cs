using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAreaController : MonoBehaviour
{
    [SerializeField] GameObject[] _item;
    [SerializeField] public float _interval;
    BoxCollider2D _bc;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frameq 
    void Update()
    {
        _time += Time.deltaTime;

        float RandomX = Random.Range((-_bc.size.x)/2, (_bc.size.x)/2);
        float RandomY = Random.Range((-_bc.size.y)/2, (_bc.size.y)/2);
        int n = Random.Range(0, _item.Length);

        if(_time >= _interval)
        {
            GameObject _Item = Instantiate(_item[n]);
            _Item.transform.position = new Vector2(RandomX + transform.position.x, RandomY + transform.position.y);
            _time = 0;
        }
    }
}
