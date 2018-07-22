using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float travelSpeed = 1f;
    [SerializeField] private float distanceTolerance = .01f;

    private Vector3 orginVector3;
    private Transform destinationMarker;
    private float startMoveTime;
    private float distanceOfTravel;

    private void Awake()
    {
        TravelNode.OnNavigationInteract += HandleNavigationInteract;
    }

    private void HandleNavigationInteract(TravelNode node)
    {
        SetTravelLocation(node.transform);
    }

    private void SetTravelLocation(Transform transform)
    {
        orginVector3 = transform.position;
        destinationMarker = transform;
        startMoveTime = Time.time;
        distanceOfTravel = Vector3.Distance(orginVector3, destinationMarker.position);
    }

    private void Update()
    {
        if (destinationMarker == null) return;

        DoTheMove(Time.deltaTime);
        if (CloseEnoughToDestination()) destinationMarker = null;
    }

    private void DoTheMove(float deltaTime)
    {
        transform.LookAt(destinationMarker);
       transform.position += transform.forward * deltaTime * travelSpeed;
    }

    private bool CloseEnoughToDestination()
    {
        return Vector3.Distance(transform.position, destinationMarker.position) <= distanceTolerance;
    }
}