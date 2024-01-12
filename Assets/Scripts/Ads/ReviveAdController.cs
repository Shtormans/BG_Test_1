using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviveAdController : MonoBehaviour
{
    [SerializeField] private AdsManager _adsManager;
    [SerializeField] private Button _reviveButton;

    public event Action AdSuccessfullyEnded;

    private void Awake()
    {
        _adsManager.AdSuccessfullyEnded += OnAdSuccessfullyEnded;
    }

    public void StartReviveAd()
    {
        _adsManager.ShowRewardedAd();
    }

    private void OnAdSuccessfullyEnded()
    {
        _reviveButton.gameObject.SetActive(false);

        AdSuccessfullyEnded?.Invoke();
    }
}
