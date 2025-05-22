using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public Animator openPipeAnim;
    public GameObject closedPipe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openPipeAnim = closedPipe.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            openPipeAnim.SetBool("isOpen", true);
            Destroy(collision.gameObject);
        }
    }
}
