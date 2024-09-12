using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float maxPositionX;
    [SerializeField] private float maxPositionY;

    private Vector3 currentDirection;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    currentDirection = touch.deltaPosition * 0.001f;
                    CheckBoundaries(currentDirection);
                    break;

                case TouchPhase.Stationary:
                    CheckBoundaries(currentDirection);
                    break;

                default:
                    currentDirection = Vector2.zero;
                    break;
            }
        }
    }

    private void CheckBoundaries(Vector3 currentDirection) 
    {
        if (Mathf.Abs(transform.position.x+currentDirection.x) > maxPositionX)
        {
            currentDirection.x = 0;
        }

        if (Mathf.Abs(transform.position.y + currentDirection.y) > maxPositionY)
        {
            currentDirection.y = 0;
        }
        transform.position += currentDirection;
    }

}