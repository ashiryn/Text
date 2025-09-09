namespace FluffyVoid.Text.AutoCompletion;

/// <summary>
///     Data class for use in reading in auto complete suggestions from JSON file
/// </summary>
[Serializable]
public class DefaultAutoCompleteEntries
{
    /// <summary>
    ///     The collection of auto complete entries read in from file
    /// </summary>
    public DefaultAutoCompleteData[]? Entries { get; set; }
}