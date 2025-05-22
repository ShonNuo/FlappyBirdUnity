using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = false;
    public bool isBirdJump = false;
    public GameObject startText;
    public GameObject bullet;
    public float x;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            isBirdJump = true;
            startText.SetActive(false);

            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && birdIsAlive)
        {
            Time.timeScale = 0;
            logic.settingsScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && birdIsAlive)
        {
            Instantiate(bullet, new Vector3(transform.position.x + 2.5f, transform.position.y, 0), transform.rotation);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            logic.gameOver();
            myRigidbody.angularVelocity = 100;
            birdIsAlive = false;
        }
    }
}
