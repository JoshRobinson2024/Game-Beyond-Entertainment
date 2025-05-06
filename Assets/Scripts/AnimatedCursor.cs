using UnityEngine;

public class AnimatedCursor : MonoBehaviour
{
    public Texture2D[] cursorFrames; // Assign your cursor frames in the Inspector
    public float frameRate = 0.1f;  // Time between frames
    private Vector2 cursorHotspot;
    private int currentFrame;
    private float timer;

    void Start()
    {
        
        
    }

    public void Animate()
    {
        cursorHotspot = new Vector2(16, 16);
        timer += Time.deltaTime;
        if (timer >= frameRate)
        {
            timer -= frameRate;

            // Update the cursor frame
            currentFrame = (currentFrame + 1) % cursorFrames.Length;
            Cursor.SetCursor(cursorFrames[currentFrame], cursorHotspot, CursorMode.ForceSoftware);
        }
    }
}
