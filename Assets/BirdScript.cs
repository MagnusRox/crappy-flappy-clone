using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float flapStrength;
    public Text diveCounter;

    private LogicScript logic;
    private PipeSpawnerPrefab pipeSpawnerPrefab;

    public AudioSource audioSource;
    public AudioClip collisionSound, jumpSound, diveSound;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawnerPrefab = GameObject.FindGameObjectWithTag("Finish").GetComponent<PipeSpawnerPrefab>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            audioSource.clip = jumpSound;
            audioSource.Play();
            rigidbody2D.velocity = Vector2.up * flapStrength;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            int diveCount = PlayerPrefs.GetInt("DiveCount", 0);
            if (diveCount > 0) {
                audioSource.clip = diveSound;
                audioSource.Play();
                rigidbody2D.velocity = Vector2.down * flapStrength * 1.5f;
                PlayerPrefs.SetInt("DiveCount", diveCount - 1);
                diveCounter.text = $"Dives Left: {diveCount - 1}";
            }

        }
    }


    void OnBecameInvisible() {
        gameOverCall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6){
            audioSource.clip = collisionSound;
            audioSource.Play();
            gameOverCall();
        }
    }

    private void gameOverCall() {
        gameObject.SetActive(false);
        pipeSpawnerPrefab.updateSpawnFlag();
        logic.gameOver();
    }
}
