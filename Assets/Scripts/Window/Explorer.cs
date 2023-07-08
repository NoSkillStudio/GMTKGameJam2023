using UnityEngine;

public class Explorer : MonoBehaviour
{
    [SerializeField] private string[] words;

    public void StartSearch()
    {
        string word = Choice(words);
        print(word);
    }

    private string Choice(string[] strings)
    {
        try
        {
            int idx = Random.Range(0, strings.Length);
            return strings[idx];
        }
        catch
        {
            return null;
        }
    }
}
