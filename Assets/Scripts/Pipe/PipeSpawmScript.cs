using UnityEngine;

public class PipeSpawmScript : MonoBehaviour
{

    public GameObject pipe;
    public GameObject closedPipe;
    public float spawnRate = 10;
    private float timer = 0;
    public float heightOffset = 10;
    public BirdScript bird;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else if (bird.isBirdJump)
        {
            if (logic.playerScrore >= 0)
            {
                SpawnClosedPipe();
            } else
            {
                spawnPipe();
            }

            timer = 0;

        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    void SpawnClosedPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(closedPipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
