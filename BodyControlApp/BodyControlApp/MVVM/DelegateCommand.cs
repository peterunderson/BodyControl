using System;
using System.Diagnostics;
using System.Windows.Input;


namespace BodyControlApp.MVVM
{

    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Die auszuführende Operation
        /// </summary>
        readonly Action<object> _executeAction;
        /// <summary>
        /// Prüfung ob die Operation ausgeführt werden kann wenn.
        /// Wenn das Ergebnis false ist werden entsprechende Steuerelemente gesperrt
        /// (Enable = false);
        /// </summary>
        readonly Predicate<object> _canExecutePredicate;

        /// <summary>
        /// Initialisiert eine neue Instanz von DelegateCommand
        /// intern wird der zweite Konstruktor aufgerufen
        /// </summary>
        /// <param name="execute">Delegate der auszuführenden Methode(Methodenaufbau: Kein Rückgabewert, Objekt als Übergabeparameter</param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {

        }
        /// <summary>
        /// Initialisiert eine neue Instanz von DelegateCommand 
        /// </summary>
        /// <param name="execute">Delegate der auszuführenden Methode</param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("No Executecommand");
            }
            _executeAction = execute;
            _canExecutePredicate = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Führt die übergebende Methode zur CanExecute aus.
        /// Wurde nichts oder Null übergeben wird true zurückgegeben
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecutePredicate != null)
            {
                return _canExecutePredicate(parameter);
            }
            return true;
        }


        /// <summary>
        /// Wird ausgeführt wenn das Command in dem UI ausgeführt wird.
        /// Löst im Constructor übergebende Methode aus
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
