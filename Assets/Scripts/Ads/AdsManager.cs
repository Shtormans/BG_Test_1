using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    private string _adUnitId;

    public event Action AdSuccessfullyEnded;

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            LoadRewardedAd();
        });
    }

    private void LoadRewardedAd()
    {
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        var adRequest = new AdRequest();

        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    return;
                }

                _rewardedAd = ad;
                RegisterEventHandlers(_rewardedAd);
            });
    }


    public void ShowRewardedAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                AdSuccessfullyEnded?.Invoke();
            });
        }
    }


    private void RegisterEventHandlers(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadRewardedAd();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadRewardedAd();
        };
    }
}
