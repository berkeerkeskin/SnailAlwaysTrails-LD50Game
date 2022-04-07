using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<VideoPlayer>().url = System.IO.Path.Combine (Application.streamingAssetsPath,"meow.mp4"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
