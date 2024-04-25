using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.Rendering.DebugUI;

public class GameData
{
    //mushroom Health

    // button postion
    private Vector3 buttonPostion;
    public Vector3 ButtonPostion
    {
        get { return buttonPostion; }
        set { buttonPostion = value; }
    }

    private int health = 3;
    public delegate void HealthChanged();
    public event HealthChanged OnHealthChanged;

    public int Health
    {
        get { return health; }
        set
        {
            if (health != value)
            {
                health = value;
                // ������ֵ�ı�ʱ�������¼�
                OnHealthChanged?.Invoke();
            }
        }


    }
}
