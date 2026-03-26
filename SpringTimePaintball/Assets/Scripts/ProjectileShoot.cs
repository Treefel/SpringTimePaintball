using System;
using UnityEngine;
public class ProjectileShoot : MonoBehaviour
{
    // [SerializeField]
    // private LineRenderer LineRenderer;

    // [Header("Display Controls")]
    // [SerializeField]
    // [Range(10, 100)]
    // private int LinePoints = 25;

    // [SerializeField]
    // [Range(0.01f, .25f)]
    // private float TimeBetweenPoints = 0.1f;

    // [SerializeField]
    // private Vector3Data mouseCursor;
    // private Camera cam;
    // private Transform camPos;
    // [SerializeField] private Transform playerPos;

    // private Rigidbody rb;

    // private Vector3 target;
    // private Vector3 dir;
    public float forceValue = 120f;
    // private GameObject curObject;
    // private Transform parentObj;
    // // private bool prepFire;
    // private bool fired;

    [SerializeField] private GameObject bulletObj;
    [SerializeField] private GameObject bulletSpawn;
    // private Vector3 mousePos;


    // void Awake()
    // {
    //     curObject = this.gameObject;
    //     rb = curObject.GetComponent<Rigidbody>();
    //     parentObj = curObject.transform.parent;
    //     cam = Camera.main;
    //     camPos = cam.transform;
        
    //     // mousePos = mouseCursor.value;
    // }

    // void Update()
    // {
    //     //  if (Input.GetButton("Fire1"))
    //     // {
    //     //     prepFire = true;
    //     //     trackMouse();
    //     // }
    //     // if (Input.GetButtonUp("Fire1"))
    //     // {
    //     //     GetDirection();
    //     //     addProjForce();
    //     // }
    // }

    // public void addProjForce()
    // {
    //     if (!fired)
    //     {
    //         GetDirection();
    //         fired = true;
    //         rb.linearVelocity = Vector3.zero;
    //         rb.AddForce(Vector3.forward * forceValue, ForceMode.Impulse);
    //     }
    // }

    public void shoot()
    {
        Debug.Log("Shoot");
        GameObject bullet = Instantiate(bulletObj, bulletSpawn.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * forceValue);
        Destroy(bullet, 5);
    }


    // public void trackMouse()
    // {
    //     target = new Vector3(
    //         mouseCursor.value.x - curObject.transform.position.x,
    //         mouseCursor.value.y - curObject.transform.position.y,
    //         mouseCursor.value.z - curObject.transform.position.z
    //     );
        
    //     GetDirection();
    //     DrawProjection();
    // }
    // private void GetDirection()
    // {
    //     // parentObj = curObject.transform.parent;
    //     rb.rotation = Quaternion.Euler(
    //         camPos.rotation.eulerAngles.x, 
    //         camPos.rotation.eulerAngles.y, 
    //         camPos.rotation.eulerAngles.z
    //         );
    // }

    // private void GetDirection()
    // {
    //     float signX = target.x * Math.Sign(target.x);
    //     float signY = target.y * Math.Sign(target.y);
    //     float total = signX + signY;
    //     dir = new Vector3(
    //         target.x / total,
    //         target.y / total,
    //         0
    //     );
    // }

    // private void DrawProjection()
    // {      
    //     LineRenderer.enabled = true;
    //     LineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
    //     Vector3 startPosition = curObject.transform.position;
    //     Vector3 curPosition = startPosition;
    //     Vector3 startVelocity = dir * forceValue / rb.mass;
    //     Vector3 velocity = startVelocity;        

    //     int i = 0;
    //     LineRenderer.SetPosition(i, startPosition);
    //     for (float time = 0; time < LinePoints; time += TimeBetweenPoints)
    //     {
    //         i++;
    //         velocity += Physics.gravity * time;
    //         Vector3 point = startPosition + time * velocity;
    //         point = curPosition + velocity * time;            
    //         curPosition = point;
    //         LineRenderer.SetPosition(i, point);
    //     }
    // }
}
