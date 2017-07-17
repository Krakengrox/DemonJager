using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class GameElementConstants
{
    public static class Characters
    {

        public static CharacterData Clasic = new CharacterData
                        (
                        prefabPath: "Characters/Clasic/Hero",
                        projectileResource: "Projectile",
                        name: "Clasic",
                        cartPath: "Characters/Clasic/ClasicHeroCard",
                        soulstCost: 100,
                        unlocked: true
                        );

        public static CharacterData DarkJager = new CharacterData
                        (
                        prefabPath: "Characters/DarkJager/DarkJager",
                        projectileResource: "Projectile",
                        name: "DarkJager",
                        cartPath: "Characters/DarkJager/DarkHeroCard",
                        soulstCost: 1000,
                        unlocked: false
                        );

        public static CharacterData WhiteJager = new CharacterData
                        (
                        prefabPath: "Characters/WhiteJager/WhiteJager",
                        projectileResource: "Projectile",
                        name: "WhiteJager",
                        cartPath: "Characters/WhiteJager/WhiteHeroCard",
                        soulstCost: 1500,
                        unlocked: false
                        );
    }
}