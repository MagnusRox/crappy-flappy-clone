using UnityEngine;


public class BirdScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float flapStrength;
    public LogicScript logic;
    public PipeSpawnerPrefab pipeSpawnerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawnerPrefab = GameObject.FindGameObjectWithTag("Finish").GetComponent<PipeSpawnerPrefab>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.up * flapStrength;
        }
    }


    void OnBecameInvisible() {
        gameOverCall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6){
            gameOverCall();
        }
    }

    private void gameOverCall() {
        gameObject.SetActive(false);
        pipeSpawnerPrefab.updateSpawnFlag();
        logic.gameOver();
    }
}
