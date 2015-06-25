using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
    private float MovementSpeed = 10;
    private Vector3 movementVector = Vector3.zero;

    private GameObject ground;

    void Awake()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

	// Update is called once per frame
	void Update () {
        Movement();
        CameraMovement();
	}

    void Movement()
    {
        movementVector = Vector3.zero;
        Vector3 pos = this.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -MovementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = MovementSpeed;
        }

        pos += movementVector * Time.deltaTime;

        //Bounds
        float xBound = ground.transform.localScale.x * 0.5f - this.transform.localScale.x * 0.5f;

        if (pos.x < -xBound)
        {
            pos.x = -xBound;
        }
        else if (pos.x > xBound)
        {
            pos.x = xBound;
        }

        this.transform.position = pos;
    }
    
    void CameraMovement()
    {
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 1, -3);
        float xBound = Mathf.Abs(ground.transform.localScale.x * 0.5f - Camera.main.orthographicSize * 3.5f * 0.5f);

        if (pos.x < -xBound)
        {
            pos.x = -xBound;
        }
        else if (pos.x > xBound)
        {
            pos.x = xBound;
        }

        Camera.main.transform.position = pos;
    }
     
}
