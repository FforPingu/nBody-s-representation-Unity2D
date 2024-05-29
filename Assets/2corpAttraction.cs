using System.IO;
using UnityEngine;

public class GravitationalAttraction : MonoBehaviour
{
    public Rigidbody2D body1;
    public Rigidbody2D body2;
    public Rigidbody2D body3; // Aggiungi il terzo corpo
    public float gravitationalConstant = 4f;

    void Start()
    {
        float initialVelocity = 0.01f; // Imposta questo valore in base alle esigenze del tuo sistema
        body2.velocity = new Vector2(0, initialVelocity);
        body3.velocity = new Vector2(2, initialVelocity);
        body1.velocity = new Vector2(1, initialVelocity);// Imposta una velocità iniziale per il terzo corpo
    }

    void FixedUpdate()
    {
        ApplyGravitationalForce(body1, body2);
        ApplyGravitationalForce(body2, body1);

        ApplyGravitationalForce(body1, body3);
        ApplyGravitationalForce(body3, body1);

        ApplyGravitationalForce(body2, body3);
        ApplyGravitationalForce(body3, body2);
    }

    void ApplyGravitationalForce(Rigidbody2D bodyA, Rigidbody2D bodyB)
    {
        Vector2 direction = bodyB.position - bodyA.position;
        float distance = direction.magnitude;

        if (distance < 1)
            return;

        float forceMagnitude = gravitationalConstant * (bodyA.mass * bodyB.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        bodyA.AddForce(force);
    }
}