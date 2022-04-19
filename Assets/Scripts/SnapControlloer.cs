using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapControlloer : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<DragDrop> draggableObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(DragDrop draggable in draggableObjects)
        {
            draggable.dragEndedCallback = onDragEnded;
        }
    }
    private void onDragEnded(DragDrop draggable)
    {
        float closestDistance = -1;
        Transform closestPoint = null;
        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closestPoint == null || currentDistance < closestDistance)
            {
                closestPoint = snapPoint;
                closestDistance = currentDistance;
            }

        }
        if(closestPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestPoint.localPosition;
        }
    }

}
