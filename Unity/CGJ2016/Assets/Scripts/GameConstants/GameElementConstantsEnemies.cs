using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static partial class GameElementConstants
{
    public static class Enemies
    {

        public static EnemyData YellowDemon = new EnemyData
                        (
                        prefabPath: "Amarillo",
                        lives: 1,
                        damage: 6,
                        points: 1,
                        souls: 10,
                        speed: 4
                        );
        public static EnemyData RedDemon = new EnemyData
                        (
                        prefabPath: "Rojo",
                        lives: 2,
                        damage: 14,
                        points: 3,
                        souls: 10,
                        speed: 3
                        );
        public static EnemyData GreenDemon = new EnemyData
                        (
                        prefabPath: "Verde",
                        lives: 3,
                        damage: 28,
                        points: 6,
                        souls: 10,
                        speed: 2
                        );
        public static EnemyData BlackDemon = new EnemyData
                       (
                       prefabPath: "Boss",
                       lives: 10,
                       damage: 100,
                       points: 25,
                       souls: 10,
                       speed: 1
                       );
    }
}