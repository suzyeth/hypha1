using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMagr : MonoBehaviour
{
    // Start is called before the first frame update
    private bool startingPanel=true;
    private bool PlayingGame = false;
    private bool EndGame = false;
    public GameObject startingPan;
    public GameObject endPan;
    public GameObject gamingPan;
    public GameObject winPan;
    public GameObject GamePlayImage;
    private GameData gameData;
    void Start()
    {
        gameData = PublicTool.GetGameData();
        intialing();
    }


    //intial
    private void intialing()
    {
        startingPan.SetActive(true);
        GamePlayImage.SetActive(false);
        gamingPan.SetActive(false);        
        endPan.SetActive(false);
        winPan.SetActive(false);        
       
    }

    //game over show lose panel
    public void End()
    {
        PlayingGame = false;
        EndGame = true;
        prefabSpawner.StopSpawning();
        endPan.SetActive(true);        
        winPan.SetActive(false);
        gamingPan.SetActive(false);
        GamePlayImage.SetActive(false);
        startingPan.SetActive(false);
    }

    //wining gmae panel
    public void Win()
    {
        PlayingGame = false;
        EndGame = true;
        prefabSpawner.StopSpawning();
        winPan.SetActive(true);
        endPan.SetActive(false);       
        gamingPan.SetActive(false);
        GamePlayImage.SetActive(false);
        startingPan.SetActive(false);
    }

    //start game
    #region Button
    public GeneratrController prefabSpawner;
    public void StartButton()
    {
        PlayingGame = true;
        EndGame = false;
        CheckGameState();
        //GamePlayImage.SetActive(true);
        //gamingPan.SetActive(true);
        //startingPan.SetActive(false);
        //endPan.SetActive(false);
        // winPan.SetActive(false);

        prefabSpawner.StartSpawning();

        gameData.Health = 3;
    }

    //quit game
    public void QuitButton()
    {
        PlayingGame = false;
        EndGame = false;
        CheckGameState();
        
        Debug.Log(gameData.Health);
    }
    #endregion 


    private void CheckGameState()
    {
        if (PlayingGame && !EndGame)
        {
            GamePlayImage.SetActive(true);
            gamingPan.SetActive(true);
            startingPan.SetActive(false);
            endPan.SetActive(false);
            winPan.SetActive(false);
            prefabSpawner.StartSpawning();
        }
        else if (!PlayingGame && EndGame)
        {
            prefabSpawner.StopSpawning();
            endPan.SetActive(true);
            winPan.SetActive(false);
            gamingPan.SetActive(false);
            GamePlayImage.SetActive(false);
            startingPan.SetActive(false);
        }
        else 
        {
            intialing();
        }
       
    }

    public void Update()
    {
        CheckWin();
        CheckLose();
    }
    public void CheckWin()
    {
        //winging
        if (gameData.Health >= 20)
        {
            Win();
        }
    }

    public void CheckLose()
    {
        //losing
        if (gameData.Health <= 0)
        {
            End();
        }

    }

}
