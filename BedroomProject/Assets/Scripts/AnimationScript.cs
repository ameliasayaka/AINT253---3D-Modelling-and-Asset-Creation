using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public bool hasPlayerInteracted;
    public bool isAlreadyOn;
    private bool playerInRange;
    private Animator screenAnimation;
    private Animator ceilingAnimation;
    public GameObject canvas;
    private AudioSource danceMusic;
    GameObject ceiling;




    // Use this for initialization
    void Start()
    {
        hasPlayerInteracted = false;
        isAlreadyOn = false;
        playerInRange = false;
        ceiling = GameObject.FindGameObjectWithTag("Ceiling");
        danceMusic = ceiling.GetComponent<AudioSource>();
        ceilingAnimation = ceiling.GetComponent<Animator>();
        screenAnimation = GetComponent<Animator>();
        
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {

        playerInRange = true;
        canvas.GetComponent<Canvas>().enabled = true;
        

    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        canvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInRange && !isAlreadyOn)
            {

                hasPlayerInteracted = true;
                screenAnimation.SetBool("isOn", hasPlayerInteracted);
                ceilingAnimation.SetBool("isParty", hasPlayerInteracted);
                isAlreadyOn = true;
                danceMusic.Play();

                Debug.Log("Party Started");

            }
            else if (playerInRange && isAlreadyOn)
            {
                isAlreadyOn = false;
                screenAnimation.SetBool("isOn", false);
                ceilingAnimation.SetBool("isParty", false);
                danceMusic.Pause();
                Debug.Log("Party Stopped");
            }

        }
       
    }
}
