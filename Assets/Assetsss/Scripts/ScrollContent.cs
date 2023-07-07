﻿using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    #region Public Properties

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    public float ItemSpacing { get { return itemSpacing; } }

    /// <summary>
    /// How much the items are indented from left and right of the scroll view.
    /// </summary>
    public float HorizontalMargin { get { return horizontalMargin; } }

    /// <summary>
    /// How much the items are indented from top and bottom of the scroll view.
    /// </summary>
    public float VerticalMargin { get { return verticalMargin; } }

    /// <summary>
    /// Is the scroll view oriented horizontally?
    /// </summary>
    public bool Horizontal { get { return horizontal; } }

    /// <summary>
    /// Is the scroll view oriented vertically?
    /// </summary>
    public bool Vertical { get { return vertical; } }

    /// <summary>
    /// The width of the scroll content.
    /// </summary>
    public float Width { get { return width; } }

    /// <summary>
    /// The height of the scroll content.
    /// </summary>
    public float Height { get { return height; } }

    /// <summary>
    /// The width for each child of the scroll view.
    /// </summary>
    public float ChildWidth { get { return childWidth; } }

    /// <summary>
    /// The height for each child of the scroll view.
    /// </summary>
    public float ChildHeight { get { return childHeight; } }

    #endregion

    #region Private Members

    /// <summary>
    /// The RectTransform component of the scroll content.
    /// </summary>
    private RectTransform rectTransform;

    /// <summary>
    /// The RectTransform components of all the children of this GameObject.
    /// </summary>
    private RectTransform[] rtChildren;

    /// <summary>
    /// The width and height of the parent.
    /// </summary>
    private float width, height;

    /// <summary>
    /// The width and height of the children GameObjects.
    /// </summary>
    private float childWidth, childHeight;

    /// <summary>
    /// How far apart each item is in the scroll view.
    /// </summary>
    [SerializeField]
    private float itemSpacing;

    /// <summary>
    /// How much the items are indented from the top/bottom and left/right of the scroll view.
    /// </summary>
    [SerializeField]
    private float horizontalMargin, verticalMargin;

    /// <summary>
    /// Is the scroll view oriented horizontall or vertically?
    /// </summary>
    [SerializeField]
    private bool horizontal, vertical;

    #endregion

    private void Start()
    {
        this.ResizeContent();
    }

    public void ResizeContent()
    {
        rectTransform = GetComponent<RectTransform>();
        rtChildren = new RectTransform[rectTransform.childCount];

        if (rectTransform.childCount < 1) return;

        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rtChildren[i] = rectTransform.GetChild(i) as RectTransform;
        }

        // Subtract the margin from both sides.
        width = rectTransform.rect.width - (2 * horizontalMargin);
        // Subtract the margin from the top and bottom.
        height = rectTransform.rect.height - (2 * verticalMargin);

        childWidth = rtChildren[0].rect.width;

        childHeight = rtChildren[0].rect.height;

        InitializeContentHorizontal();
    }

    /// <summary>
    /// Initializes the scroll content if the scroll view is oriented horizontally.
    /// </summary>
    private void InitializeContentHorizontal()
    {
        float originX = 50;
        float posOffset = childWidth * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.x = originX + posOffset + i * (childWidth + itemSpacing);
            childPos.y = -100;
            rtChildren[i].localPosition = childPos;
        }
    }
}
