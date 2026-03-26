using UnityEngine;

public class DeleteOnCall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DestroyObj()
	{
        Debug.Log("kerblam");
		Destroy(this.gameObject);
	}
}
