using Punisher.Domain;

namespace Punisher.TestData
{
	public class TestDataGenerator
	{
		private readonly IRepository<MeasureType> _measureTypesRepository;

		public TestDataGenerator(IRepository<MeasureType> measureTypesRepository)
		{
			_measureTypesRepository = measureTypesRepository;
		}

		public void Generate()
		{
			_measureTypesRepository.Add(new MeasureType("Выговор", MeasureKind.Penalty, 1));
			_measureTypesRepository.Add(new MeasureType("Строгий выговор", MeasureKind.Penalty, 5));
			_measureTypesRepository.Add(new MeasureType("Выговор с занесением", MeasureKind.Penalty, 7));
		}
	}
}