using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    public GameObject impactEffect;
    public IntData scoreValue;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                scoreValue.Value += 1;
                // collision.gameObject.GetComponent<Collider>().enabled = false;
            }
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(impactEffect, pos, rot);
            Destroy(gameObject);

        }
}
