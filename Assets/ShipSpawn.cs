using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    //Detta är min lista av skepp
    public List<GameObject> ships;


    // Use this for initialization
    void Start()
    {
        //Jag använder denna "Transformen" för att det ska väljas ett random skepp från min skepps lista.
        Transform.Instantiate(ships[Random.Range(0, ships.Count - 1)]);
        //Transform.Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
