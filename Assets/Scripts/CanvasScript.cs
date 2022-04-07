using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public GameObject keyUI;
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( _playerController.isKeyCollected){
            keyUI.SetActive(true);
        }
        else
        {
            keyUI.SetActive(false);
        }
    }
}
