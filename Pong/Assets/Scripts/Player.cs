using UnityEngine;

public class Player : MonoBehaviour
{
    public int player = 1;
    public int speed = 200;
    public Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Movement();
    }

    private void Movement() {
        if (player == 1) {
            if (Input.GetKeyDown(KeyCode.W)) {
                rigidbody2D.AddForce(Vector2.up * speed);
            }
            else if (Input.GetKeyDown(KeyCode.S)) {
                rigidbody2D.AddForce(Vector2.down * speed);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                rigidbody2D.AddForce(Vector2.up * speed);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                rigidbody2D.AddForce(Vector2.down * speed);
            }
        }
    }
}
