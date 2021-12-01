/**
 * Gilvã Lopes e Isac Aguiar
 * Space Ship
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipScript : MonoBehaviour
{
    private Vector3 position; 
    private float width;
    private float height;
    public GameObject clone;
    public GameObject bullet;
    public int timeoutDestructor;
    public Transform target;
    public float speed;
    public int score = 0;
    public int scoreFinal = 0;
    public int life = 3;
    public AudioSource audioBulletSrc;

    void Awake() {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Start() {
        emitirSomTiro();
     }

    public void init() {
        life = 3;
        scoreFinal = score;
        score = 0;
    }

    void emitirSomTiro() {
        audioBulletSrc.Play();
    }
    void tiro() {
        emitirSomTiro();
        float step;
        clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        step = speed * Time.deltaTime;
        Debug.Log("Step: "+ step);
        clone.GetComponent<Rigidbody2D>()
            .AddRelativeForce(new Vector3(target.position.x * step, target.position.y * step, 10));
    } 
    void Update() {
        
        // Handle screen touches.
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; ++i) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    tiro();
                }
            }

            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved) {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / 150;
                pos.y = (pos.y - height) / 150;
                position = new Vector3(pos.x, pos.y, 0.0f);
                Debug.Log("Width: "+ width + " Height: "+ height);
                Debug.Log("-----------------------------------------------");
                transform.position = position;
            }

            if (Input.touchCount == 2) {
                touch = Input.GetTouch(1);
                if (touch.phase == TouchPhase.Began) transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                if (touch.phase == TouchPhase.Ended) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                
            }
        }
    }

    
}
