using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    public float lifespan = 10f; // ������������ڣ�10�����ʧ

    void Start()
    {
        Invoke(nameof(DestroySelf), lifespan); // 10��������������ĺ���
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // ��������ķ���
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
