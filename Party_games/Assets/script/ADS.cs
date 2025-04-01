using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3994587";
    bool gametest = false;
    string myPlacementId = "rewardedVideo";
    string myPlacementId2 = "video";
     GameManager gameManager;

   // public playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
       
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
        if (PlayerPrefs.GetFloat("rounds") >= 5)
        {
            Advertisement.Show(myPlacementId2);
            gameManager.time = gameManager.time * 0.7f;
            PlayerPrefs.SetFloat("time", gameManager.time);
            //time = PlayerPrefs.GetFloat("time");
                gameManager.num = gameManager.num * 1.2f;
                PlayerPrefs.SetFloat("num2", gameManager.num);
            gameManager.rounds = 0;
            PlayerPrefs.SetFloat("rounds", gameManager.rounds);
            
            //gameManager.slider.value = gameManager.time;
        }
        else
        {
            gameManager.time = PlayerPrefs.GetFloat("time");
            gameManager.time = gameManager.time;
            //PlayerPrefs.SetFloat("time", time);
            gameManager.slider.maxValue = gameManager.time;
            gameManager.slider.value = gameManager.time;
        }


    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            gameManager.life += 1;
            PlayerPrefs.SetInt("life", gameManager.life);
            gameManager.ads.SetActive(false);
            
        }
        else if (showResult == ShowResult.Skipped)
        {
            gameManager.ad = false;
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
