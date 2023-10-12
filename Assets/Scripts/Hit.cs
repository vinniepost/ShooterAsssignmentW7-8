using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        // Check if the GameController object and component are found
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            // Log an error if the GameController object is not found
            Debug.LogError("GameController object not found!");
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            if (gameController != null)
            {
                // explosie particals en sound ding
                gameController.KillScoreIncrease();
                Destroy(gameObject);
            }
            
        }
    }
}
