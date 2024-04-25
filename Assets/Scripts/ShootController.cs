using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Playables;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab; // 引用子弹Prefab
    public float bulletSpeed = 5f;  // 子弹速度
    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = PublicTool.GetGameData();
    }

    public void Shoot()
    {
        // 获取按钮位置
        Vector3 buttonPosition = gameData.ButtonPostion;

        // 发射子弹向上
        InstantiateBullet(buttonPosition, Vector3.up);

        // 发射子弹向下
        InstantiateBullet(buttonPosition, Vector3.down);

        // 发射子弹向左
        InstantiateBullet(buttonPosition, Vector3.left);

        // 发射子弹向右
        InstantiateBullet(buttonPosition, Vector3.right);
    }

    void InstantiateBullet(Vector3 position, Vector3 direction)
    {
        // 实例化子弹Prefab
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

        // 获取子弹的Rigidbody2D组件（如果使用2D物理系统）
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // 设置子弹的速度和方向
        if (bulletRb != null)
        {
            bulletRb.velocity = direction * bulletSpeed;
        }
    }

    #region Event

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener("ClickButton", ClickButtonEvent);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener("ClickButton", ClickButtonEvent);
    }

    private void ClickButtonEvent(object arg0)
    {
        Shoot();
        Debug.Log("shoot");
    }

    #endregion
}
