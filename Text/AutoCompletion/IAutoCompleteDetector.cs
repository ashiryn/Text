namespace FluffyVoid.Text.AutoCompletion;

/// <summary>
///     Defines a contract for all classes that have the capability of calculating string suggestions based on passed in
///     text
/// </summary>
public interface IAutoCompleteDetector
{
    /// <summary>
    ///     Adds a suggestion that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestion">The suggestions to add</param>
    void AddSuggestion(string suggestion);
    /// <summary>
    ///     Adds a collection of suggestions that can be used for AutoCompletion
    /// </summary>
    /// <param name="suggestions">Collection of suggestions to add</param>
    void AddSuggestions(params string[] suggestions);
    /// <summary>
    ///     Clears all suggestions from the detector
    /// </summary>
    void ClearSuggestions();
    /// <summary>
    ///     Finds the next available suggestion for use
    /// </summary>
    /// <returns>The next suggestion available in the list</returns>
    string GetSuggestion();
    /// <summary>
    ///     Whether the handler is capable of offering a suggestion or not
    /// </summary>
    /// <param name="text">The text to check if it is in a state to be offered any suggestions</param>
    /// <returns>True if the text is valid for offering stored suggestions for, otherwise false</returns>
    bool HasSuggestions(string text);
    /// <summary>
    ///     Removes a suggestion from being available
    /// </summary>
    /// <param name="suggestion">The suggestion to remove</param>
    void RemoveSuggestion(string suggestion);
}