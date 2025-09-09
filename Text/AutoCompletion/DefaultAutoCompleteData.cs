namespace FluffyVoid.Text.AutoCompletion;

/// <summary>
///     Data class for use in storing information needed to evaluate an auto completed string
/// </summary>
[Serializable]
public class DefaultAutoCompleteData
{
    /// <summary>
    ///     The keyword that will be used to calculate if there are any suggestions available for a text
    /// </summary>
    public required string Keyword { get; set; }
    /// <summary>
    ///     List of suggestions available for this keyword
    /// </summary>
    public required string[] Suggestions { get; set; }
}