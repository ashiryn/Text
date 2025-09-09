namespace FluffyVoid.Text.AutoCompletion;

/// <summary>
///     Default auto complete handler that attempts to find suggestions based on the entered text compared to the stored
///     keyword
/// </summary>
public class DefaultAutoCompleteDetector : IAutoCompleteDetector
{
    /// <summary>
    ///     The keyword that this handler will use to determine if it can suggest anything with the passed in text
    /// </summary>
    private readonly string _keyword;
    /// <summary>
    ///     Collection used to ensure distinct suggestions to account for a user accidentally adding a suggestion twice
    /// </summary>
    private readonly HashSet<string> _registeredSuggestions;
    /// <summary>
    ///     List of suggestions available
    /// </summary>
    private readonly List<string> _suggestions;
    /// <summary>
    ///     The current index of the suggestion in use
    /// </summary>
    private int _index;

    /// <summary>
    ///     Constructor used to initialize the handler with information it will need to calculate suggestions
    /// </summary>
    /// <param name="keyword">The keyword to use when calculating suggestions</param>
    /// <param name="suggestions">The list of all available suggestions that this handler will have</param>
    public DefaultAutoCompleteDetector(string keyword,
                                       params string[] suggestions)
    {
        _keyword = keyword;
        _index = 0;
        _suggestions = new List<string>();
        _registeredSuggestions = new HashSet<string>();
        AddSuggestions(suggestions);
    }
    /// <summary>
    ///     Adds a suggestion that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestion">The suggestions to add</param>
    public void AddSuggestion(string suggestion)
    {
        if (_registeredSuggestions.Add(suggestion))
        {
            _suggestions.Add(suggestion);
        }
    }
    /// <summary>
    ///     Adds a collection of suggestions that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestions">Collection of suggestions to add</param>
    public void AddSuggestions(params string[] suggestions)
    {
        foreach (string suggestion in suggestions)
        {
            AddSuggestion(suggestion);
        }
    }
    /// <summary>
    ///     Clears all suggestions from the detector
    /// </summary>
    public void ClearSuggestions()
    {
        _suggestions.Clear();
        _index = 0;
    }
    /// <summary>
    ///     Finds the next available suggestion for use
    /// </summary>
    /// <returns>The next suggestion available in the list</returns>
    public string GetSuggestion()
    {
        if (_index >= _suggestions.Count)
        {
            _index = 0;
        }

        return _suggestions[_index++];
    }
    /// <summary>
    ///     Whether the handler is capable of offering a suggestion or not
    /// </summary>
    /// <param name="text">The text to check if it is in a state to be offered any suggestions</param>
    /// <returns>True if the text is valid for offering stored suggestions for, otherwise false</returns>
    public bool HasSuggestions(string text)
    {
        return text.StartsWith(_keyword);
    }
    /// <summary>
    ///     Removes a suggestion from being available
    /// </summary>
    /// <param name="suggestion">The suggestion to remove</param>
    public void RemoveSuggestion(string suggestion)
    {
        if (!_registeredSuggestions.Remove(suggestion))
        {
            return;
        }

        for (int index = _suggestions.Count - 1; index >= 0; --index)
        {
            if (_suggestions[index] != suggestion)
            {
                continue;
            }

            _suggestions.RemoveAt(index);
            return;
        }
    }
}