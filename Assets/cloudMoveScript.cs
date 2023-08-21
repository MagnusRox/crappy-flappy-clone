using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    private float deadZone = -65.0f;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        //if (transform.position.x < deadZone)
        //{
        //    destroyCloud();
        //}


    }

    public void destroyCloud() { 
        Destroy(gameObject);
    }
}
