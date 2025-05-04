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
        cursorHotspot = new Vector2(cursorFrames[0].width / 2, cursorFrames[0].height / 2);
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
