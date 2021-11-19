using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
    public int speed = -5;

    public GameObject enemy;
    public AudioSource audioExplosaoSrc;
    public AudioSource audioGameOverSrc;

    Rigidbody2D r2d;
    void Start() {
        r2d = GetComponent("Rigidbody2D") as Rigidbody2D;
        r2d.velocity = new Vector3(0, 0, 0);      
        r2d.angularVelocity = Random.Range(-200, 200);
    }
    
    void Update() { }

    void OnBecameInvisible() {
        Destroy(gameObject);
    } 

    void OnTriggerEnter2D(Collider2D obj) {
        var name = obj.gameObject.name;
        spawnScript spaceship = GameObject.Find("spawn").GetComponent<spawnScript>();
        if (name == "bullet(Clone)") {
            if(spaceship.life > 0) {
                audioExplosaoSrc.Play();
                Destroy(gameObject);
                Destroy(obj.gameObject);
                spaceship.score++;
            }
        }

        if (name == "spaceship") {
            if(spaceship.life == 1) {
                audioGameOverSrc.Play();
            }
            if(spaceship.life > 0) {
                Destroy(gameObject);
                spaceship.life--;
            }
        }
    } 
    
}
