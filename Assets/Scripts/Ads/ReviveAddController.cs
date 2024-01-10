using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviveAddController : MonoBehaviour
{
    [SerializeField] private AdsManager _adsManager;
    [SerializeField] private Button _reviveButton;

    public event Action AdSuccessfullyEnded;

    private void Awake()
    {
        _adsManager.AdSuccessfullyEnded += _adsManager_AdSuccessfullyEnded;
    }

    public void StartReviveAd()
    {
        _adsManager.ShowRewardedAd();
    }

    private void _adsManager_AdSuccessfullyEnded()
    {
        _reviveButton.gameObject.SetActive(false);

        AdSuccessfullyEnded?.Invoke();
    }
}
