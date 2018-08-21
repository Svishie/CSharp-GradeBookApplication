using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks {
    public class RankedGradeBook : BaseGradeBook{
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted) {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var grades = 
                from student in Students
                where student.AverageGrade > averageGrade
                select student.AverageGrade;

            double percentage = 1.0 - ((double)grades.Count() / (double)Students.Count);

            if (percentage > 0.8)
                return 'A';
            else if (percentage > 0.6)
                return 'B';
            else if (percentage > 0.4)
                return 'C';
            else if (percentage > 0.2)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics() {
            if(Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name) {
            if(Students.Count < 5) {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
