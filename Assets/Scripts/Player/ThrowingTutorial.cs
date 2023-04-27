using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingTutorial : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public GameObject attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;
    public Text numberOfThrows;
    public Animator shootAnim;

    [Header("Throwing")]
    public KeyCode rightThrowKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Audio")]
    public AudioSource knifeThrowSound;

    bool readyToThrow;
    

    private void Start()
    {
        numberOfThrows.text = "Knifes: " + totalThrows.ToString();

        readyToThrow = true;
        
    }

    private void Update()
    {
        numberOfThrows.text = "Knifes: " + totalThrows.ToString();

        if (Input.GetKeyDown(rightThrowKey) && readyToThrow && totalThrows > 0)
        {
            knifeThrowSound.Play();
            shootAnim.SetBool("IsShooting", true);
           
            Throw();
        }
        else if (totalThrows <= 0)
        {
            shootAnim.SetBool("IsShooting", false);
            print("No Knifes Left");
        }
        else
        {
            shootAnim.SetBool("IsShooting", false);
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.transform.position, cam.rotation);
        
        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.transform.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
        
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}