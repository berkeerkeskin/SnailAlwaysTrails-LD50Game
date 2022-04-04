using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text counterText;
    public float seconds, minutes;

    void Start () {
        counterText = GetComponent<TMP_Text>() as TMP_Text;
    }

    void Update () {
        minutes = (int)(Time.time/60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
