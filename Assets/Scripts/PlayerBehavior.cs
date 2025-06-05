using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public GameObject[] fruits;
    public GameObject currentFruit;
    public float min;
    public float max;
    public GameObject gameOver;
    public int fruitType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
         

        if (currentFruit !=null) {
            fruitType = currentFruit.GetComponent <FruitBehavior>().fruitType;
                if (fruitType < 5) {
                    min = -6;
                    max = 6;
                } 

            Vector3 fruitOffset = new Vector3(0f, -1f, 0f);
            currentFruit.transform.position = transform.position + fruitOffset;
            //currentFruit.GetComponent<PolygonCollider2D>().enabled = false;
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        } else {
            int index = Random.Range(0, fruits.Length);
            currentFruit = Instantiate(fruits[index], transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
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

    public void GameOver() {
        gameOver.SetActive(true);
    }
}