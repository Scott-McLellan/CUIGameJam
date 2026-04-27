using UnityEngine;

public class PlayerTwoPaddleMove : MonoBehaviour
{

    public float speed;
    
    private Rigidbody2D rb;
    
    private bool touchingTopWall = false;
    private bool touchingBottomWall = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !touchingTopWall)
        {
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !touchingBottomWall)
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopWall"))
        {
            touchingTopWall = true;
        }

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            touchingBottomWall = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopWall"))
        {
            touchingTopWall = false;
        }

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            touchingBottomWall = false;
        }
    }
}
