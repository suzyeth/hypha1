using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    public float lifespan = 10f; // 物体的生命周期，10秒后消失

    void Start()
    {
        Invoke(nameof(DestroySelf), lifespan); // 10秒后调用销毁自身的函数
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // 销毁物体的方法
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
