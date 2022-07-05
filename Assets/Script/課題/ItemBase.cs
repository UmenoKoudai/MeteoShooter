using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public abstract class ItemBase : MonoBehaviour
{
    ItemController _item;
    int _hp;

    public abstract void Activate();
    public abstract void Damage();

    void Update()
    {
        _item = GameObject.FindObjectOfType<ItemController>();
        _hp = _item._hp;
        if(_hp <= 0)
        {
            Activate();
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("GameManager"))
        {
            Damage();
            Destroy(this.gameObject);
        }
    }



}
