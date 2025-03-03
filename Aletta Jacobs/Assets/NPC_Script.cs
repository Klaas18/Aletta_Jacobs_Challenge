using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Script : MonoBehaviour
{
    [Header("Person Info")]
    public Person thisPerson;
    public float height = 1.8f; // NPC height in meters

    [Header("Walking Info")]
    public float moveSpeed = 2f;
    public float wanderRadius = 5f;
    public float waitTime = 2f;

    [Header("Movement Info")]
    private Vector3 targetPosition;
    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        thisPerson = FindObjectOfType<DataReader>().GetRandomPerson();

        transform.localScale = new Vector3(1, Mathf.Round(thisPerson.HEIGHT_T2 /100), 1); // Adjust height


        StartCoroutine(Wander());
    }

    IEnumerator Wander()
    {
        while (true)
        {
            if (!isMoving)
            {
                targetPosition = GetRandomPosition();
                isMoving = true;
            }

            Vector3 direction = (targetPosition - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
            {
                rb.velocity = Vector3.zero;
                isMoving = false;
                yield return new WaitForSeconds(waitTime);
            }

            yield return null;
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        randomDirection.y = transform.position.y;
        return randomDirection;
    }

    void OnLookedAt()
    {
        // Add player interaction info here
        // Example: Display NPC name, story, or dialogue
    }
    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }
    public void TestShow()
    {
        Debug.Log($"Gender: {thisPerson.GENDER} - Age: {thisPerson.AGE} - Height: {thisPerson.HEIGHT_T2} ");
    }
}
