using UnityEngine;

public class PipeMove : MonoBehaviour
{

    public float moveSpeed = 6;
    public float deadZone = -40;
    public BirdScript bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.isBirdJump)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
