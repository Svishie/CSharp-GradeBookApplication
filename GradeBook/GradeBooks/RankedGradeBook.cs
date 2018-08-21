using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks {
    class RankedGradeBook : BaseGradeBook{
        public RankedGradeBook(string name) : base(name) {
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
    }
}
