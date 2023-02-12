using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRod : MonoBehaviour
{
    public static Transform startPos, endPos;
    public static float fadeIncrement = 1;
    bool destroy = false;
    public Color blue;


    LineRenderer lr;

    float maxZ = 8;
    int noSegments = 50;
    float posRange = 0.15f;
    float radius = 1;
    Vector2 midPoint;

    Color color;
    Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        color = r.material.color;

        if (endPos != null) maxZ = endPos.position.z;

        lr = GetComponent<LineRenderer>();
        lr.positionCount = noSegments;
        midPoint = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));

        for (int i = 0; i < noSegments - 1; i++)
        {
            float z = i * maxZ / (noSegments - 1);
            float x = -midPoint.x * z * z / 16 + z * midPoint.x / 2;
            float y = -midPoint.y * z * z / 16 + z * midPoint.y / 2;


            lr.SetPosition(i, new Vector3(x + Random.Range(-posRange, posRange), y + Random.Range(-posRange, posRange), z));
        }

        lr.SetPosition(0, startPos == null ? Vector3.zero : startPos.position);
        lr.SetPosition(noSegments - 1, endPos == null ? new Vector3(transform.position.x, transform.position.y, transform.position.z + 8) : endPos.position);

    }


    void Update()
    {
        switch (animationIndex)
        {
            case 0: fadeToBlue(); break;
            case 1: fadeToNothing(); break;
        }

    }

    int animationIndex = 0;
    float timer = 0.5f;
    void fadeToBlue()
    {
        color = Color.Lerp(color, blue, fadeIncrement * 2);

        if (color == blue)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                animationIndex = 1;
            }
        }
        else
        {
            setColors(color);
        }
    }
    void fadeToNothing()
    {
        //print(color);
        color = Color.Lerp(color, Color.clear, fadeIncrement);

        if (color == Color.clear)
        {
            destroy = true;
        }

        setColors(color);

        if (destroy)
        {
            Destroy(gameObject);
        }
    }

    void setColors(Color color)
    {
        r.material.SetColor("_Color", color);
        lr.startColor = color;
        lr.endColor = color;
    }
}
