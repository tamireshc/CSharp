namespace SchoolQueries;

public class SchoolDatabase : ISchoolDatabase
{
    public Student[] Students { get; set; }
    public Project[] Projects { get; set; }
    public ProjectGrade[] ProjectGrades { get; set; }

    public Student[] GetStudentsByName(string name)
    {
        var studentByName = from student in Students
                            where student.Name == name
                            select student;
        return studentByName.ToArray();
    }

    public Student[] GetStudentsWithAverageGradeInProjectAbove(int gradeInput)
    {
        var studentForAverage = from item in ProjectGrades
                                where item.Grades.Average() > gradeInput

                                from student in Students
                                where student.Id == item.StudentId
                                select student;
        return studentForAverage.ToArray();
    }

    public Project[] GetProjectsWithMinimumGradeInProjectBelow(int gradeInput)
    {
        var projectWithMinimumGrade = from item in ProjectGrades
                                      where item.Grades.Min() < gradeInput

                                      from project in Projects
                                      where project.Id == item.ProjectId
                                      select project;
        return projectWithMinimumGrade.ToArray();
    }

    public Student[] GetStudentsDoneProject(string projectName)
    {
        var studentDoneProject = from item in ProjectGrades
                                 join student in Students on item.StudentId equals student.Id
                                 join project in Projects on item.ProjectId equals project.Id
                                 where project.Name == projectName
                                 select student;
        return studentDoneProject.ToArray();
    }
}
