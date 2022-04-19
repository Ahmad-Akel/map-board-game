using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollowPath : MonoBehaviour
{
    public Transform circleSprite;
    private LineRenderer _lr;

    void Start()
    {
        _lr = gameObject.AddComponent<LineRenderer>();
        _lr.startWidth = 0.1f;
        _lr.endWidth = 0.1f;
        int waveResolution = 20;
        _lr.positionCount = waveResolution;
        // Construct a sine wave out of lines, the more lines (waveResolution) the smoother it gets
        for (int i = 0; i < waveResolution; i++)
        {
            float p = i / (float)waveResolution;
            _lr.SetPosition(i, new Vector2(-2.5f + p * 5.0f, Mathf.Sin(p * Mathf.PI * 4)));
        }
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 closestPoint = Vector2.zero;
        float closestDistance = float.MaxValue;
        for (int i = 0; i < _lr.positionCount - 1; i++)
        {
            Vector2 p1 = _lr.GetPosition(i);
            Vector2 p2 = _lr.GetPosition(i + 1);
            var closestPointBetweenP1P2 = GetClosestPoint(p1, p2, mousePos);
            float distanceToClosestPoint = Vector2.Distance(closestPointBetweenP1P2, mousePos);
            if (distanceToClosestPoint < closestDistance)
            {
                closestDistance = distanceToClosestPoint;
                closestPoint = closestPointBetweenP1P2;
            }
        }
        circleSprite.position = closestPoint;
    }

    private Vector2 GetClosestPoint(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        Vector2 from_p1_to_p3 = p3 - p1;
        Vector2 from_p1_to_p2 = p2 - p1;
        float dot = Vector2.Dot(from_p1_to_p3, from_p1_to_p2.normalized);
        dot /= from_p1_to_p2.magnitude;
        float t = Mathf.Clamp01(dot);
        return p1 + from_p1_to_p2 * t;
    }
}
