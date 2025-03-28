using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Dropdown difficultyDropdown;

    void Start()
    {
        // difficulty options
        difficultyDropdown.options.Clear();
        difficultyDropdown.options.Add(new Dropdown.OptionData("Difficulty: Easy"));
        difficultyDropdown.options.Add(new Dropdown.OptionData("Difficulty: Medium"));
        difficultyDropdown.options.Add(new Dropdown.OptionData("Difficulty: Hard"));

        // default = easy
        difficultyDropdown.value = PlayerPrefs.GetInt("difficulty", 0);

        // save whenever the player changes selection
        difficultyDropdown.onValueChanged.AddListener(index =>
        {
            PlayerPrefs.SetInt("difficulty", index);
            PlayerPrefs.Save();
        });
    }
}
