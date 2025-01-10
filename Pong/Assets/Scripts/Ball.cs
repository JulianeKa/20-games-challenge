using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float ramdonDirection = .5f;
    private Rigidbody2D rigidbody2D;
    public int p1Points = 0;
    public int p2Points = 0;
    public Text p1PointsText;
    public Text p2PointsText;
    private int victoryLable = 0;
    public Text information;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Moviment();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space) && victoryLable == 1) {
            RestartGame();
        }
    }

    //Movimento da bola
    private void Moviment() {
        if(victoryLable == 0) {
            rigidbody2D.linearVelocity = new Vector2(speed, speed);
        }
    }

    //Verifica se houve colisão para realizar um movimento aleatório para evitar bug de movimento em sentido único
    void OnCollisionEnter2D(Collision2D collision) {
        rigidbody2D.linearVelocity += new Vector2(ramdonDirection, ramdonDirection);
    }

    //Verificar se houve gol
    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.CompareTag("LeftGoal") && victoryLable == 0) {
            transform.position = new Vector3(0f, 0f, 0f);
            Scoreboard(1);
        }
        if(trigger.CompareTag("RightGoal") && victoryLable == 0) {
            transform.position = new Vector3(0f, 0f, 0f);
            Scoreboard(2);
        }
    }

    //Atualiza o placar
    void Scoreboard(int player) {
        if(player==1) {
            p1Points++;
            p1PointsText.text = p1Points.ToString();
        }else if(player==2) {
            p2Points++;
            p2PointsText.text = p2Points.ToString();
        }
        ItWon();
    }

    //Verifica vitória
    void ItWon() {
        if(p1Points == 7 || p2Points == 7) {
            victoryLable = 1;
            information.text = "Victory! Pressione Espaço para reiniciar";
        }
    }

    void RestartGame() {
        transform.position = new Vector3(0f, 0f, 0f);
        victoryLable = 0;
        p1Points = 0;
        p2Points = 0;
        p1PointsText.text = p1Points.ToString();
        p2PointsText.text = p2Points.ToString();
        information.text = " ";
    }
}
