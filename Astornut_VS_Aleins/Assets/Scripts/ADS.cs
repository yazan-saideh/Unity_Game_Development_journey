using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class ADS : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4056181";
    bool gametest = false;
    string myPlacementId = "rewardedVideo";
    string myPlacementId2 = "video";
    GameObject gamemanager;
    GameObject player;
    // public playerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
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
        player.GetComponent<player>().death = PlayerPrefs.GetFloat("death");
        if (PlayerPrefs.GetFloat("death") >= 5)
        {
            player.GetComponent<player>().death = 0;
            PlayerPrefs.SetFloat("death", player.GetComponent<player>().death);
            Advertisement.Show(myPlacementId2);
        }
   // 
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            Time.timeScale = 1;
            player.SetActive(true);
            player.transform.position = new Vector3(3.85f, 0, 0);
            
            gamemanager.GetComponent<GameManager>().MAINCANVAS.SetActive(true);
            gamemanager.GetComponent<GameManager>().GameOversCANVAS.SetActive(false);
            player.GetComponent<player>().health = player.GetComponent<player>().maxhealth;
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
