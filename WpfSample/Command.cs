using System;
using System.Windows.Input;

namespace WpfSample
{
    public abstract class BaseCommand : ICommand
    {
        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);
        public static void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    
    public abstract class BaseCommand<TParam> : ICommand
    {
        public abstract bool CanExecute(TParam parameter);
        public abstract void Execute(TParam parameter);
        public static void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
        bool ICommand.CanExecute(object? parameter) => parameter is TParam param && CanExecute(param);
        void ICommand.Execute(object? parameter)
        {
            if (parameter is TParam param)
            {
                Execute(param);
            }
        }
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    
    
    
    public class Command : BaseCommand
    {
        private readonly Action<object?> execute;
        private readonly Func<object?, bool>? canExecute;
        public Command(Action execute, Func<bool>? canExecute = null)
            : this(_ => execute(), canExecute is null ? null : _ => canExecute())
        {
        }
        public Command(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) => canExecute is null || canExecute(parameter);
        public override void Execute(object? parameter) => execute(parameter);
    }
    
    public class Command<TParam> : BaseCommand<TParam>
    {
        private readonly Action<TParam> execute;
        private readonly Func<TParam, bool>? canExecute;
        public Command(Action<TParam> execute, Func<TParam, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(TParam parameter) => canExecute is null || canExecute(parameter);
        public override void Execute(TParam parameter) => execute(parameter);
    }
    
}