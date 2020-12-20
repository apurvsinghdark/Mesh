using UnityEngine;

public class BoxMove : MonoBehaviour
{
    private float Animation;

    //[SerializeField] float radius;

    private void Start() {
        //radius = 4;
    }

    private void Update() {
        // timeCounter += Time.deltaTime;

        // float x = Mathf.Cos(timeCounter) * radius;
        // float y = Mathf.Sin(timeCounter) * radius;
        
        // transform.position = new Vector2(transform.position.x * y,transform.position.y * x);

        Animation += Time.deltaTime;

        Animation = Animation % 5f;

        Vector2 pos = transform.position;

        transform.position = MathParabola.Parabola(pos, new Vector2(20,-7), 4f, Animation / 5f);

    }

    
} 
