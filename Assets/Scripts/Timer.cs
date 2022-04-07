using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text counterText;
    
    private float startTime;

    void Start () {
        counterText = GetComponent<TMP_Text>() as TMP_Text;
        startTime = Time.time;

    }

    void Update ()
    {
        float t = Time.time - startTime;
        if (!PlayerController.isDead)
        {
            PlayerController.scoreMin = (int)(t /60f);
            PlayerController.scoreSec = (int) (t % 60f);

        }
        counterText.text = PlayerController.scoreMin.ToString("00") + ":" + PlayerController.scoreSec.ToString("00");
       
    }
}
