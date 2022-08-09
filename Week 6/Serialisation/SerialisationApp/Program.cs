namespace SerialisationApp
{
    public class Program
    {
        //private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\");
        private static ISerialise? _serialiser;
        static void Main(string[] args)
        {
            Trainee trainee = new Trainee
            {
                FirstName = "Maks",
                LastName = "Hadys",
                SpartaNumber = 1
            };

            var serialiser = new SerialiseBinary();
            serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);

            Trainee deserialisedMaks = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");

            _serialiser = new SerialiserFactory();

            _serialiser = new SerialiseJSON();
            serialiser.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);
            var dsjTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");

        }

        public static ISerialise SerialiserFactory()
        {
            return new SerialiseXML();
        }

    }
}