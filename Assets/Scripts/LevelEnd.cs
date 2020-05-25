using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    float duration = 2f;
    float elapsed;

    public System.Action OnAnimationEnded;

    Canvas canvas;
    public Text text;
    public Level level;

    void Start()
    {
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;
        float percentage = elapsed / duration;
        if (percentage > 1)
        {
            OnAnimationEnded();
        }
        else
        {
            Color textColor = text.color;
            textColor.a = 1 - percentage;
            text.color = textColor;
            text.text = level.LevelName + " Ended";
        }
    }
}
