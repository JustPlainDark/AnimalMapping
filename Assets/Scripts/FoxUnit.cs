using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class FoxUnit : MonoBehaviour
{

    [SerializeField]
    private GameObject den;

    Animator animator;
    public NavMeshAgent Agent;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //// check if the fox is really close to their den target then check if the animation is in transition
        if (Vector3.Distance(this.transform.position, den.transform.position) < 20f)
        {
            animator.SetBool("Walk", false);
            //if (animator.IsInTransition(0))
            //{
            //    animator.SetBool("Walk", false);
            //}

        }
        else if (Agent.hasPath)
        {
            animator.SetBool("Walk", true);
        }




        //// reached to destination
        ////(!Agent.pathPending && !Agent.hasPath)
        //if (Agent.hasPath)
        //{
        //    animator.SetBool("Walk", true);
        //    //Debug.Log("Walk = true");
        //}
        //else
        //{
        //    animator.SetBool("Walk", false);
        //    //Debug.Log("Walk = false");
        //}

    }


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        FoxManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }
}