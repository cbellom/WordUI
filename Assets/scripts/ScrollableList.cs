using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public GameObject itemPrefab;
	public LevelData levelData;
	public int columnCount = 1;
	private int itemCount; 

    void Start(){
		itemCount = levelData.words.Count;

        int j = 0;
		for (int i = 0; i < itemCount; i++){
			//this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
			if (i % columnCount == 0)
				j++;
			
			//create a new item, name it, and set the parent
			GameObject newItem = Instantiate(itemPrefab) as GameObject;
			newItem.name = "itemWord_" + i;
			newItem.transform.SetParent(gameObject.transform);
			
			newItem.transform.GetChild(0).GetComponent<Text>().text = levelData.words[i].wordText;
			newItem.transform.GetChild(1).GetComponent<Image>().sprite = levelData.words[i].wordImage;		

        }
		Destroy (itemPrefab);

    }

}
