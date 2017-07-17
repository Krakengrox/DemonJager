using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RitualHud
{
    float amountChange;
    float initFillAmout;
    float maxAmount;
    bool UpBar = false;
    bool DownBar = false;
    public bool activePowerUp = false;
    Image ritualBar = null;
    public Button buttonPowerUp = null;
    GameObject powerUpGlowEffect;
    public Action TriggerRitualEvent;
    public Action inactivePowerUp;
    public Action<bool> SetActiveRitualEvent;
    public GameObject powerUpIcon;

    UI.Behaviours.GamePlay.GamePlayManager uiManager = null;

    public RitualHud(float ritualAmount)
    {
        this.uiManager = UI.Behaviours.GamePlay.GamePlayManager.Instance;

        this.maxAmount = ritualAmount;
        FindRitualElement();
        ResetRitualAmount();
    }

    public void FindRitualElement()
    {
        this.ritualBar = GameObject.Find("RitualFillBar").GetComponent<Image>();
        this.ritualBar.gameObject.AddComponent<UpdateEvent>().updateEvent += ProgresiveUp;
        this.buttonPowerUp = this.uiManager.gamePlay.HUDScreen.ActivatePowerUp;
        this.powerUpIcon = this.uiManager.gamePlay.HUDScreen.PowerUpIcon;
        this.powerUpGlowEffect = this.uiManager.gamePlay.HUDScreen.PowerUpGlowEffect;
        buttonPowerUp.interactable = false;
        buttonPowerUp.onClick.AddListener(TriggerRitual);
    }

    public void ResetRitualAmount()
    {
        this.ritualBar.fillAmount = (this.maxAmount * 0.1f) / this.maxAmount;
        this.initFillAmout = this.ritualBar.fillAmount;
    }

    public void ReduceRitualAmount()
    {
        float amount = this.maxAmount;
        if (ritualBar && maxAmount > 0)
        {
            this.amountChange = ritualBar.fillAmount - (amount / this.maxAmount);
            DownBar = true;
        }
    }

    public void UpRitualAmount(float amount)
    {
        if (ritualBar && maxAmount > 0 && !activePowerUp)
        {
            this.amountChange = ritualBar.fillAmount + (amount / this.maxAmount);
            UpBar = true;
        }
    }

    void ProgresiveUp()
    {
        if (this.ritualBar.fillAmount < amountChange && UpBar)
        {
            this.ritualBar.fillAmount += Time.fixedDeltaTime * Time.timeScale * GameElementConstants.timeUpProgresiveBar;


            if (this.ritualBar.fillAmount >= 1)
            {
                UpBar = false;
                SetActiveRitual(true);
            }
        }
        else
        {
            UpBar = false;
        }

        if (this.ritualBar.fillAmount > amountChange && DownBar)
        {
            this.ritualBar.fillAmount -= Time.fixedDeltaTime * Time.timeScale * GameElementConstants.timeUpProgresiveBar;

        }
        else
        {
            DownBar = false;
            inactivePowerUp();
        }

    }

    void TriggerRitual()
    {
        TriggerRitualEvent.Trigger();
        SetActiveRitual(false);
    }

    public void SetActiveRitual(bool state)
    {
        this.powerUpGlowEffect.SetActive(state);
        this.buttonPowerUp.interactable = state;
        this.SetActiveRitualEvent.Trigger(state);
    }

    public void DeactivateGlow()
    {

    }

}
