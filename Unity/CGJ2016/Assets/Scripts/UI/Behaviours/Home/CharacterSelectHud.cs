using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Behaviours.Home
{
    public class CharacterSelectHud : MonoBehaviour
    {
        public CharacterSelect characterSelect = null;
        public List<CharacterSelect> characterList = null;
        public User userData = null;
        void Start()
        {
            this.characterList = new List<CharacterSelect>();
            this.userData = DataService.Instance.GetUserData();

            foreach (var character in DataService.Instance.GetCharacters())
            {
                this.characterSelect = new CharacterSelect(character, userData);
                this.characterList.Add(characterSelect);
                this.characterSelect.inUse += ValidCharacterInUse;

            }
            GameObject.Find("CharacterSelect").GetComponent<ScrollSnapRect>().enabled = true;
            ValidCharacterInUse();
        }

        void ValidCharacterInUse()
        {
            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i].data.Id == this.userData.CharacterEquip)
                {
                    characterList[i].InUseCharacter();
                }
                else
                {
                    characterList[i].ValidUnlocked();
                }

            }

        }
    }
}
