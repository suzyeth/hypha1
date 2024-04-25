using UnityEngine;

public class HealthListener : MonoBehaviour
{
    public GameData gameData; // ������ Inspector ����ק GameData ���

    void Start()
    {
        // ȷ�� gameData ���� null
        if (gameData != null)
        {
            gameData.OnHealthChanged += HandleHealthChanged; // �����¼�
        }
    }

    private void OnDestroy()
    {
        if (gameData != null)
        {
            gameData.OnHealthChanged -= HandleHealthChanged; // ȡ�������¼�
        }
    }

    void HandleHealthChanged()
    {
        // ���ﴦ������ֵ�仯���߼���������� UI ��
        Debug.Log("Health has changed, new value: " + gameData.Health);
    }
}
