using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
     //A janela 200x300 px aparecerá no centro da tela.
     private Rect windowRect = new Rect(0, 0, 500, 200);
     //Variavel para controlar a visibilidade.
     //private bool show = false;

     public GUISkin customSkin;

     public Font font;

     void onStart() {
        windowRect.center = new Vector2(10, 10);
     }

    void OnGUI () { }

    //Este é o metodo que cria a janela
    public void DialogWindow (int windowID)
    {
        if (!font)
        {
            print("No font found, assign one in the inspector.");
        }
        spawnScript spaceship = GameObject.Find("spawn").GetComponent<spawnScript>();
        //GUI.skin.font = font;
        GUI.skin.button.font = font;
        GUI.skin.button.fontSize = (int)(Screen.width / 10.0f);
        if(GUI.Button(new Rect(120, 650, windowRect.width - 10, 120), "Iniciar Jogo")) {
            print("Clique");
            spaceship.life = 3;
            spaceship.score = 0;
        }
           
    }

    //Para abrir o diálogo de você chama este método no botão que você criou na tela
    public void Open() {
        print("Open");
    }
}