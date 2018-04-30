using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeScript : MonoBehaviour {

    private PlayerController playerController;
    public float waitTime = 3f;
    int timer = 0;
    // Use this for initialization
    void Start () {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (timer <= 20)
        {
            timer++;

        }
        else
        {
            playerController.fireRate = .25f;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (other.tag == "Player")
        {
            playerController.fireRate = .05f;
            timer = 0;
            Destroy(gameObject);

        }
        
    }

    public void StopUpdgrade()
    {
        
    }

}
