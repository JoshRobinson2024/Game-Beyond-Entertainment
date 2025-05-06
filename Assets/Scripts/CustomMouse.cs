using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CustomMouse : MonoBehaviour
{
    [SerializeField] private Texture2D clickedTexture;
    [SerializeField] private Texture2D normalTexture;

    private Vector2 cursorHotspot;
    public bool noMouse;
    public static bool aiming;

    public AnimatedCursor AnimatedCursor;
    // Start is called before the first frame update
    void Start()
    {
        if (noMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aiming)
        {
            AnimatedCursor.Animate();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(clickedTexture, cursorHotspot, CursorMode.Auto);
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(normalTexture, cursorHotspot, CursorMode.Auto);
            
        }
        
    }
    
}
