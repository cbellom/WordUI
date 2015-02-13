using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {
	private static int indexSelectedWord;
	private Image imageWord;
	private GameObject scrollList;
	
	void Start () {
		indexSelectedWord = 0;
		imageWord = GameObject.Find("ImageWord").GetComponent<Image>();
		scrollList = GameObject.Find ("List");
		selectDefaultWord (indexSelectedWord);		
	}

	public void selectWord(){
		indexSelectedWord = int.Parse(gameObject.name.Substring(9));
		imageWord.sprite = transform.GetChild(1).GetComponent<Image>().sprite ;
	}
	
	public void approveWord(){
		imageWord.sprite = null;
		scrollList.transform.GetChild(indexSelectedWord).gameObject.SetActive(false);
		selectNextWordInList();
	}
	
	public void reproveWord(){
		selectNextWordInList();
	}
	
	public void selectNextWordInList(){
		GameObject item = scrollList.transform.GetChild (indexSelectedWord).gameObject;
		int length = scrollList.transform.childCount;
		
		for(int i = 1; i < length ; ++i) {
			indexSelectedWord = (indexSelectedWord + 1) % length;
			item = scrollList.transform.GetChild (indexSelectedWord).gameObject;
			if(item.activeSelf) {
				imageWord.sprite = item.transform.GetChild(1).GetComponent<Image>().sprite ;
				EventSystem.current.SetSelectedGameObject (item);
				return;
			}
		}
	}
	
	public void selectDefaultWord(int indexWord){
		if (scrollList.transform.childCount <= indexWord)
			return;
		
		GameObject item = scrollList.transform.GetChild (indexWord).gameObject;
		imageWord.sprite = item.transform.GetChild(1).GetComponent<Image>().sprite ;
		EventSystem.current.SetSelectedGameObject (item);
	}

}
