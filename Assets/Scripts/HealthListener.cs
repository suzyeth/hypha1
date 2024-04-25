using UnityEngine;

public class HealthListener : MonoBehaviour
{
    public GameData gameData; // 可以在 Inspector 中拖拽 GameData 组件

    void Start()
    {
        // 确保 gameData 不是 null
        if (gameData != null)
        {
            gameData.OnHealthChanged += HandleHealthChanged; // 订阅事件
        }
    }

    private void OnDestroy()
    {
        if (gameData != null)
        {
            gameData.OnHealthChanged -= HandleHealthChanged; // 取消订阅事件
        }
    }

    void HandleHealthChanged()
    {
        // 这里处理生命值变化的逻辑，比如更新 UI 等
        Debug.Log("Health has changed, new value: " + gameData.Health);
    }
}
