using UnityEngine;


public class PipeSpawnerPrefab : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pipe;


    public float spawnRate = 5;
    private float timer;
    public float pipeHeightOffset = 10;
    public bool keepSpawning = true;

    private float timeRan;
    private float timeFrequencyToIncreaseSpeed = 5;
    private float moveSpeedToUpdateBy = 0;

    private float moveSpeedToUpdateByPerIteration = .8f;
    private float spawnRateToReduceByPerIteration = 0.075f;
    private float timeinSecondsPerFrequency = 5;



    void Start()
    {
        spawnPipe(moveSpeedToUpdateBy);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (keepSpawning)
        {
            timeRan+= Time.deltaTime;
            if(moveSpeedToUpdateBy <= 25) 
            {
                if (timeRan > timeFrequencyToIncreaseSpeed)
                {
      
                    moveSpeedToUpdateBy += moveSpeedToUpdateByPerIteration;
                    spawnRate = spawnRate - spawnRateToReduceByPerIteration;
                    timeFrequencyToIncreaseSpeed += timeinSecondsPerFrequency;

                }
            }
   
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnPipe(moveSpeedToUpdateBy);
                timer = 0;
            }
        }
    }

    void spawnPipe(float updateMoveSpeedBy) {
     
        var pipePrefab = Resources.Load("Pipe");
        pipe = pipePrefab as GameObject;
        var highestPipeYPosition = transform.position.y + pipeHeightOffset;
        var lowestPipeYPosition = transform.position.y - pipeHeightOffset;
        
        GameObject thisPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPipeYPosition,highestPipeYPosition),0), transform.rotation);
        var thisPipeScriptComponent = thisPipe.GetComponent<PipeMoveScript>();
        thisPipeScriptComponent.updateMoveSpeed(updateMoveSpeedBy);
    }

    public void updateSpawnFlag() { 
        keepSpawning = false;
        }

    public void updateSpawnRate(float increaseSpawnRateby) {
        spawnRate = spawnRate + increaseSpawnRateby;
    }

    public float getSpawnRate() {
        return spawnRate;

    }
}
