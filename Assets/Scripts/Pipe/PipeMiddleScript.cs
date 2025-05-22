using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic;
    public AudioClip scoreSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            logic.addScore();
            SoundFXManager.instance.PlaySoundFXClip(scoreSound, transform, 1);
        }
    }
}
