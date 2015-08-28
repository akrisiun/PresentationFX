using System.Windows.Controls;

namespace Metro.Wpf.DataAct
{
    public enum FormAction
    {
        List = 0,
        New = 1,
        Edit = 2,
        Delete = 3
    }

    /// <summary>
    /// Interaction logic for AppTools.xaml
    /// </summary>
    public partial class ActionsBar : UserControl, IAppTools
    {
        public FormAction Action { get; set; }

        ComboBox IAppTools.comboCmd { get { return null; } }

        Button IAppTools.cmdEdit { get { return this.cmdEdit; } }
        Button IAppTools.cmdSave { get { return this.cmdSave; } }
        Button IAppTools.cmdUndo { get { return this.cmdUndo; } }
        Button IAppTools.cmdRefresh { get { return this.cmdRefresh; } }
        Button IAppTools.cmdPaste { get { return this.paste1; } }

        public ActionsBar()
        {
            this.Action = FormAction.List;

            InitializeComponent();
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wpf.MetroLib;component/wpf/dataact/actionsbar.xaml", System.UriKind.Relative);
            System.Windows.ApplicationX.LoadComponent(this, resourceLocater);
        }
    }
}
