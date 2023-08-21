using System.Runtime.CompilerServices;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{


    public GameObject cloudPrefab;
    private float screenLeftEdge = -45.55f;

    private GameObject firstCloud;
    private GameObject secondCloud;


    private bool isFirst = true;
    private float bufferXGap = 20.0f;

    private
    // Start is called before the first frame update
    void Start()
    {


        firstCloud =  Instantiate(cloudPrefab);
        secondCloud = Instantiate(cloudPrefab);
        updateCloudPosition(secondCloud, firstCloud);

     }

    // Update is called once per frame
    void Update()
    {
        

        if (firstCloud.transform.position.x  < screenLeftEdge) {
            updateCloudPosition(firstCloud, secondCloud);
        }

        if (secondCloud.transform.position.x < screenLeftEdge)
        {
            updateCloudPosition(secondCloud, firstCloud);
        }

    }

    private void updateCloudPosition(GameObject frontCloud,GameObject backCloud)
    {


        Vector3 currentRightCloudPosition = backCloud.gameObject.transform.GetChild(4).transform.position;
        Vector3 currentLeftCloudPosition = backCloud.gameObject.transform.GetChild(5).transform.position;
        float currentCloudSpawnX = bufferXGap + backCloud.transform.position.x + (currentRightCloudPosition.x - currentLeftCloudPosition.x);
        frontCloud.transform.position = new Vector3(currentCloudSpawnX,transform.position.y, 0);

    }
}
