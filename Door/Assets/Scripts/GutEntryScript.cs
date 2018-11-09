using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GutEntryScript : MonoBehaviour {
    private AudioSource playerWalk;
    private Animator monsterDoorAnimator;
    private GameObject monsterDoor;
    private GameObject canvas;
    private bool isPlayerInside;
    private GameObject player;
    private float timeLeft = 4f;
    private bool isDead;
    

    public AudioClip squelchWalkNoise;
    public AudioClip tatamiWalkNoise;

  

	// Use this for initialization
	void Start () {
        isPlayerInside = false;
        monsterDoor = GameObject.FindGameObjectWithTag("MonsterDoor");
        monsterDoorAnimator = monsterDoor.GetComponent<Animator>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        player = GameObject.FindGameObjectWithTag("Player");
        playerWalk = player.GetComponent<AudioSource>();
        isDead = false;

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInside = true;
            playerWalk.clip = squelchWalkNoise;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInside = false;
            playerWalk.clip = tatamiWalkNoise;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > 0 && timeLeft < 2)
            {
                
                
                monsterDoorAnimator.SetBool("hasPlayerOpened", false);
            }
            if (timeLeft < 0 && !isDead)
            {

                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
                canvas.GetComponent<Canvas>().enabled = true;
                GetComponent<AudioSource>().Play();
                isDead = true;
            }
            
        }

    }

}
