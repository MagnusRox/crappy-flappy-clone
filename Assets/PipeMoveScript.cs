using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    
    private double deadZone = -65.0;
    //private float timeRan = 0;

    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the pipe object is because the pipe will move faster in the cases of extremely high FPS
        //This unifies the rate of pipe transition across all the different FPS

        transform.position = transform.position + (Vector3.left * moveSpeed )* Time.deltaTime;
        if (transform.position.x < deadZone) { 
            destroyPipe();
        }
        
    }

    public void updateMoveSpeed(float updateMoveSpeedBy)
    {
        
        moveSpeed+= updateMoveSpeedBy;
        Debug.Log("Updating movemnt speed to" + moveSpeed);
    }

    private void destroyPipe()
    {
        Debug.Log(moveSpeed);
        Destroy(gameObject);
    }
}
