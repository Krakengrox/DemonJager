using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FrameCounter : MonoBehaviour
{
    public Text text = null;
    const string pre = "FPS = ";
    public int fps = 0;

    public float timerElapsed = 0.0f;

    void Awake()
    {
        this.text = this.gameObject.GetComponent<Text>();
    }

    int frameCount = 0;
    void Update()
    {
        frameCount++;
    }

    void FixedUpdate()
    {
        this.timerElapsed += Time.fixedDeltaTime;
        if (this.timerElapsed >= 1.0f)
        {
            this.fps = frameCount;
            Print();

            this.timerElapsed = 0;
            this.frameCount = 0;
        }
    }

    void Print()
    {
        this.text.text = pre + fps;
    }



}