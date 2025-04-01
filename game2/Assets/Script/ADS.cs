using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ADS : MonoBehaviour, IUnityAdsListener
{
    string gameId = "3950475";
    bool gametest = false;
    string myPlacementId = "rewardedVideo";
    string myPlacementId2 = "video";
    public GameObject gameoverpanel;
    public GameManager gameManager;
    public GameObject player;
    public float time = 0;
    bool start;
    public GameObject postprocces;
    public GameObject maincanves;
   // public playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
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
       if (PlayerPrefs.GetFloat("lose") >= 5)
        {
            gameManager.losenum = 0;
            PlayerPrefs.SetFloat("lose", gameManager.losenum);
            Advertisement.Show(myPlacementId2);
            
       }
       if(start == true)
        {
            if (time < 3)
            {
                player.layer = LayerMask.NameToLayer("Water");
                time += Time.deltaTime;
            }
            else
            {
                player.layer = LayerMask.NameToLayer("player");
                time = 0;
                start = false;
            }
            
        }

    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            start = true;
            player.layer = default;
            gameoverpanel.SetActive(false);
            postprocces.SetActive(false);
            maincanves.SetActive(true);
            Time.timeScale = 1f;
          
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
