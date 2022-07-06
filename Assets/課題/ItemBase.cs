using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate();
    public abstract void Damage();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("GameManager"))
        {
            Damage();
            Destroy(this.gameObject);
        }
    }
    public void ItemDestroy(int hp)
    {
        if (hp <= 0)
        {
            Activate();
            Destroy(this.gameObject);
        }
    }



}
