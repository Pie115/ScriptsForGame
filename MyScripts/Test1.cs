using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.AI;  public class Test1 : MonoBehaviour {    // private NavMeshAgent navMesh;     public Transform Player;     public Transform[] randomPoints;     public Transform goal;     public AudioClip Shotsound;
    public AudioClip KillPlayer;
    public AudioClip followsound;      public float perceptionDistance = 30, chaseDistance = 20, attackDistance = 1, walkVelocity = 10, chaseVelocity = 20, attackTime = 1.5f, enemyDamage = 100;     public bool seeingPlayer;     public float enemyLife;     public float totalEnemyLife = 100;     public string GameOverScene;     public int Playerlife;     public int totalPlayerlife = 100;     public int currentRandomPoint;

    private AudioSource rakeAudio;     private NavMeshAgent navMesh;     private bool chasing, chaseTime, attacking;     private float chaseStopwatch, attackingStopwatch;     private float playerDist;

    protected Animator animator;  

    void Walk()     {          if (chasing == false)         {              navMesh.acceleration = 4;             navMesh.speed = walkVelocity;
            //   navMesh.destination = randomPoints[currentRandomPoint].position;

        }         else
        {              chaseTime = true;         }     }      void Look()
    {         navMesh.speed = 10;         transform.LookAt(Player);     }      void Chase()
    {          navMesh.acceleration = 8;         navMesh.speed = chaseVelocity;         navMesh.destination = Player.position;     }      void Attack()
    {          animator.SetBool("Attack", true);         navMesh.acceleration = 0;         navMesh.speed = 0;         attacking = true;     }

    void OnCollisionEnter(Collision col)     {         if (col.transform.tag == "Bullet")         {
            rakeAudio.PlayOneShot(Shotsound, 2.0f);             enemyLife -= 20;             if (enemyLife <= 0)             {                 animator.SetBool("Dying", true);                 seeingPlayer = false;                 walkVelocity = 0;                 attackDistance = 0;                 chaseVelocity = 0;                 chaseDistance = 0;                 enemyDamage = 0;                 currentRandomPoint = 0;

                // SceneManager.loadscene(GameOverScene);
                //GameOverScene();
            }         }     }       void PlayStart()
    {

        animator = GetComponent<Animator>();         currentRandomPoint = Random.Range(0, 0);          navMesh = transform.GetComponent<NavMeshAgent>();         enemyLife = totalEnemyLife;         Playerlife = totalPlayerlife;

    }      void WhilePlaying()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();         agent.destination = goal.position;         playerDist = Vector3.Distance(Player.transform.position, transform.position);         transform.LookAt(Player);         //         //randomPointDist = Vector3.Distance(0, 0);         //transform.position, transform.position);          RaycastHit hit;          Vector3 startRay = transform.position;         Vector3 endRay = Player.transform.position;         Vector3 direction = endRay - startRay;          if (Physics.Raycast(transform.position, direction, out hit, 1000) && playerDist < perceptionDistance)         {             Debug.Log(hit.collider.gameObject.CompareTag("Main Camera"));             if (hit.collider.gameObject.CompareTag("Main Camera"))             {                 seeingPlayer = true;             }             else             {                 seeingPlayer = false;             }         }          if (playerDist > perceptionDistance)             Walk();          if (playerDist <= perceptionDistance && playerDist > chaseDistance)         {             if (seeingPlayer == true)                 Look();             else                 Walk();         }          if (playerDist <= chaseDistance && playerDist > attackDistance)         {             if (seeingPlayer == true)             {                 Chase();                 chasing = true;             }             else             {                 Walk();             }         }          if (playerDist <= attackDistance && seeingPlayer == true)             Attack();          if (chaseTime == true)             chaseStopwatch += Time.deltaTime;          if (chaseStopwatch >= 5 && seeingPlayer == false)         {             chaseTime = false;             chaseStopwatch = 0;             chasing = false;         }          if (attacking == true)             attackingStopwatch += Time.deltaTime;          if (attackingStopwatch >= attackTime && playerDist <= attackDistance)         {             attacking = true;             attackingStopwatch = 0;             Playerlife = Playerlife - 50;              if (Playerlife <= 50)             {                   // SceneManager.LoadScene(GameOverScene);             }             else if (attackingStopwatch >= attackTime && playerDist > attackDistance)             {                 attacking = false;                 attackingStopwatch = 0;             }          }
    }       void Start()     {         PlayStart();     }      void Update()     {         WhilePlaying();     }    } 