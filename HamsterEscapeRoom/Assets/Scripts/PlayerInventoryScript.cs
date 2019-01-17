using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour {

    private int foodCounter;
    private int stickCounter;
    private int ropeCounter;
    private bool ropeColleted;


    public GameObject waterBottle;
	// Use this for initialization
	void Start () {
        foodCounter = 0;
        stickCounter = 0;
        ropeCounter = 0;
        ropeColleted = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (ropeCounter == 2)
        {
            waterBottle.GetComponent<Rigidbody>().isKinematic = false;
            ropeColleted = true;
        }
	}

    public void AddStick()
    {
        stickCounter++;
    }

    public void AddFood()
    {
        foodCounter++;
    }

    public void AddRope()
    {
        ropeCounter++;
    }

    public void RemoveStick()
    {
        stickCounter = 0;
    }

    public void RemoveFood()
    {
        foodCounter = 0;
    }
    public void RemoveRope()
    {
        ropeCounter--;
    }
    
    public int FoodCounter
    {
        get { return foodCounter; }
    }
    public int StickCounter
    {
        get { return stickCounter; }
    }
    public int RopeCounter
    {
        get { return ropeCounter; }
    }
    public bool RopeColleted
    {
        get { return ropeColleted; }
    }
}
