using Collage.Domain.Entities;
using FluentValidation;

namespace Collage.Application.Validations
{
    public class CollageValidations : AbstractValidator<Collages>
    {
        public CollageValidations()
        {

        }
    }
    public class FacultyValidations : AbstractValidator<Faculty>
    {
        public FacultyValidations()
        {

        }
    }
    public class CollageDepartmentValidations : AbstractValidator<CollageDepartment>
    {
        public CollageDepartmentValidations()
        {

        }
    }
    public class ProfessorValidations : AbstractValidator<Professor>
    {
        public ProfessorValidations()
        {

        }
    }
    public class SubjectValidations : AbstractValidator<Subject>
    {
        public SubjectValidations()
        {

        }
    }
    public class WorkerValidations : AbstractValidator<Worker>
    {
        public WorkerValidations()
        {

        }
    }
    public class EmployeeValidations : AbstractValidator<Employee>
    {
        public EmployeeValidations()
        {

        }
    }
    public class StudentValidations : AbstractValidator<Student>
    {
        public StudentValidations()
        {

        }
    }
}
