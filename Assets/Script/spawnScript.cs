using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gilvã Lopes e Isac Aguiar
 * Space Ship
 */
public class spawnScript : MonoBehaviour
{
    public GameObject enemy;
    float spawnTime = 1;
    public int score = 0;
    public int life = 3;
    public Font font;

    void Start() {
        InvokeRepeating("addEnemy", 0, spawnTime);        
    }

    void Update() { }

    void addEnemy() {
        Debug.Log("Adicionando inimigo ");

        var rd = GetComponent("Renderer") as Renderer;
        var x1 = transform.position.x - rd.bounds.size.x/2;
        var x2 = transform.position.x + rd.bounds.size.x/2;
        var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }

    public MessageBox box;
    void OnGUI() {
        if (!font)
        {
            print("No font found, assign one in the inspector.");
        }
        GUI.skin.font = font;
        GUI.skin.label.fontSize = (int)(Screen.width / 20.0f);
        GUI.Label(new Rect((Screen.width/2) - 300, 40, 400, 400), "Vida(s): " + life);
        GUI.Label(new Rect((Screen.width/2) - 300, 100, 400, 400), "Pontuação: " + score);
        GUI.skin.label.fontSize = (int)(Screen.width / 13.0f);
        GUI.Label(new Rect((Screen.width/2) + 10, 30, 400, 400), "Space Ship");
        if(life == 0) {
            GUI.skin.label.fontSize = (int)(Screen.width / 9.0f);
            GUI.Label(new Rect((Screen.width/2) - 250, 500, 600, 600), "Fim de Jogo");
            GUI.skin.label.fontSize = (int)(Screen.width / 10.0f);
            GUI.Label(new Rect((Screen.width/2) - 40, 400, 400, 400), score.ToString());

            box.DialogWindow(1);
        }
        
        
    }
}