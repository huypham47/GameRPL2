using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    private static InfiniteScroll instance;
    public static InfiniteScroll Instance => instance;
    #region Private Members

    /// <summary>
    /// The ScrollContent component that belongs to the scroll content GameObject.
    /// </summary>
    [SerializeField]
    private ScrollContent scrollContent;

    /// <summary>
    /// How far the items will travel outside of the scroll view before being repositioned.
    /// </summary>
    [SerializeField]
    private float outOfBoundsThreshold;

    /// <summary>
    /// The ScrollRect component for this GameObject.
    /// </summary>
    private ScrollRect scrollRect;

    /// <summary>
    /// The last position where the user has dragged.
    /// </summary>
    private Vector2 lastDragPosition;

    /// <summary>
    /// Is the user dragging in the positive axis or the negative axis?
    /// </summary>
    private bool positiveDrag = false;

    #endregion

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        //scrollRect.vertical = scrollContent.Vertical;
        //scrollRect.horizontal = scrollContent.Horizontal;
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        //this.AddOnValueChange();
        Invoke(nameof(HandleHorizontalScroll), 1f);
        if (InfiniteScroll.instance != null) return;
        InfiniteScroll.instance = this;
    }

    //protected virtual void AddOnValueChange()
    //{
    //    this.scrollRect.onValueChanged.AddListener(this.OnViewScroll);
    //}

    //public void OnViewScroll( Vector2 valua)
    //{
    //    HandleHorizontalScroll();
    //}

    
    public void HandleHorizontalScroll()
    {
        Debug.Log("HandleHorizontalScroll");
        int currItemIndex = 0;
        var currItem = scrollRect.content.GetChild(currItemIndex);
        if (!ReachedThreshold(currItem))
        {
            return;
        }

        int endItemIndex = scrollRect.content.childCount - 1;
        Transform endItem = scrollRect.content.GetChild(endItemIndex);
        Vector2 newPos = endItem.localPosition;
        newPos.x += scrollContent.ChildWidth + scrollContent.ItemSpacing;

        currItem.localPosition = newPos;
        currItem.SetSiblingIndex(endItemIndex);
    }

    /// <summary>
    /// Checks if an item has the reached the out of bounds threshold for the scroll view.
    /// </summary>
    /// <param name="item">The item to be checked.</param>
    /// <returns>True if the item has reached the threshold for either ends of the scroll view, false otherwise.</returns>
    private bool ReachedThreshold(Transform item)
    {
        float negXThreshold = transform.localPosition.x - scrollContent.Width * 0.5f - outOfBoundsThreshold;
        return item.localPosition.x + scrollContent.ChildWidth * 0.5f < negXThreshold;
    }
}
