using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float screenLeftEdge;

    private void Start() {
        // add an offset (-1f), so we're sure the element already
        // left the screen 
        screenLeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < screenLeftEdge) {
            Destroy(gameObject);
        }
    }
}
