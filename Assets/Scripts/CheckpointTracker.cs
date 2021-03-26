using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
    // Stores number of most recent checkpoint
    public int _checkpointTracker;

    // Start is called before the first frame update
    void Start()
    {
        _checkpointTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Add some use for the tracker

        maybe some system that checks if the next checkpoint is in front of the player
        and tells them to turn around otherwise.

        also check if the final checkpoint has been passed and if so, end the lap / game.
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check the tag
        if (other.gameObject.tag == "checkpoint")
        {
            // Get the triggered checkpoint
            GameObject checkpoint = other.gameObject;

            //Find number of checkpoint
            try
            {
                // Get name of checkpoint as int
                int checkpointName = int.Parse(checkpoint.name.Split(' ')[0]);

                //Check if next checkpoint
                if (checkpointName == _checkpointTracker + 1)
                {
                    //Update checkpoint tracking
                    _checkpointTracker = checkpointName;
                }
            }
            catch { }
        }
    }
}

/* HOW TO USE
  Throw this onto the car, as long as:
  the checkpoints have a rigidbody, 
  the car has a trigger boxcollider,
  the first word (before a space) of the name of the checpoint must be an integer, and they need to be placed in order.
  */ 
