using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

public abstract class ACommandHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField _input;
    private List<string> _history = new List<string>();
    private int _historyPointer;
    
    [SerializeField] TMP_Text _log;
    private Stack<string> _logs = new Stack<string>();

    [TextArea] public string _onStartCommands;

    private ACliCommand _rootCommand;
    public ACliCommand RootCommand
    {
        get => _rootCommand;
        set
        {
            _rootCommand = value;
            _history.Clear();
            _logs.Clear();
            _historyPointer = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(_input.gameObject); 
        _input.onEndEdit.AddListener(HandleCommand);

        foreach (string s in _onStartCommands.Split("\n"))
            HandleCommand(s);
    }

    public void HandleCommand(string command)
    {
        string[] parts = command.Split(' ');

        string log = _rootCommand.Parse(parts);
        
        if(log != string.Empty)
            LogAndPrint(log);
        
        if(_history.Count == 0 || _history[^1] != command)
            AddToHistory(command);
        
        _input.SetTextWithoutNotify("");
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_input.gameObject);
    }

    public void LogAndPrint(string newLog)
    {
        _logs.Push(newLog);
        _log.text = _logs.Take(20).Aggregate((s, ag) => $"{ag}\n{s}");
    }

    void AddToHistory(string command)
    {
        if(command != string.Empty)
            _history.Add(command);
        _historyPointer = _history.Count - 1;
    }
    
    string GetLast()
    {
        string last = _history[_historyPointer];
        
        if(_historyPointer != 0)
            _historyPointer--;

        return last;
    }

    string GetNext()
    {
        if (_historyPointer == _history.Count - 1)
            return "";
        
        if(_historyPointer != _history.Count-1)
            _historyPointer++;

        return _history[_historyPointer];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            _input.SetTextWithoutNotify(GetLast());
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            _input.SetTextWithoutNotify(GetNext());
    }
}