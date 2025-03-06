using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Script : MonoBehaviour
{
    [Header("Person Info")]
    public Person thisPerson;
    public float height = 1.8f; // NPC height in meters

    public Material[] shirtMat;
    [Header("Movement info")]
    public float moveRadius = 10f;  // Radius within which the NPC will move
    public float waitTime = 2f;     // Time to wait before moving again
    private NavMeshAgent agent;
    private float timer;
    public bool canWave = false;

    [Header("Data")]
    [SerializeField] private DataReader dataReader;

    [Header("UI Text")]
    public TextMeshProUGUI genderText;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI heightText;

    [Header("Animations")]
    public Animator npcAnimator;
    // Voeg animaties toe

    private void Awake()
    {
        
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = waitTime;
        MoveToRandomLocation();

        dataReader = FindObjectOfType<DataReader>();
        SetInfo();
    }

    void Update()
    {
        if (!canWave)
        {
            // If NPC has reached the destination, wait for a moment before moving again
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    MoveToRandomLocation();
                    timer = waitTime;
                }
            }
        }
        npcAnimator.SetFloat("speed",agent.velocity.magnitude);
        npcAnimator.SetBool("canWave", canWave);
    }

    void MoveToRandomLocation()
    {
        Vector3 randomPoint;
        if (GetRandomPoint(transform.position, moveRadius, out randomPoint))
        {
            agent.SetDestination(randomPoint);
        }
    }

    bool GetRandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++) // Try multiple times to find a valid point
        {
            Vector3 randomPos = center + UnityEngine.Random.insideUnitSphere * range;
            randomPos.y = center.y;  // Keep it at the same height

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, range, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }
    public void TestShow()
    {
        Debug.Log($"Gender: {thisPerson.GENDER} - Age: {thisPerson.AGE} - Height: {thisPerson.HEIGHT_T2} ");
    }

    public void SetInfo()
    {
        SkinnedMeshRenderer skinnedMesh = GetComponentInChildren<SkinnedMeshRenderer>();

        thisPerson = dataReader.GetRandomPerson();
        if (thisPerson.GENDER == "1")
        {
            genderText.text = "Man";
            skinnedMesh.materials[0].color = Color.blue;
        }
        else
        {
            genderText.text = "Vrouw";
            skinnedMesh.materials[0].color = new Color32(255, 192, 203,1    );
        }

        ageText.text ="Leeftijd = " + thisPerson.AGE.ToString();

        heightText.text = "Lengte = "  + Mathf.Round(thisPerson.HEIGHT_T2).ToString();
    }
}
