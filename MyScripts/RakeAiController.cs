using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RakeAiController : MonoBehaviour
{
    public Transform roamA;
    public Transform roamB;
    public GameObject EnemyAnimation;
    public GameObject killpositionone;
    public GameObject killpositiontwo;
    public bool follow = false;
    public bool endroambool = false;
    public int roamposition = 0;
    public bool randomPositionGenerator = true;
    public int move = 0;
    private int timer = 100;
    private int previousGoal = 1;
    private int huntNumb = 0;
    private int deathtimer = 0; 



    Vector3 rightforward = new Vector3(0.5f, 0, -1);
    Vector3 leftforward = new Vector3(-0.5f, 0, -1);


    public void Roam()
    {

        if (timer == 0 && deathtimer == 0)
        {
            if(previousGoal == 1)
            {
                huntNumb = Random.Range(1, 100);
                if(huntNumb < 60)
                {
                    roamposition = 2;
                }
                else if(huntNumb < 80 && huntNumb > 60)
                {
                    roamposition = 3;
                }
                else if (huntNumb < 100 && huntNumb > 80)
                {
                    roamposition = 4;
                }
            }
            else if (previousGoal == 2)
            {
                huntNumb = Random.Range(1, 100);
                if (huntNumb < 40)
                {
                    roamposition = 1;
                }
                else if (huntNumb < 70 && huntNumb > 40)
                {
                    roamposition = 3;
                }
                else if (huntNumb < 100 && huntNumb > 70)
                {
                    roamposition = 4;
                }
            }

            if (roamposition == 1)
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = roamA.position;
                previousGoal = roamposition;
                timer = 1000;
            }
            if (roamposition == 2)
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = roamB.position;
                previousGoal = roamposition;
                timer = 1000;

            }
            if (roamposition == 3)
            {
                deathtimer = 100;
                killpositiontwo.SetActive(false);
                killpositionone.SetActive(true);
                EnemyAnimation.SetActive(false);


            }
            if (roamposition == 4)
            {
                deathtimer = 100;
                killpositionone.SetActive(false);
                killpositiontwo.SetActive(true);
                EnemyAnimation.SetActive(false);

            }
        }
    if(deathtimer > 0)
        {
            deathtimer--;
        }
        else
        {
            killpositionone.SetActive(false);
            killpositiontwo.SetActive(false);
            EnemyAnimation.SetActive(true);

        }

        if (timer > 0 && deathtimer == 0)
        {
        timer--;
        }
}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("RandomPosition"))
        {
            randomPositionGenerator = true;

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Guy"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }



    void FixedUpdate()
    {
        if (follow == false)
        {
            Roam();
        }
    }
}
