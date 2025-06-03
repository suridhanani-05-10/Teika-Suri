using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int number = 100;
    public int nunmmnnm = 12;
    public float nunmmnn = 12.5f;
    public int denominator = 5;
    public GameObject thing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        number = 52;


    }

    // Update is called once per frame
    void Update() {
       //Debug.Log(thing.name);
        Debug.Log(thing);
        float result = divideby10();
        Debug.Log(result);
    }


    float divideby10()
    {

        float divided = (float)number / (float)denominator; //5.2 -> 5
        //int / int -> int
        //int + int -> int
        //int / float -> float
        return divided;
    }
}
