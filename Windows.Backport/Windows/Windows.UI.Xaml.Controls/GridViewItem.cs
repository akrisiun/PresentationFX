using System;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls.Primitives;
namespace Windows.UI.Xaml.Controls
{
	[Composable(typeof(IGridViewItemFactory), CompositionType.Public, 100794368u), MarshalingBehavior(MarshalingType.Agile), Threading(ThreadingModel.Both), Version(100794368u), WebHostHidden]
	public class GridViewItem : SelectorItem, IGridViewItem
	{
		public extern GridViewItemTemplateSettings TemplateSettings
		{
			get;
		}
		public extern GridViewItem();
	}
}