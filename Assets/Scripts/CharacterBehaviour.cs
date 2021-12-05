using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterBehaviour : MonoBehaviour
{
    private Animator anim;
    private const float characterSpeedFactor = 0.1f;
    private const float runStartSpeed = 0.1f;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 velocity = new(h, 0, v);

        var characterSpeed = velocity.magnitude;
        anim.SetFloat("Speed", characterSpeed);

        if (characterSpeed >= runStartSpeed)
            anim.speed = velocity.magnitude;
        else
            anim.speed = 1.0f; // reset animation speed to 1.0 when going to idle.

        transform.position += velocity * characterSpeedFactor;

        // do not rotate the charactor when it's not moving.
        if (characterSpeed > runStartSpeed)
        {
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}