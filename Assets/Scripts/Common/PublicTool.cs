using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PublicTool
{
   

    public static GameData GetGameData()
    {
        if (GameMgr.Instance != null)
        {
            if (GameMgr.Instance.gameData != null)
            {
                return GameMgr.Instance.gameData;
            }
            else
            {
                Debug.LogWarning("gameData is null in GameMgr");
            }
        }
        else
        {
            Debug.LogWarning("GameMgr.Instance is null");
        }

        return null;
    }


}
