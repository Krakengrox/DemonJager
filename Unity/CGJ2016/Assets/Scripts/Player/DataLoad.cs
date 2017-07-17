using UnityEngine;
using System.Collections;
using System;

public static class DataLoad
{
    public static void InitData()
    {
        string test = PlayerPrefs.GetString("DataLoad");

        if (!PlayerPrefs.HasKey("DataLoad"))
        {
            PlayerPrefs.SetString("DataLoad", "true");

            CharacterData playerData = GameElementConstants.Characters.Clasic;
            PlayerPrefs.SetString("CharacterName", playerData.Name);
            PlayerPrefs.SetString("prefabPath", playerData.PrefabPath);
            PlayerPrefs.SetString("ProjectileResource", playerData.ProjectileResource);
            PlayerPrefs.SetString("CardPath", playerData.CartPath);
            PlayerPrefs.SetInt("SoulsCost", playerData.SoulstCost);
            PlayerPrefs.SetString("Unlocked", Convert.ToString(playerData.Unlocked));
        }

    }

    public static CharacterData Player()
    {
        CharacterData player = new CharacterData
        (
            PlayerPrefs.GetString("prefabPath"),
            PlayerPrefs.GetString("ProjectileResource"),
            PlayerPrefs.GetString("CharacterName"),
            PlayerPrefs.GetString("CardPath"),
            PlayerPrefs.GetInt("SoulsCost"),
            bool.Parse(PlayerPrefs.GetString("Unlocked"))
        );

        return player;
    }
}
