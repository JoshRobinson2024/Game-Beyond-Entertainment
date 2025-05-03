using UnityEngine;

public class AnimatedCursor : MonoBehaviour
{
    public Texture2D[] cursorFrames; // Assign your cursor frames in the Inspector
    public float frameRate = 0.1f;  // Time between frames

    private int currentFrame;
    private float timer;

    void Start()
    {
        
        
    }

    public void Animate()
    { 
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;

            // Update the cursor frame
            currentFrame = (currentFrame + 1) % cursorFrames.Length;
            Cursor.SetCursor(cursorFrames[currentFrame], Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
