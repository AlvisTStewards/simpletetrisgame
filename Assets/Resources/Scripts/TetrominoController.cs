using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public float fallSpeed = 1f;
    private float fallTimer;

    void Update()
    {
        HandleInput();
        HandleFall();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Move(Vector3.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Move(Vector3.right);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Rotate();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Move(Vector3.down);
    }

    void HandleFall()
    {
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallSpeed)
        {
            Move(Vector3.down);
            fallTimer = 0;
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction;
        if (!IsValidPosition()) transform.position -= direction;
    }

    void Rotate()
    {
        transform.Rotate(0, 0, 90);
        if (!IsValidPosition()) transform.Rotate(0, 0, -90);
    }

    bool IsValidPosition()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = gridManagmentScript.Round(block.position);
            if (!gridManagmentScript.IsInsideGrid(pos) || gridManagmentScript.IsOccupied(pos)) return false;
        }
        return true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gridManagmentScript.AddToGrid(transform);
        enabled = false; // Disable script after landing
    }
}

