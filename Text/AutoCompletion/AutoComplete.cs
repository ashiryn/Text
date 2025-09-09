namespace FluffyVoid.Text.AutoCompletion;

/// <summary>
///     Manager for finding suggestions to passed in text for the purpose of returning an auto-completed version of the
///     string
/// </summary>
public class AutoComplete
{
    /// <summary>
    ///     Text detector that define how suggestions are found
    /// </summary>
    public IAutoCompleteDetector AutoCompletionDetector { private get; set; }

    /// <summary>
    ///     Constructor for the manager that allows for initialization of the manager
    /// </summary>
    /// <param name="autoCompleteDetector">Text detector that define how suggestions are found</param>
    public AutoComplete(IAutoCompleteDetector autoCompleteDetector)
    {
        AutoCompletionDetector = autoCompleteDetector;
    }

    /// <summary>
    ///     Adds a suggestion that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestion">The suggestions to add</param>
    public void AddSuggestion(string suggestion)
    {
        AutoCompletionDetector.AddSuggestion(suggestion);
    }
    /// <summary>
    ///     Adds a collection of suggestions that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestions">Collection of suggestions to add</param>
    public void AddSuggestions(params string[] suggestions)
    {
        AutoCompletionDetector.AddSuggestions(suggestions);
    }
    /// <summary>
    ///     Clears all suggestions from the detector
    /// </summary>
    public void ClearSuggestions()
    {
        AutoCompletionDetector.ClearSuggestions();
    }
    /// <summary>
    ///     Finds a suggested string that was found based on the passed in text
    /// </summary>
    /// <param name="text">The text to find an auto complete suggestion for</param>
    /// <returns>The full text suggestion based on the passed in text</returns>
    public string GetSuggestion(string text)
    {
        return AutoCompletionDetector.HasSuggestions(text)
            ? AutoCompletionDetector.GetSuggestion()
            : text;
    }
    /// <summary>
    ///     Removes a suggestion from being available
    /// </summary>
    /// <param name="suggestion">The suggestion to remove</param>
    public void RemoveSuggestion(string suggestion)
    {
        AutoCompletionDetector.RemoveSuggestion(suggestion);
    }
}