using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleLine : MonoBehaviour
{
    public Transform circleTransform;
    public LineRenderer lineRenderer;
    private int positionCount = 0;

    void Start()
    {
        updateLineRenderer();

    }


    void Update()
    {
        if (circleHasMoved())
        {
            updateLineRenderer();
        }


    }


    private void updateLineRenderer()
    {
        lineRenderer.positionCount = positionCount + 1; // Aggiungi un punto al LineRenderer
        lineRenderer.SetPosition(positionCount, circleTransform.position); // Imposta la posizione del nuovo punto
        positionCount++;
    }

    private bool circleHasMoved()
    {
        return true;
    }
}
