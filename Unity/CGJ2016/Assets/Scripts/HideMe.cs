using UnityEngine;
using System.Collections;

public class HideMe: MonoBehaviour
{
    public float hideTime = 1f;

    void OnEnable()
    {
        Invoke("Hide", hideTime);
    }

    void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
