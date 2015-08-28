using System.Windows.Controls;

namespace Metro.Wpf.DataAct
{
    public interface IAppTools
    {
        FormAction Action { get; set; }

        ComboBox comboCmd { get; }

        Button cmdEdit { get; }
        Button cmdSave { get; }
        Button cmdUndo { get; }
        Button cmdRefresh { get; }

        Button cmdPaste { get; }
        //this.cmdIntoExcel  { get; }
        //this.filterPanel StackPanel)(target));

        //// this.filterNotEmpty CheckBox)(target));
        // this.filterText = ((Metro.Wpf.DataAct.DataTextBoxFS)(target));
    }

    public interface IAppToolsFilter : IAppTools
    {
        Button cmdIntoExcel { get; }

        StackPanel filterPanel { get; }
        DataTextBoxFS filterText { get; }

        //// this.filterNotEmpty CheckBox)(target));
    }
}