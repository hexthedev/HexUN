using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hex.UN.Runtime.Framework.CliCommands
{
    public class ObservableTMPInputFieldOnEndEditTrigger : ObservableTriggerBase
    {
        private TMP_InputField _input;
        
        Subject<string> OnEndEdit = new Subject<string>();

        private void OnEnable()
        {
            _input = GetComponent<TMP_InputField>();

            if (_input == null)
                Debug.LogError($"Failed to observe TMP_InputField, no TMP_InputField present on the GameObject");

            _input.onEndEdit.AddListener(s => OnEndEdit.OnNext(s));
        }

        public IObservable<string> OnEndEditAsObservable()
        {
            return OnEndEdit ??= new Subject<string>();
        }

        protected override void RaiseOnCompletedOnDestroy()
        {
            OnEndEdit.OnCompleted();
        }
    }

    public static class ObservableTMPInputFieldOnEndEditExtensions
    {
        public static IObservable<string> ObserveOnEndEdit(this TMP_InputField target)
        {
            ObservableTMPInputFieldOnEndEditTrigger trigger =
                target.gameObject.GetComponent<ObservableTMPInputFieldOnEndEditTrigger>();

            if (trigger == null)
                trigger = target.gameObject.AddComponent<ObservableTMPInputFieldOnEndEditTrigger>();

            return trigger.OnEndEditAsObservable();
        }
    }
    
    
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

            foreach (string s in _onStartCommands.Split("\n"))
                HandleCommand(s);
            
            _input
                .ObserveOnEndEdit()
                .Subscribe(HandleCommand);
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

            if (!EventSystem.current.alreadySelecting)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(_input.gameObject);
            }
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
}