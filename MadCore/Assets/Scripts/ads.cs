using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ads : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4104085";
    bool gametest = false;
    string myPlacementId = "rewardedVideo";
    string myPlacementId2 = "video";
    public GameManager gamemanager;
    // public playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, gametest);
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }
    public void Update()
    {
        if (gamemanager.timerestart == 5)
        {
            Advertisement.Show(myPlacementId);
            gamemanager.timerestart = 0;
            PlayerPrefs.SetFloat("timerestart", gamemanager.timerestart);
        }
        if(gamemanager.videorewardtime == 2)
        {
            Advertisement.Show(myPlacementId2);
            gamemanager.videorewardtime = 0;
            PlayerPrefs.SetFloat("videorestart", gamemanager.videorewardtime);
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            gamemanager.time = gamemanager.time2;
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
