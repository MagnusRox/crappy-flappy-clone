using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

    }

}
