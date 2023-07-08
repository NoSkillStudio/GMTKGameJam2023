using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Explorer : MonoBehaviour
{
    [SerializeField] private string[] searchWords;
    [Space(20)]
    [SerializeField] private string[] filenames;
    [SerializeField] private Sprite[] icons;
    [SerializeField] private GameObject filePrefab;

    public void StartSearch()
    {
        StartCoroutine(Search());
    }

    private IEnumerator Search()
    {
        GameObject files = GameObject.FindWithTag("Files");
        TMP_Text search = GameObject.FindWithTag("Search").GetComponent<TMP_Text>();

        int idx = ChoiceIdx(searchWords);
        string word = searchWords[idx];

        // type word
        yield return new WaitForSeconds(1f);
        search.color = Color.white;
        search.text = "";

        while (search.text != word)
        {
            search.text = word.Substring(0, search.text.Length + 1);
            yield return new WaitForSeconds(0.2f);
        }

        // start search
        while (files.transform.childCount > 0) {
            DestroyImmediate(files.transform.GetChild(0).gameObject);
        }

        for (int i = 0; i < filenames.Length; i++)
        {
            string filename = filenames[i];
            if (filename.Contains(word))
            {
                GameObject file = Instantiate(filePrefab, files.transform);
                file.GetComponent<Image>().sprite = icons[idx];
                file.GetComponentInChildren<TMP_Text>().text = filename;
            }
        }
    }

    private int ChoiceIdx(string[] strings)
    {
        return Random.Range(0, strings.Length);
    }
}
