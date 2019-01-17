using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour {

    public GameObject victoryCanvas;
	// Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            victoryCanvas.SetActive(true);
            Time.timeScale = 0.0001f;
        }
    }
}
