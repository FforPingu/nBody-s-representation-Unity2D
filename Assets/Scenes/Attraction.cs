using System.IO;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public Rigidbody2D[] attractors;
    public float minAttractionStrength = 234f;
    public float maxAttractionStrength = 760f;
    public float disturbanceMagnitude = 21f;
    public float minDistance = 1f;

    void FixedUpdate()
    {
        foreach (Rigidbody2D attractor in attractors)
        {
            if (attractor != null && attractor != GetComponent<Rigidbody2D>())
            {
                ApplyForce(attractor);
            }
        }
    }

    private void ApplyForce(Rigidbody2D attractor)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = attractor.position - rb.position;
        float distance = direction.magnitude;

        if (distance < minDistance)
        {
            return;
        }

        // Variabilità dell'intensità di attrazione
        float attractionStrength = Random.Range(minAttractionStrength, maxAttractionStrength);

        // Aggiunta di forze di disturbo casuali
        Vector2 disturbanceForce = Random.insideUnitCircle * disturbanceMagnitude;

        // Calcolo della forza di attrazione
        Vector2 force = direction.normalized * attractionStrength + disturbanceForce;

        rb.AddForce(force);
    }
}
