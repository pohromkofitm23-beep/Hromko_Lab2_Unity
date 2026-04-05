using UnityEngine;
using TMPro; 

public class PlayerMovement : MonoBehaviour
{
    [Header("Налаштування руху")]
    public float speed = 5f;          
    private bool movingRight = true;  
    private bool isDead = false;      

    [Header("Налаштування інтерфейсу")]
    public TextMeshProUGUI scoreText; 
    private float score = 0f;         

    void Update()
    {
        if (isDead) return;

        float horizontalMove = movingRight ? speed : -speed;
        transform.Translate(new Vector3(horizontalMove, speed, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            movingRight = !movingRight;
        }

        score += Time.deltaTime * 10; 
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            Debug.Log("Гра закінчена!");
            isDead = true;
            Time.timeScale = 0; 
        }
    }
}