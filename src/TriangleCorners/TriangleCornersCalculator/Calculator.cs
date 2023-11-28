namespace TriangleCornersCalculator
{
	public enum TriangleType
	{ 
		Undefined,
		Sharp,
		Obtuse,
		Right
	}

	public static class Calculator
	{
		public static TriangleType CalculateCorners(double a, double b, double c)
		{
			if (!(a + b > c && b + c > a && a + c > b))
				return TriangleType.Undefined;

			var aSq = a * a;
			var bSq = b * b;
			var cSq = c * c;
			var bcSq = bSq + cSq;
			var acSq = aSq + cSq;
			var abSq = aSq + bSq;

			double tolerance = 1e-10;
			if (Math.Abs(aSq - bcSq) < tolerance || Math.Abs(bSq - acSq) < tolerance || Math.Abs(cSq - abSq) < tolerance)
				return TriangleType.Right;

			if (aSq > bcSq || bSq > acSq || cSq > abSq)
				return TriangleType.Obtuse;

			return TriangleType.Sharp;
		}
	}
}