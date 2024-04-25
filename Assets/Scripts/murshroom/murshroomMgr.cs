using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class murshroomMgr : MonoBehaviour
{
    public List<GameObject> mushrooms = new List<GameObject>();


    private GameData gameData;
  

    void Start()
    {
        intialCheck();
        gameData = PublicTool.GetGameData();

        // 订阅生命值变化事件
        gameData.OnHealthChanged += ShineMushroom;

        //mushrooms[0].GetComponent<Glow>().Shine();

    }
    void OnDestroy()
    {
        // 取消订阅事件
        gameData.OnHealthChanged -= ShineMushroom;
    }


    void Update()
    {
        //ShineMushroom();
        //mushrooms[0].GetComponent<Glow>().Shine();

    }


    private void ShineMushroom()
    {

        for (int i = 0; i < 4; i++)
        {
            if (i == gameData.Health / 5)
            {
                mushrooms[i].SetActive(true);
                mushrooms[i].GetComponent<Glow>().Shine();

            }
            else
            {
                mushrooms[i].GetComponent<Glow>().StopShine();
                mushrooms[i].SetActive(false);
            }
        }
    }

    private void intialCheck()
    {
        mushrooms[1].SetActive(false);
        mushrooms[2].SetActive(false);
        mushrooms[3].SetActive(false);
    }
}
