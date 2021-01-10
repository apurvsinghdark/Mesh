using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularArc : MonoBehaviour
{

    public G02 G02command; 
    public G03 G03command; 

    private void Start() {
        G02command.FollowCircle += Follow;
        G03command.FollowCircle += Follow;
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
            Pin.turrent.parent = Pin.pin;
            float angle = startAngle + progress * travel;
            mover.localPosition = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime/duration;
            Pin.turrent.parent = Pin.meshHolder;
            yield return null;
        } while (progress < 1f);

        mover.localPosition = end;
    }
}
