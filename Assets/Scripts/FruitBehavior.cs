using UnityEngine;
using TMPro;

public class FruitBehavior : MonoBehaviour{
    public float timeout;
    public float timeStart;
    public float timeThusFar;
    public GameObject gameOver;
    public GameObject[] fruits;
    public int fruitType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        timeStart = Time.time; //Get current Time
        fruits = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().fruits;
    
    }

    // Update is called once per frame
    void Update(){

    }

public void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Fruit")) {
        GameObject otherFruit = collision.gameObject;
        int otherFruitType = otherFruit.GetComponent<FruitBehavior>().fruitType;
        if (fruitType == otherFruitType && fruitType != 9) {
            
            if (transform.position.x > otherFruit.transform.position.x ||
                (transform.position.y > otherFruit.transform.position.y
                && transform.position.x == otherFruit.transform.position.x)) {
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().UpdateScore(fruitType);
                GameObject newFruit = 
                    Instantiate(fruits[fruitType+1], Vector3.Lerp(transform.position,
                    otherFruit.transform.position, 0.5f), Quaternion.identity);
                newFruit.GetComponent<Collider2D>().enabled = true;
                newFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                Destroy(otherFruit);
                Destroy(gameObject);
            }
        }
    }
}


public void OnTriggerEnter2D(Collider2D collision) {
    string tag = collision.gameObject.tag;
    Debug.Log("You entered the trigger of: " + collision.gameObject.name);
    if (collision.gameObject.CompareTag("Top")) {
        Debug.Log("Game over Timer started at: " + timeStart);
        timeStart = Time.time; //Get current Time
    }
}

public void OnTriggerStay2D(Collider2D collision) {
    string tag = collision.gameObject.tag;
    Debug.Log("You are in trigger of: " + collision.gameObject.tag);
    if (tag.Equals("Top")){
        timeThusFar = Time.time - timeStart;
        Debug.Log("Game over Timer updated: " + timeThusFar);
        if (timeThusFar >= timeout) {
            //Debug.Log("Game over");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().GameOver();
        }
    }

}
}
