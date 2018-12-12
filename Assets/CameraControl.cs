using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private RaceCar[] cars;
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float defaultSpeed;
    [SerializeField]
    private float delay;

    private RaceCar fastestCar;
    private Vector3 startPosition;
    private bool raceIsActive = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (raceIsActive && transform.position.x < endPosition.x) { 
            if (fastestCar != null) {
                transform.Translate(Vector3.right * fastestCar.GetComponent<Rigidbody2D>().velocity.magnitude * Time.deltaTime);
            } else {
                transform.Translate(Vector3.right * defaultSpeed * Time.deltaTime);
            }
        }
    }

    public void StartMoving()
    {
        for (int i = 0; i < cars.Length; ++i) {
            if (fastestCar == null || cars[i].maxSpeed > fastestCar.maxSpeed) {
                fastestCar = cars[i];
            }
        }
        StartCoroutine(StartMovingAfterDelay());
    }

    private IEnumerator StartMovingAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        raceIsActive = true;
    }

    public void Reset()
    {
        fastestCar = null;
        raceIsActive = false;
        transform.position = startPosition;
    }
}
