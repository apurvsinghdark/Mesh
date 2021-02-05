using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularArc : MonoBehaviour
{

    public G02 G02command; 
    public G03 G03command;
    
    public GameObject CHISEL;
    public Transform start;
    public Transform end;

    Vector3 endPos;

    private float startTime;

    private void Start() {
        // Note the time at the start of the animation.
        startTime = Time.time;

        G02command.FollowCircle += Follow;
        G03command.FollowCircle += Follow;
    }

    void Follow(float xValue, float zValue, float _radius, float _duration)
    {
        //StartCoroutine(FollowArc(mover, start, end, _radius, _duration));
        StartCoroutine(CircularInterpolation(xValue, zValue, _radius, 30));
    }

    void Follow(Transform mover, Vector2 start, Vector2 end, float _radius, float _duration)
    {
        //StartCoroutine(FollowArc(mover, start, end, _radius, _duration));
        StartCoroutine(FollowArc(mover, start, end, _radius, _duration));
    }

    IEnumerator FollowArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float radius, // Set this to negative if you want to flip the arc.
        float duration) {

        //float percentXValue = - 
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
            Pin.turrent_toolHolder.parent = Pin.pin;
            float angle = startAngle + progress * travel;
            mover.localPosition = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime/duration;

            Pin.turrent.localPosition = new Vector3(Pin.pin.localPosition.x + 52.7f,Pin.turrent.localPosition.y ,Pin.turrent.localPosition.z);
            Pin.turrent_toolHolder.parent = Pin.turrent;
            yield return null;
        } while (progress < 1f);

        mover.localPosition = end;
        //Pin.turrent_toolHolder.localPosition = new Vector3(Pin.turrent_toolHolder.localPosition.x, 1.38f, Pin.turrent_toolHolder.localPosition.z);
    }

    IEnumerator CircularInterpolation(float xValue, float zValue, float _radius, float _duration)
    {
        GameManager Pin = GameManager.instance;


        float percentZValue = (zValue/100) * 17.5f;
        float percentXValue = (xValue/100) * 17.5f;
        //Debug.Log(percentValue);
        float newXPosition = -35.2f - percentZValue;
        float newZPosition = -3f - percentXValue;

        //end = new Vector3(-32.86f, -4.90000f);
        
        do{
            //Pin.turrent.parent = Pin.pin;

            // The center of the arc
            Vector3 center = (start.localPosition + end.localPosition) * 0.5F;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 1f, 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = start.localPosition - center;
            Vector3 setRelCenter = end.localPosition - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - startTime) / _duration;

            CHISEL.transform.localPosition = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            CHISEL.transform.localPosition += center;

            //Pin.turrent.parent = Pin.meshHolder;

            yield return null;
        }while(Vector3.Distance(start.localPosition, end.localPosition) > 0.1f);
        
        ///start.position = end;

    }
}
