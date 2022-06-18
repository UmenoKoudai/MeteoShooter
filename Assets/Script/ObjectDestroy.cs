using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] float _position;
    Animator _an;
    // Start is called before the first frame update
    void Start()
    {
        _an = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _an.SetBool("BD", true);
        }
        if (transform.position.y <= _position)
        {
            Destroy(gameObject);
        }

    }
}
