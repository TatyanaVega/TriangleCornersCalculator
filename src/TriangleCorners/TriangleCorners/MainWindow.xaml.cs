using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TriangleCorners
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{

			var textBox = sender as TextBox;
			var fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);

			e.Handled = !double.TryParse(fullText,
				NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
				CultureInfo.InvariantCulture,
				out _);
		}
	}
}
