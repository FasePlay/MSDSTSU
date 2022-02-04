using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool GamePaused = false;
    [SerializeField] GameObject filter;
    [SerializeField] GameObject PauseText;
    [SerializeField] Text factsText;
    string[] funFacts = {"the total budget of the game is 12 cents", 
        "we are all going to die some day and there is no way to fool Death itself",
        "The \"Shrek\" movie is banned in Nepal",
        "Chocolate milkl comes from brown cows ",
        "who reads these anyways",
        "donating to Team Seas increases your chances at winning the game",
        "the pythagoreas theorem is a^2+b^2=c^2, which is just the cosine theorem in a rare case",
        "people who watch netflix with subtitles are superior",
        "on average, in their sleep people swallow around 8 spiders a year! That's 8 more than it should be",
        "[insert a rickroll here]",
        "PLACEHOLDER FUNFACT"};
    //pause flip
    public void GamePause()
    {
        GamePaused = !GamePaused;
        Debug.Log(GamePaused);
        if (GamePaused == false)
        {
            Time.timeScale = 0; 
            filter.GetComponent<RawImage>().enabled = true;
            //Facts(funFacts);
        }
        else 
        {
            Time.timeScale = 1; 
            filter.GetComponent<RawImage>().enabled = false;
        }
    }
    //returns a random fact

    string[] Facts (string[] funFacts)
    {
        factsText.text = funFacts[Random.Range(0, funFacts.Length)];
        return funFacts;
    }
    
}
