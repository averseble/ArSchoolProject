using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class IsDetectedTarget : MonoBehaviour, ITrackableEventHandler
{
    //скрипт для того, чтобы узнать видит ли камера метку

    private TrackableBehaviour mTrackableBehaviour;

    private bool isDetected = false;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            isDetected = true;
        }
        else
        {
            isDetected = false;
        }      
    }

    public bool IsDetected()
    {
        return isDetected;
    }
}
