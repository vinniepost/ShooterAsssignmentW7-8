using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    float timer = 10f;
    bool start = false;
    public float shootRange = 1f;


    void Update()
    {
        float shoot = Input.GetAxis("Fire1");
        print(shoot);

        if (shoot == 1 && timer >= shootRange)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation); // dit is oke


            Vector3 moveDirection = transform.forward * 200f;
            moveDirection += transform.forward * 200f;

            // Apply movement force
            newProjectile.GetComponent<Rigidbody>().velocity = moveDirection;

            start = true;
            timer = 0f;
        }

        if (start)
        {
            if (timer < shootRange)
            {
                timer += Time.deltaTime;
             
            }
            else
            {
                timer = shootRange;
                start = false;
            }
        }
    }
}
