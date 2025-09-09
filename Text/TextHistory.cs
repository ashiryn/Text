namespace FluffyVoid.Text;

/// <summary>
///     Manager that can track a list of items, and recall them as needed
/// </summary>
public class TextHistory
{
    /// <summary>
    ///     List of items to store as the history
    /// </summary>
    private readonly List<string> _history;
    /// <summary>
    ///     The maximum number of items to store
    /// </summary>
    private readonly int _maximumHistory;
    /// <summary>
    ///     The current history index
    /// </summary>
    private int _index;

    /// <summary>
    ///     Constructor used to initialize the manager
    /// </summary>
    /// <param name="maximumHistory">The maximum number of items to store in the history</param>
    public TextHistory(int maximumHistory)
    {
        _history = new List<string>();
        _maximumHistory = maximumHistory >= 0 ? maximumHistory : 0;
        _index = 0;
    }

    /// <summary>
    ///     Adds an item to be stored in history
    /// </summary>
    /// <param name="item">The item to be stored</param>
    public void AddHistory(string item)
    {
        _history.Add(item);
        if (_history.Count > _maximumHistory)
        {
            _history.RemoveAt(0);
        }

        _index = _history.Count;
    }
    /// <summary>
    ///     Gets the next entry in the history from where the history currently is
    /// </summary>
    /// <returns>The next entry if any exist, otherwise a default item</returns>
    public string GetNextEntry()
    {
        string result = string.Empty;
        ++_index;
        if (_index >= _history.Count)
        {
            _index = _history.Count;
        }

        if (_index < _history.Count)
        {
            result = _history[_index];
        }

        return result;
    }
    /// <summary>
    ///     Gets the previous entry in the history from where the history currently is
    /// </summary>
    /// <returns>The previous entry if any exist, capping at the first entry in the history</returns>
    public string GetPreviousEntry()
    {
        string result = string.Empty;
        --_index;
        if (_index < 0)
        {
            _index = 0;
        }

        if (_index < _history.Count)
        {
            result = _history[_index];
        }

        return result;
    }
}