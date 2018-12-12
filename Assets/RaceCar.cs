using UnityEngine;
using System.Collections;

public class RaceCar : MonoBehaviour
{
    public RaceStarter raceStarter;
    [HideInInspector]
    public float maxSpeed;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D carRigidbody;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Vector2 startingPosition;
    private float acceleration;
    private float reactionTime;
    private bool raceActive = false;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (raceActive) {
            carRigidbody.AddForce(Vector2.right * acceleration, ForceMode2D.Impulse);
            if (carRigidbody.velocity.magnitude > maxSpeed) {
                carRigidbody.velocity = Vector2.right * maxSpeed;
            }
        }
    }

    public void SetUpAndStartRace()
    {
        SetUp();
        StartCoroutine(StartRace());
    }

    private void SetUp()
    {
        spriteRenderer.sprite = raceStarter.vehicleBody.sprite;
        spriteRenderer.color = raceStarter.vehicleColor.color;
        acceleration = raceStarter.tires.accelerationCoefficient *  10f * speed;
        maxSpeed = speed * 2 + raceStarter.engine.maxSpeedCoefficient;
        reactionTime = 1f / (2 + raceStarter.vehicleColor.reactionTimeCoefficient);
        carRigidbody.drag = 1f / raceStarter.vehicleBody.aerodynamicsCoefficient;
    }

    private IEnumerator StartRace()
    {
        yield return new WaitForSeconds(reactionTime);
        raceActive = true;
    }

    public void EndRace()
    {
        raceActive = false;
        carRigidbody.velocity = Vector2.zero;
    }

    public void Reset()
    {
        EndRace();  
        transform.position = startingPosition;
    }
}
