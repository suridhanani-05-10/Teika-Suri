using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public GameObject fruit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
        if (fruit !=null) {
            Vector3 fruitOffset = new Vector3(0f, -1f, 0f);
            fruit.transform.position = transform.position + fruitOffset;
            fruit.GetComponent<PolygonCollider2D>().enabled = false;
            fruit.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentFruit.GetComponent<PolygonCollider2D>().enabled = true;
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
            currentFruit = null;
        
        if ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.LeftArrow)))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed;
            transform.position = newPosition;
        }
        if ((Input.GetKey(KeyCode.D))||(Input.GetKey(KeyCode.RightArrow)))
        
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + speed;
            transform.position = newPosition;
        }
    }
}