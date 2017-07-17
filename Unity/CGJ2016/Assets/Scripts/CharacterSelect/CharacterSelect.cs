using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class CharacterSelect
{

    public Character data = null;
    Button buttonBuy;
    public Button buttonSelect;
    public Button buttonInUse;
    GameObject characterCard = null;
    GameObject lockCharacter = null;
    public User user = null;
    public Action inUse = null;

    public CharacterSelect(Character data, User userData)
    {
        this.data = data;
        this.user = userData;
        Init();
    }

    void Init()
    {
        FindParent();
        InstanceCharacter();
        GetButtons();
        ValidUnlocked();

    }

    void InstanceCharacter()
    {
        this.characterCard = GameObject.Instantiate(Resources.Load(this.data.CartPath)) as GameObject;
        this.characterCard.transform.SetParent(FindParent().transform, false);
        this.characterCard.gameObject.FindInChildren("SoulsCost").GetComponent<Text>().text = this.data.SoulsCost.ToString();
        this.characterCard.gameObject.FindInChildren("CharacterName").GetComponent<Text>().text = this.data.Name;
        this.lockCharacter = this.characterCard.gameObject.FindInChildren("Lock");
    }

    void GetButtons()
    {
        buttonBuy = this.characterCard.FindInChildren("Btn_Buy").GetComponent<Button>();
        buttonBuy.onClick.AddListener(BuyNewCharacter);

        buttonSelect = this.characterCard.FindInChildren("Btn_Select").GetComponent<Button>();
        buttonSelect.onClick.AddListener(UseCharacter);

        buttonInUse = this.characterCard.FindInChildren("Btn_Use").GetComponent<Button>();

    }

    public void ValidUnlocked()
    {
        if (bool.Parse(this.data.Unlocked))
        {
            this.lockCharacter.SetActive(false);
            buttonBuy.gameObject.SetActive(false);
            buttonInUse.gameObject.SetActive(false);
            buttonSelect.gameObject.SetActive(true);
        }
        else
        {
            this.lockCharacter.SetActive(true);
            buttonBuy.gameObject.SetActive(true);
            buttonInUse.gameObject.SetActive(false);
            buttonSelect.gameObject.SetActive(false);
        }
    }

    GameObject FindParent()
    {
        return GameObject.Find("CharacterList");
    }

    void BuyNewCharacter()
    {
        if (this.user.Souls >= this.data.SoulsCost)
        {
            this.user.Souls -= this.data.SoulsCost;
            this.data.Unlocked = "true";
            DataService.Instance.UpdateTable(this.data);
            DataService.Instance.UpdateTable(this.user);
            ValidUnlocked();
        }
    }

    void UseCharacter()
    {
        buttonSelect.gameObject.SetActive(false);
        buttonInUse.gameObject.SetActive(true);
        this.user.CharacterEquip = this.data.Id;
        DataService.Instance.UpdateTable(this.user);
        inUse();
    }

    public void InUseCharacter()
    {
        this.buttonInUse.gameObject.SetActive(true);
        this.buttonSelect.gameObject.SetActive(true);

    }
}
