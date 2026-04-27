using UnityEngine;

// Some code that I used is from bananadev2 https://www.youtube.com/watch?v=7z0hKe9KaAc&t=415s

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float startingSpeed;
    
    public bool scored = false;
    
    public AudioSource audioSource;
    public AudioClip wallSound;
    public AudioClip paddleSound;
    public AudioClip goalSound;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        bool IsRight = UnityEngine.Random.value > 0.5f;

        float xVelocity = -1f;

        if (IsRight == true)
        {
            xVelocity = 1f;
        }
        
        float yVelocity = UnityEngine.Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(xVelocity * startingSpeed, yVelocity * startingSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopWall") || collision.gameObject.CompareTag("BottomWall"))
        {
            startingSpeed += 0.50f;
            rb.linearVelocity = rb.linearVelocity.normalized * startingSpeed;
            audioSource.PlayOneShot(wallSound);
        }
        else if (collision.gameObject.CompareTag("Padel"))
        {
            startingSpeed += 0.50f;
            rb.linearVelocity = rb.linearVelocity.normalized * startingSpeed;
            audioSource.PlayOneShot(paddleSound);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            startingSpeed = 5f;
            transform.position = new Vector3(0f, 0f, 0f);
            audioSource.PlayOneShot(goalSound);
            
            scored = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
