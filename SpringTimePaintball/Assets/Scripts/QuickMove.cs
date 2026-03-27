using UnityEngine;

public class QuickMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private GameObject curObject;
    private Quaternion ogState;
    private Rigidbody rb;
    public bool moving = false;
    private int i = 0;
    [SerializeField] private Vector3DataCollection collection;

    void Awake()
    {
        i = 0;
        curObject = this.gameObject;
        // ogState = new Quaternion(
        //     curObject.transform.rotation.x,
        //     curObject.transform.rotation.y,
        //     curObject.transform.rotation.y,
        //     curObject.transform.rotation.w
        //     );

        if (curObject.GetComponent<Rigidbody>() !=null)
        {
            rb = curObject.GetComponent<Rigidbody>();
            ogState = rb.rotation;
        }
        
        
    }

    void Update()
    {
        if (moving && collection != null)
            MoveBetweenPoints();
    }

    // Update is called once per frame
    public void RotateTo(Transform target)
    {
        var step = speed * Time.deltaTime;
        // curObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        // curObject.transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, step);
        // curObject.transform.rotation = target.rotation;
        rb.MoveRotation(target.rotation);
    }

    public void ReturnToOriginal()
    {
        if (ogState != rb.rotation)
        {
            var step = speed * Time.deltaTime;
            // curObject.transform.rotation = Quaternion.Slerp(transform.rotation, ogState.rotation, step);
            // curObject.transform.rotation = ogState.rotation;
            rb.MoveRotation(ogState);
        }

    }
    public void ReturnToZero()
    {
        var step = speed * Time.deltaTime;
        Quaternion zeroQuat = new Quaternion (0, 0, 0, 1);
        // curObject.transform.rotation = Quaternion.Slerp(transform.rotation, zeroQuat, step);
        // curObject.transform.rotation = zeroQuat;
        rb.MoveRotation(zeroQuat);
    }

    public void SetOriginalPosition(Transform newOGState)
    {
        ogState = new Quaternion(
            newOGState.rotation.x,
            newOGState.rotation.y,
            newOGState.rotation.y,
            newOGState.rotation.w
            );
        // ogState = new Quaternion(
        //     newOGState.x,
        //     newOGState.y,
        //     newOGState.y,
        //     newOGState.w
        //     );
    }

    public void MoveBetweenPoints()
    {
        
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, collection.vector3Datas[i].value, step);
        if (curObject.transform.position == collection.vector3Datas[i].value)
        {
            i++;
            if (i >= collection.vector3Datas.Count)
            {
                i = 0;
            }
        } 
    }

    public void SetMoving(bool newMoving)
    {
        moving = newMoving;
    }
}
