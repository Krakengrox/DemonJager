using UnityEngine;
using System.Collections.Generic;

public class DataInitializer : MonoBehaviour
{
    #region Variables
    DataService dataService = null;
    GoogleInitializer googleInitializer = null;
    #endregion

    #region Methods
    protected void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        //catch singletons
        this.dataService = DataService.Instance;

        this.dataService.Initialize();

        this.googleInitializer = new GoogleInitializer();


    }

    #endregion
}

