/**
 * Gilvã Lopes e Isac Aguiar
 * Space Ship
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
    public int speed = 6;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()  { }

    // Update is called once per frame
    void Update() { }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }    
}
