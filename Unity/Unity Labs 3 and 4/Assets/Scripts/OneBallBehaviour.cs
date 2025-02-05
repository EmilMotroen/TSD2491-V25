using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float DegreesPerSecond = 180;
    public float Multiplier = 0.75F;
    public float TooFar = 5;

    static int BallCount = 0;
    public int BallNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BallCount++;
        BallNumber = BallCount;

        ResetBall();
    }
    private void ResetBall()
    {
        XSpeed = Multiplier - Random.value * Multiplier * 2;
        YSpeed = Multiplier - Random.value * Multiplier * 2;
        ZSpeed = Multiplier - Random.value * Multiplier * 2;

        transform.position = new Vector3(3 - Random.value * 6,
            3 - Random.value * 6, 3 - Random.value * 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * XSpeed,Time.deltaTime * YSpeed,Time.deltaTime * ZSpeed);
        XSpeed += Multiplier - Random.value * Multiplier * 2;
        YSpeed += Multiplier - Random.value * Multiplier * 2;
        ZSpeed += Multiplier - Random.value * Multiplier * 2;

        if ((Mathf.Abs(transform.position.x) > TooFar)
            || (Mathf.Abs(transform.position.y) > TooFar)
            || (Mathf.Abs(transform.position.z) > TooFar))
        {
            ResetBall();
        }
    }

    void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (!controller.GameOver)
        {
            controller.ClickedOnBall();
            Destroy(gameObject);
        }
    }
}
