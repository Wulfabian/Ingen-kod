using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeppet : MonoBehaviour

{
    public SpriteRenderer rend;
    public Color color;
    public float movespeed; //= 5f;
    //skapade två rotationspeeds eftersom innan när jag skulle göra så att man kan åka till höger
    //så fick jag error när jag satte minus framför rotationspeed variablen. 
    public float rotationspeed = 180f;
    public float time;
    public float xStart;
    public float yStart;
    public float randomms;

    // Use this for initialization
    void Start()
    {

        //x och y Start är random värden mellan kordinaterna som finns på bildskärmen


        xStart = Random.Range(-10f, 10f);
        yStart = Random.Range(-4f, 4f);
        //Med min "randomms" float så bestämmer jag ett random värde mellan 3 och 10 som jag sedan kommer använda
        //för skeppets hastighet
        randomms = Random.Range(3f, 10f);

        //Jag använder en InvokRepeting så att min timer function bara används 1 gång i sekunden.
        InvokeRepeating("timer", 1.0f, 1.0f);

        //Jag sätter X och Y värdet till mina 2 floats som jag skapat för x och y värdet så att den inte startar
        //utanför spelskärmen. Dessa floats är random range mellan två kordinater.
        transform.position = new Vector3((xStart), (yStart));

        //Här sätter jag min speed float till min randomms float som jag redan har randomiserat mellan 2 värden.
        movespeed = randomms;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movespeed * Time.deltaTime, 0, 0, Space.Self);
        //När "D" är nertryckt så svänger den åt höger, det gör jag genom att ändra variabeln
        //"rotationspeed" till negativ och sedan så eändrar jag färgen med rend.color till blå
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationspeed * Time.deltaTime);
            rend.color = Color.blue;
        }
        //Här har jag använt min variabel "rotationspeed" och sedan ändrat färgen till grön när "A" är nertryckt
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationspeed * Time.deltaTime - 1);
            rend.color = Color.green;
        }
        //Sålänge "S" är nertryckt så halveras skeppets hastighet
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-movespeed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }


        //Jag sätter alla färger, RGB (red green blue) till random value vilket gör att den slumpar mellan färgerna.
        //Jag ändrade också så att den bara ändrar färg när tangenten släpps
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rend.color = new Color(Random.value, Random.value, Random.value, 1f);
        }

        // Om skeppet kommer under x=-12 så flyttar jag den till 11, för om jag flyttar den till 12 så kommer den
        //att warpa tillbaka eftersom jag senare har en om x=12 så kommer den till -11. 
        //Exakt samma med y värdet
        if (transform.position.x <= -12)
        {
            transform.position = new Vector3(11, transform.position.y);
        }
        if (transform.position.x >= 12)
        {
            transform.position = new Vector3(-11, transform.position.y);
        }

        if (transform.position.y <= -6)
        {
            transform.position = new Vector3(transform.position.x, 5);
        }
        if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, -5);
        }

    }
    //Skapar en egen funktion för timern eftersom då kan jag själv bestämma hur ofta den ska printas istället
    //för o ha den i update där den printas hela tiden
    void timer()
    {
        //Jag sätter en Debug.Log (aka print) som visar en siffra varje sekund vilket motsvarar tid
        //tiden ökar med 1 varje frame.
        Debug.Log(string.Format("Timer:{0}", (time += 1)));

    }
}