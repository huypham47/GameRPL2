using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseCell : MonoBehaviour
{

    [System.Serializable]
    private class ItemImage
    {
        public List<Sprite> sprites;
    }

    [System.Serializable]
    private class ListOfSprites
    {
        public List<ItemImage> itemImages;
        public int[] chance;
        public Color[] color;
    }

    [SerializeField] private List<ListOfSprites> listOfSprites;

    public void SetUp()
    {
        int level = 0;
        //int level = MapLevel.Instance.LevelCurrent - 2;
        var index = Randomize(level);

        GetComponent<Image>().sprite = listOfSprites[level].itemImages[index].sprites[Random.Range(0, listOfSprites[level].itemImages[index].sprites.Count)];
        transform.parent.GetComponent<Image>().color = listOfSprites[level].color[index];
    }

    private int Randomize(int level)
    {
        Debug.Log("Level " + level);
        int ind = 0;
        int count = this.listOfSprites[level].chance.Length;
        Debug.Log("Count " + count);
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, 100);
            if (rand > this.listOfSprites[level].chance[i])
            {
                return i;
            }
            ind++;
        }
        return ind;
    }
}
