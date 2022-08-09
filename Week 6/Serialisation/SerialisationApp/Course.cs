using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp
{
    internal class Course
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        [field: NonSerialized]
        private readonly DateTime _lastRead;
        public Course()
        {
            _lastRead = DateTime.Now;
        }
        public void AddTrainee(Trainee trainee)
        {
            Trainees.Add(trainee);
        }
    }
}
