using UnityEngine;
using System;
using System.Collections;

public class CurveMoment : MonoBehaviour {

    public Transform sunrise;
    public Transform sunset;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    public G02 G02command; 


    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;

        //G02command.FollowCircle += Follow;
        
        //StartCoroutine(CircularInterpolation());
    }

    void Follow()
    {
        //StartCoroutine(FollowArc(mover, start, end, _radius, _duration));
        //StartCoroutine(CircularInterpolation());
    }

    // void Update()
    // {
    //     // The center of the arc
    //     Vector3 center = (sunrise.position + sunset.position) * 0.5F;

    //     // move the center a bit downwards to make the arc vertical
    //     center -= new Vector3(0, 2, 0);

    //     // Interpolate over the arc relative to center
    //     Vector3 riseRelCenter = sunrise.position - center;
    //     Vector3 setRelCenter = sunset.position - center;

    //     // The fraction of the animation that has happened so far is
    //     // equal to the elapsed time divided by the desired time for
    //     // the total journey.
    //     float fracComplete = (Time.time - startTime) / journeyTime;

    //     transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
    //     transform.position += center;
    // }

    IEnumerator CircularInterpolation()
    {
        do{
            // The center of the arc
            Vector3 center = (sunrise.position + sunset.position) * 0.5F;

            // move the center a bit downwards to make the arc vertical
            center -= new Vector3(0, 1, 0);

            // Interpolate over the arc relative to center
            Vector3 riseRelCenter = sunrise.position - center;
            Vector3 setRelCenter = sunset.position - center;

            // The fraction of the animation that has happened so far is
            // equal to the elapsed time divided by the desired time for
            // the total journey.
            float fracComplete = (Time.time - startTime) / journeyTime;

            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;

            yield return null;

        }while(Vector3.Distance(sunrise.position,sunset.position) > 0.1f);
        
        //yield return null;
    }
}