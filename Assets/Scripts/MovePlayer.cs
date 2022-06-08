using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovePlayer : MonoBehaviour
{

    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public TextMeshProUGUI speedText;
    [SerializeField] private float moveCharacterTestVariable = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedText.text = "Speed: " + playerSpeed + "ms";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0)
        {
            moveCharacterTestVariable+=Time.deltaTime;
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }
        else
        {
            if (moveCharacterTestVariable >= Time.deltaTime)
                moveCharacterTestVariable -= Time.deltaTime;
            else
                moveCharacterTestVariable = 0;
            rb.velocity = Vector2.zero;
        }
    }
}