namespace SchoolQueries;

public interface ISchoolDatabase
{
    Student[] Students { get; set; }
    Project[] Projects { get; set; }
    ProjectGrade[] ProjectGrades { get; set; }

    Student[] GetStudentsByName(string name);

    Student[] GetStudentsWithAverageGradeInProjectAbove(int grade);

    Project[] GetProjectsWithMinimumGradeInProjectBelow(int grade);

    Student[] GetStudentsDoneProject(string projectName);
}
