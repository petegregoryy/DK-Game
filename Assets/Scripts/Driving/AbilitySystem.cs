using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour {

    // Render so i can change the colour for testing
    public int _value;

	// Use this for initialization
	void Start () {
        _value = 1;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT AN OBJECT");
        // Trigger object must be tagged as "Ability_Trigger" to trigger this. Tag name subject to change.
        // Trigger object can be projectile, ray-cast, or any kind of GameObject that has a trigger boxCollider attached to it.
        if(other.CompareTag("Ability_Trigger"))
        {
            Debug.Log("HIT AN Ability Trigger");
            // Switch case gets name of trigger object, which can be used to identify and select intended abibity.
            switch (other.ToString().Split(' ')[0])
            {
                // INSERT CALLS TO ABILITY EFFECTS HERE

                // Example case
                case "Projectile": Ability1(); break;

                default: break;
            }
        }
    }

    // Example ability
    private void Ability1()
    {
        Debug.Log("Ability Pickup");
        // Represents car value such as speed
        _value += 1;
    }
}
