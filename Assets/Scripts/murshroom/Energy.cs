using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private GameData gameData;
    void Start()
    {
        gameData = PublicTool.GetGameData();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("mushroom"))
        {
            int currenthealth=gameData.Health;
            //other.gameObject.GetComponent<Mushroom>().ChangeHealth(-1);
            Destroy(gameObject);

            currenthealth++;
            Debug.Log("currenthealth=" + currenthealth);
            gameData.Health = currenthealth;

            Debug.Log("health=" + gameData.Health);
        }
    }
}

