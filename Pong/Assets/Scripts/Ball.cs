using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float ramdonDirection = .5f;
    private Rigidbody2D rigidbody2D;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Moviment();
    }

    private void Update() {
        
    }

    private void Moviment() {
        rigidbody2D.linearVelocity = new Vector2(speed, speed);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        rigidbody2D.linearVelocity += new Vector2(ramdonDirection, ramdonDirection);
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.CompareTag("Goal")) {
            transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
