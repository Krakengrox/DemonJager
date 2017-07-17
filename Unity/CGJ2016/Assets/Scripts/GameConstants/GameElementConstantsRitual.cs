using UnityEngine;
using System.Collections.Generic;

public static partial class GameElementConstants
{


    public static float ritualAmount = 220;

    public static Dictionary<PowerUpType, string> RitualDescription = new Dictionary<PowerUpType, string>()
            {
                { PowerUpType.DoublePoints,
                    "Double points for every demon you kill" },
                {PowerUpType.ExtraLive,
                    "It's dangerous to go alone! Take this." },
                {PowerUpType.Frenzy,
                    "I'm thirst of demon souls!" },
                {PowerUpType.KillingAll,
                    "I've never felt this unlimited POWER!!!" },
            };

    public static Dictionary<PowerUpType, Sprite> RitualSprite = new Dictionary<PowerUpType, Sprite>()
            {
                { PowerUpType.DoublePoints,
                    Resources.Load<Sprite>("MSG/MessageBonusx2") },
                {PowerUpType.ExtraLive,
                    Resources.Load<Sprite>("MSG/MessageExtraLife") },
                {PowerUpType.Frenzy,
                    Resources.Load<Sprite>("MSG/MessageFrenzy") },
                {PowerUpType.KillingAll,
                    Resources.Load<Sprite>("MSG/MessageKillEmAll") },
            };
}
