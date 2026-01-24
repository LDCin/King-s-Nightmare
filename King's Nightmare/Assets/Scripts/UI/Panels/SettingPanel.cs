using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : Panel
{
    public static event Action OnChangeBGMState;
    public static event Action OnChangeSFXState;
    [SerializeField] private Button _BGMButton;
    [SerializeField] private Button _SFXButton;
    [SerializeField] private Sprite _onBGMSprite;
    [SerializeField] private Sprite _offBGMSprite;
    [SerializeField] private Sprite _onSFXSprite;
    [SerializeField] private Sprite _offSFXSprite;
    public void Start()
    {
        UpdateBGMSprite();
        UpdateSFXSprite();
    }
    public void ChangeBGMState()
    {
        OnChangeBGMState?.Invoke();
        UpdateBGMSprite();
    }
    public void ChangeSFXState()
    {
        OnChangeSFXState?.Invoke();
        UpdateSFXSprite();
    }
    public void UpdateBGMSprite()
    {
        if (GameConfig.BGM_STATE == 1)
        {
            _BGMButton.image.sprite = _onBGMSprite;
        }
        else
        {
            _BGMButton.image.sprite = _offBGMSprite;
        }
    }
    public void UpdateSFXSprite()
    {
        if (GameConfig.SFX_STATE == 1)
        {
            _SFXButton.image.sprite = _onSFXSprite;
        }
        else
        {
            _SFXButton.image.sprite = _offSFXSprite;
        }
    }
    // public void 
}