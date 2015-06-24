using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
    public float MovementSpeed = 1;

    private Vector3 movementVector = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        movementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -MovementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = MovementSpeed;
        }

        this.transform.position += movementVector * Time.deltaTime;
    }
}
