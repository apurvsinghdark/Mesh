using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFunction : MonoBehaviour
{

    [SerializeField]
    Transform movingObject;
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 endPos;
    [SerializeField] float radius;
    [SerializeField] float duration;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Follow(movingObject, startPos, endPos, radius, duration);
        }
    }

    void Follow(Transform mover, Vector2 start, Vector2 end, float _radius, float _duration)
    {
        StartCoroutine(FollowArc(mover, start, end, _radius, _duration));
    }

    IEnumerator FollowArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float radius, // Set this to negative if you want to flip the arc.
        float duration) {

        GameManager Pin = GameManager.instance;

        Vector2 difference = end - start;
        float span = difference.magnitude;

        // Override the radius if it's too small to bridge the points.
        float absRadius = Mathf.Abs(radius);
        if(span > 2f * absRadius)
            radius = absRadius = span/2f;

        Vector2 perpendicular = new Vector2(difference.y, -difference.x)/span;
        perpendicular *= Mathf.Sign(radius) * Mathf.Sqrt(radius*radius - span*span/4f);

        Vector2 center = start + difference/2f + perpendicular;

        Vector2 toStart = start - center;
        float startAngle = Mathf.Atan2(toStart.y, toStart.x);

        Vector2 toEnd = end - center;
        float endAngle = Mathf.Atan2(toEnd.y, toEnd.x);

        // Choose the smaller of two angles separating the start & end
        float travel = (endAngle - startAngle + 5f * Mathf.PI) % (2f * Mathf.PI) - Mathf.PI;

        float progress = 0f;
        do {
            // Pin.turrent.parent = Pin.pin;
            float angle = startAngle + progress * travel;
            mover.localPosition = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime/duration;
            // Pin.turrent.parent = Pin.meshHolder;
            yield return null;
        } while (progress < 1f);

        mover.localPosition = end;

        // Assuming point[0] and point[2] are your starting point and destination
        // and all points are Vector3
        
        // point[1] = point[0] +(point[2] -point[0])/2 +Vector3.up *5.0f; // Play with 5.0 to change the curve
// 
        // float count = 0.0f;
// 
        // void Update() {
            // 
            // }
// 
        // float progress = 0f;
        // do {
            // if (count < 1.0f) {
                // count += 1.0f *Time.deltaTime;
// 
                // Vector3 m1 = Vector3.Lerp( point[0], point[1], count );
                // Vector3 m2 = Vector3.Lerp( point[1], point[2], count );
                // myObject.position = Vector3.Lerp(m1, m2, count);
            // }
            // progress += Time.deltaTime/duration;''
            // yield return null;
        // } while (progress < 1f);
        // }
    }

    
        // //For Center Position
            // if(zValue == 0 && xValue == 0)
            // {
            //     zValue = -2.9f;
            //     //xValue = -3;
            // }

            // if(isMoving)
            // {
            //     yield break;
            // }

            // isMoving = true;

            // float counter = 0;

            // Vector3 startPos = Pin.pin.localPosition;
            // //Vector3 toPos = new Vector3(Pin.pin.position.x, Pin.pin.localPosition.y + xValue, Pin.pin.localPosition.z - xValue);

            // while(counter < fValue)
            // {
            //     counter += Time.deltaTime;
            //     Pin.turrent_toolHolder.parent = Pin.pin;
            //     //Pin.pin.localPosition = Vector3.Lerp(startPos, toPos, counter / fValue);
            //     Pin.pin.localPosition += new Vector3(0f, xValue/4, -xValue/4) * fValue * Time.deltaTime;
            //     Pin.turrent_toolHolder.parent = Pin.turrent;
            //     yield return null;
            // }

            // isMoving = false;
    
}
