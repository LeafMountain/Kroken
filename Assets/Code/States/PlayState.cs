﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Interfaces;

public class PlayState : IStateBase
{
    private GameManager gameManagerRef;
    private IPlayStateBase playStateRef;


    private PlayState() { }
    public PlayState(GameManager gameManager_ref)
    {
        this.gameManagerRef = gameManager_ref;

        if (gameManager_ref.debugMode)
        {
            Debug.Log("Constructing PlayState!");
        }

        if (!gameManagerRef.gameRunning)
        {
            gameManagerRef.gameRunning = true;
            gameManagerRef.audioManagerRef.StartMusicTrack();
        }



       gameManagerRef.canvasManagerRef.TogglePlayUI(true);
        gameManagerRef.canvasManagerRef.ToggleMainMenu(false);

        if (gameManager_ref.debugMode)
        {
            Debug.Log("Constructing PlayState DONE!!!");
        }

        for (int i = 0; i < gameManagerRef.players.Count; i++)
        {
            gameManagerRef.players[i].SetMovementLock(false);
        }
    }

    public void StateUpdate()
    {
        //DebugWin
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gameManagerRef.SetNewState(new ResultState(gameManagerRef, null));
        }

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            gameManagerRef.SetNewState(new PauseState(gameManagerRef));
        }

    }
    public void UIState()
    {
        
    }
}
