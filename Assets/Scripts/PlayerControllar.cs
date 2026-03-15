using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllar : MonoBehaviour
{
    //Variables to allow for customization of speed during testing
    [SerializeField] protected internal float xSpeed = 0.25f;
    [SerializeField] protected internal float ySpeed = 10f;
    //Variables for collision
    protected bool isGrounded = false;
    protected int health = 100;
    protected int iFrames = 0;

    // Update is called once per frame
    void Update(){ 
        //Reduces I-Frames (doesn't work, or works very poorly with current implamentation)
        if (iFrames > 0){
            iFrames--;
        }

        //Movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float vert = 0;
        float horz = Input.GetAxis("Horizontal");
        //Caps speed in either direction
        if (horz > 0.15f) horz = 0.15f;
        if (horz < -0.15f) horz = -0.15f;
        if (Input.GetButtonDown("Jump") && isGrounded){
            vert = ySpeed;
        }

        rb.linearVelocity += new Vector2(xSpeed * horz, vert);
    }

    //Gets if the player is on the ground or not
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    //Checks to see if the player is grounded
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Increases score and destroys coin
        if (other.CompareTag("Coin"))
        {
            //Calls for the GameManager to change the points given
            GameManager.Instance.changePoints(1);
            Destroy(other.gameObject);
        }

        //Take damage
        if (other.CompareTag("Enemy"))
        {
            if (iFrames == 0){
                takeDamage(-10);
            }
        }
    }

    //A function based around taking damage
    void takeDamage(int damage){
        //Calls the GameManager to do the damage
        GameManager.Instance.changeHp(damage);
        iFrames = 180;
    }
}
