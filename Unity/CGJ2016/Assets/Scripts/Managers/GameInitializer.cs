using UnityEngine;
using System.Collections.Generic;

public class GameInitializer : MonoBehaviour
{
    #region Variables
    GameManager gameManager = null;

    #endregion

        #region Methods
    protected void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        //catch singletons
        this.gameManager = GameManager.Instance;
        if (!this.gameManager.isInitialized) this.gameManager.Initialize();
    }

    #endregion
}

