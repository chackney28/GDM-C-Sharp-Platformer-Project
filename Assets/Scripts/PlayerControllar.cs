using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllar : MonoBehaviour
{
    //Sets the player pref to 0
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
    //Variables to allow for customization of speed during testing
    [SerializeField] protected internal float xSpeed = 0.25f;
    [SerializeField] protected internal float ySpeed = 10f;
    //Variables for collision
    protected bool isGrounded = false;
    protected int health = 100;
    protected int iFrames = 0;
    //Text boxes during the main scene
    public TextMeshProUGUI hpTextBox;
    public TextMeshProUGUI scoreTextBox;

    // Update is called once per frame
    void Update(){
        //Updates Health and Score
        hpTextBox.text = "Hp: " + health;
        scoreTextBox.text = "Score: " + PlayerPrefs.GetInt("Score", 0);
        
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
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 1);
            Destroy(other.gameObject);
        }

        //Take damage
        if (other.CompareTag("Enemy"))
        {
            if (iFrames == 0){
                takeDamage(10);
            }
        }
    }

    void takeDamage(int damage){
        health -= damage;
        if (health <= 0){
            health = 0;
            SceneManager.LoadScene("GameOver");
        }
        iFrames = 180;
    }
}
