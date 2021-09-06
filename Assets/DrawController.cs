using UnityEngine;

public class DrawController : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brushPrefab, pauseScreen;
    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Update()
    {
        if(!pauseScreen.activeSelf)
            Draw();
    }

    void Draw() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos) 
            {        
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else 
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush() 
    {
        GameObject brushInstance = Instantiate(brushPrefab);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos) 
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
