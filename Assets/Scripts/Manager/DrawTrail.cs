using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrail : MonoBehaviour
{
    public List<Color> colorList; // 色のリスト
    public float trailWidth = 0.1f;
    public float lineLifetime = 10f; // Lineが消えるまでの時間

    private GameObject baseObject; // BaseObject
    private LineRenderer currentLine;
    private List<Vector2> points = new List<Vector2>();
    private int currentColorIndex = 0; // 現在の色のインデックス

    void Start()
    {
        // BaseObjectを取得するか、生成する
        baseObject = GameObject.Find("BaseObject");
        if (baseObject == null)
        {
            baseObject = new GameObject("BaseObject");
        }

        // 初期の色を設定
        SetLineColor(colorList[currentColorIndex]);
        // 10秒ごとに色を切り替える
        InvokeRepeating("ChangeLineColor", 0f, 10f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (currentLine == null)
            {
                CreateLine();
            }

            UpdateLine(mousePos);
        }
        else if (currentLine != null)
        {
            currentLine = null;
        }
    }

    void CreateLine()
    {
        GameObject lineObject = new GameObject("Line");
        lineObject.transform.parent = baseObject.transform; // BaseObjectの子オブジェクトにする
        currentLine = lineObject.AddComponent<LineRenderer>();
        currentLine.material = new Material(Shader.Find("Sprites/Default"));
        currentLine.startColor = colorList[currentColorIndex];
        currentLine.endColor = colorList[currentColorIndex];
        currentLine.startWidth = trailWidth;
        currentLine.endWidth = trailWidth;

        points.Clear();
        points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        currentLine.positionCount = 1;
        currentLine.SetPosition(0, points[0]);

        // 一定時間後にLineを破棄する
        Destroy(lineObject, lineLifetime);
    }

    void UpdateLine(Vector2 mousePos)
    {
        points.Add(mousePos);
        currentLine.positionCount = points.Count;
        currentLine.SetPosition(points.Count - 1, mousePos);
    }

    void SetLineColor(Color color)
    {
        if (currentLine != null)
        {
            currentLine.startColor = color;
            currentLine.endColor = color;
        }
    }

    void ChangeLineColor()
    {
        currentColorIndex = (currentColorIndex + 1) % colorList.Count;
        SetLineColor(colorList[currentColorIndex]);
    }
}
