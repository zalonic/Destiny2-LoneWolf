using System;
using System.Diagnostics;
using System.Windows;
using Destiny2LoneWolf.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace Destiny2LoneWolf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            try
            {
                FirewallCommands.OpenMatchmakingPorts(); //Incase it was forced closed and ExecuteClosingCommand was not run
            }
            catch (Exception)
            {
                // ignored
            }

            ExecuteToggleCommand();
        }

        #region Variables
        private string _buttonImage;
        public string ButtonImage
        {
            get => _buttonImage;
            set => SetProperty(ref _buttonImage, value);
        }

        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private bool _soloMode;
        public bool SoloMode
        {
            get => _soloMode;
            set => SetProperty(ref _soloMode, value);
        }
        #endregion

        private DelegateCommand _toggleCommand;
        public DelegateCommand ToggleCommand =>
            _toggleCommand ?? (_toggleCommand = new DelegateCommand(ExecuteToggleCommand));
        private void ExecuteToggleCommand()
        {
            if (_soloMode) FirewallCommands.CloseMatchmakingPorts(); else FirewallCommands.OpenMatchmakingPorts();
            ButtonImage = _soloMode ? "/Images/lwEnabled.png" : "/Images/lwDisabled.png";
        }

        private DelegateCommand _closingCommand;
        public DelegateCommand ClosingCommand =>
            _closingCommand ?? (_closingCommand = new DelegateCommand(ExecuteClosingCommand));
        private void ExecuteClosingCommand() { if (_soloMode) FirewallCommands.OpenMatchmakingPorts(); }

        #region ContextMenu
        private DelegateCommand _openGitHubUrl;
        public DelegateCommand OpenGitHubUrl =>
            _openGitHubUrl ?? (_openGitHubUrl = new DelegateCommand(ExecuteOpenGitHubUrl));
        private static void ExecuteOpenGitHubUrl() => Process.Start("https://github.com/zalonic/Destiny2-LoneWolf/");

        private DelegateCommand _closeButtonCommand;
        public DelegateCommand CloseButtonCommand =>
            _closeButtonCommand ?? (_closeButtonCommand = new DelegateCommand(ExecuteCloseCommand));
        private static void ExecuteCloseCommand() => Application.Current.Shutdown();

        #endregion
    }
}
