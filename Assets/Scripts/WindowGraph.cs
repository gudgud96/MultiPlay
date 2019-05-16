using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateY;
    private List<GameObject> dots = new List<GameObject>();
    private List<GameObject> lines = new List<GameObject>();
    private List<GameObject> labelsY = new List<GameObject>();
    private List<GameObject> dashesY = new List<GameObject>();

    List<int> valueListEz = new List<int>() { 55, 88, 96, 95, 100, 123, 124, 85, 64, 102, 120, 145, 140, 150, 130 };
    List<int> valueListMed = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
    List<int> valueListHard = new List<int>() { 5, 22, 15, 40, 30, 22, 25, 30, 50, 40, 45, 10, 20, 15, 50 };

    void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        
        ShowGraph(valueListMed);
    }

    public void scoreSelectionEasy()
    {
        clearGraph();
        ShowGraph(valueListEz);
    }

    public void scoreSelectionMed()
    {
        clearGraph();
        ShowGraph(valueListMed);
    }

    public void scoreSelectionHard()
    {
        clearGraph();
        ShowGraph(valueListHard);
    }

    void clearGraph()
    {
        foreach (GameObject d in dots)
        {
            Object.Destroy(d);
        }
        dots = new List<GameObject>();
        foreach (GameObject l in lines)
        {
            Object.Destroy(l);
        }
        lines = new List<GameObject>();
        foreach (GameObject lab in labelsY)
        {
            Object.Destroy(lab);
        }
        labelsY = new List<GameObject>();
        foreach (GameObject dash in dashesY)
        {
            Object.Destroy(dash);
        }
        dashesY = new List<GameObject>();

    }


    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("Circle", typeof(Image));
        dots.Add(gameObject);
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<int> valueList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float graphWidth = graphContainer.sizeDelta.x;
        float yMaximum = 0f;
        float startShift = 50f;
        
        foreach(int score in valueList)
        {
            if (score > yMaximum)
                yMaximum = score*1.1f;
        }

        GameObject lastCircleGameObject = null;
        for (int i=0; i<valueList.Count; i++)
        {   
            float xPosition = startShift + (i * (graphWidth/(valueList.Count+1)));
            float yPosition = (valueList[i] / yMaximum) * (graphHeight);
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

        }

        int seperatorCount = 10;
        for (int i = 0; i<seperatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            dashesY.Add(labelY.gameObject);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = (i+1) * 1f / seperatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();

            RectTransform dashY = Instantiate(dashTemplateY);
            dashesY.Add(dashY.gameObject);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(2f, normalizedValue * graphHeight);
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        lines.Add(gameObject);
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f); 
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir*distance*.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, getAngleFromVectorFloat(dir));
    }

    private float getAngleFromVectorFloat(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
