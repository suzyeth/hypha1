using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSubstance : MonoBehaviour
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
            //other.gameObject.GetComponent<Mushroom>().ChangeHealth(-1);
            int currenthealth = gameData.Health;
            //other.gameObject.GetComponent<Mushroom>().ChangeHealth(-1);
            Destroy(gameObject);

            currenthealth--;
            Debug.Log("currenthealth=" + currenthealth);
            gameData.Health = currenthealth;

            Debug.Log("health=" + gameData.Health);
            

        }
        else if (collision.gameObject.CompareTag("bullet"))
        {
            //other.gameObject.GetComponent<Mushroom>().ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
