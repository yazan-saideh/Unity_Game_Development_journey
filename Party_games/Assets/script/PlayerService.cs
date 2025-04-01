using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
public class PlayerService : MonoBehaviour
{
    GameObject gamemanager;
    
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        Invoke("addleaderboard", 1);
        DontDestroyOnLoad(this);
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            //PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) => {
                if (!success)
                {
                    
                    Debug.LogError("unable to connect");
                }
            });
    }

    // Update is called once per frame
    public  void addleaderboard()
    {
       
            Social.ReportScore(gamemanager.GetComponent<GameManager>().highscore2, GPG.leaderboard_highscore, success => {
                if (success)
                {
                    Debug.Log("hey");
                }
                else
                {
                    Debug.Log("hooo");
                }
            });
        
    }
    public  void ShowLeaderboeardUI()
    {
        
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPG.leaderboard_highscore);
            Debug.Log("boo");
            
        
    }
}
