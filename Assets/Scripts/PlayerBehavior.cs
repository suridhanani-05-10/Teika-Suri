using UnityEngine;
using TMPro;

public class PlayerBehavior : MonoBehaviour {

    public float speed;
    public GameObject[] fruits;
    public GameObject currentFruit;
    public float min;
    public float max;
    public GameObject gameOverText;
    public int fruitType;

    public int [] points;
    public int score;
    public TMP_Text scoreText;
    public float timer;
    public float timeout;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        timer = 0;
        score = 0;
    }

    public void UpdateScore(int fruitType) {
        score = score + points[fruitType];
        scoreText.text = "Score: " + score;
    }

         public void GameOver() {
            gameOverText.SetActive(true);
         }

    // Update is called once per frame
    void Update(){
         timer += Time.deltaTime;

        if (currentFruit !=null) {
            fruitType = currentFruit.GetComponent <FruitBehavior>().fruitType;
                if (fruitType <= 5) {
                    min = -7.8f;
                    max = 0.3f;
                } 

                if (fruitType == 7) {
                    min = -7.537f;
                    max = -0.019f;
                } 

            Vector3 fruitOffset = new Vector3(0f, -1f, 0f);
            currentFruit.transform.position = transform.position + fruitOffset;
            //currentFruit.GetComponent<PolygonCollider2D>().enabled = false;
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        } else {
            int index = Random.Range(0, fruits.Length);
            currentFruit = Instantiate(fruits[index], transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space)  && timer > timeout) {
            timer = 0;
            currentFruit.GetComponent<PolygonCollider2D>().enabled = true;
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
            currentFruit = null;
        }
        if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow))){
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed;
            if (newPosition.x > min) {
                transform.position = newPosition;
            }
        }
        if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow)))
        
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + speed;
            if (newPosition.x < max) {
                transform.position = newPosition;
            }
        }
    }
}