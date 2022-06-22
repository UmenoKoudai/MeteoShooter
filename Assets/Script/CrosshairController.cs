using UnityEngine;

/// <summary>
/// 照準 (Crosshair) を制御するコンポーネント
/// マウスカーソルの位置に照準を移動する
/// </summary>
public class CrosshairController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;    // Z 座標がカメラと同じになっているので、リセットする
        this.transform.position = mousePosition;
    }
}
