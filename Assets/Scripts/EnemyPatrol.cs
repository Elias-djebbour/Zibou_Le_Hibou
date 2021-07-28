using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed; // vitesse de la patrol
    public Transform[] waypoints; // les destinations

    public Transform target; // la prochaine destinations
    public int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        // On détermine la distance entre la target et l'ennemi
        Vector3 direction = target.position - transform.position; 
        // On défini le déplacement de la patrol
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); 

        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }
}
