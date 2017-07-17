using System;

public interface IPowerUp
{
    PowerUpType type { get; }
    string icon { get;}

    void LaunchPowerUp();
}
