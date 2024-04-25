using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Playables;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab; // �����ӵ�Prefab
    public float bulletSpeed = 5f;  // �ӵ��ٶ�
    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = PublicTool.GetGameData();
    }

    public void Shoot()
    {
        // ��ȡ��ťλ��
        Vector3 buttonPosition = gameData.ButtonPostion;

        // �����ӵ�����
        InstantiateBullet(buttonPosition, Vector3.up);

        // �����ӵ�����
        InstantiateBullet(buttonPosition, Vector3.down);

        // �����ӵ�����
        InstantiateBullet(buttonPosition, Vector3.left);

        // �����ӵ�����
        InstantiateBullet(buttonPosition, Vector3.right);
    }

    void InstantiateBullet(Vector3 position, Vector3 direction)
    {
        // ʵ�����ӵ�Prefab
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

        // ��ȡ�ӵ���Rigidbody2D��������ʹ��2D����ϵͳ��
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // �����ӵ����ٶȺͷ���
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
