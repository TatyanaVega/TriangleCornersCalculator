using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TriangleCornersCalculator;

namespace TriangleCorners
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private string _triangleTypeResult;

		public MainWindowViewModel()
		{
			CalculateCommand = new RelayCommand(p => Calculate());
		}

		public ICommand CalculateCommand { get; set; }

		public double ALength { get; set; }
		public double BLength { get; set; }
		public double CLength { get; set; }

		public string TriangleTypeResult
		{
			get => _triangleTypeResult;
			set
			{
				_triangleTypeResult = value;
				OnPropertyChanged();
			}
		}

		private void Calculate()
		{
			switch (Calculator.CalculateCorners(ALength, BLength, CLength))
			{
				case TriangleType.Obtuse:
					TriangleTypeResult = "Тупой";
					break;
				case TriangleType.Sharp:
					TriangleTypeResult = "Острый";
					break;
				case TriangleType.Right:
					TriangleTypeResult = "Прямоугольный";
					break;
				case TriangleType.Undefined:
				default:
					TriangleTypeResult = "Введенные данные не корректны";
					break;
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}