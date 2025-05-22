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
    public float rotationSpeed;
    public const float maxAngle = 25;
    public float goDownAccel;
    private float prevPosition;
    private float curAngle;
    private bool isUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        prevPosition = transform.position.y;
        isBirdJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            isBirdJump = true;
            startText.SetActive(false);
            myRigidbody.SetRotation(10);
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

        float curPosition = transform.position.y;
        float diff = curPosition - prevPosition;

        switch (diff)
        {
            case > 0:
                isUp = true;
                break;
            case < 0:
                isUp = false;
                break;
            default:
                break;
        }

        curAngle = myRigidbody.rotation;

        switch (isUp, curAngle)
        {
            case (true, <= maxAngle):
                myRigidbody.angularVelocity = rotationSpeed;
                break;
            case (false, >= -maxAngle):
                myRigidbody.angularVelocity = -rotationSpeed * goDownAccel;
                break;
            case (true, >= maxAngle):
                myRigidbody.angularVelocity = 0;
                break;
            case (false, <= -maxAngle - 15 and <0):
                myRigidbody.angularVelocity = 0;
                break;
            default:
                break;
        }

        prevPosition = curPosition;

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
