using ErrorOr;

namespace Collage.Domain.Entities.ApplicationUser.Errors;
public static partial class DomainErrors
{
    public static class UserErrors
    {
        public static string EmailAlreadyExists => "Email already exists, please login";
        public static string EmailDoesNotExist => "User with this email does not exist";
        public static string UserNameAlreadyExists => "Username already exists, please login";
    }
    public static class CollageUsers
    {

        public static Error InvalidCollageUser => Error.Failure("CollageUser.InvalidCollageUser", "Invalid CollageUser, couldn't complete your request");
        public static Error NotFound => Error.NotFound("CollageUser.NotFound", "CollageUser not found, create CollageUser");
        public static Error CannotJoinCollageUser => Error.Failure("CollageUser.CannotJoin", "Can't join CollageUser, please check your input");

        public static Error AlreadyExest => Error.Failure("CollageUser.AlreadyExest", "CollageUser aleaready exists");

        public static Error CannotDeleteCollageUser => Error.Failure("CollageUser.CannaotLeaveCollageUser", "this CollageUser cant be Deleted");


    }
    public static class Tasks
    {

        public static Error InvalidTask => Error.Failure("Task.InvalidTask", "Invalid Task, couldn't complete your request");
        public static Error NotFound => Error.NotFound("Task.NotFound", "Task not found, create Task");
        public static Error CannotJoinTask => Error.Failure("Task.CannotJoin", "Can't join Task, please check your input");

        public static Error AlreadyExest => Error.Failure("Task.AlreadyExest", "Task aleaready exists");

        public static Error CannotDeleteTask => Error.Failure("Task.CannaotLeaveTask", "this Task cant be Deleted");


    }


    public static class Departments
    {

        public static Error InvalidDepartment => Error.Failure("Department.InvalidDepartment", "Invalid Department, couldn't complete your request");
        public static Error NotFound => Error.NotFound("Department.NotFound", "Department not found, create Department");
        public static Error CannotJoinDepartment => Error.Failure("Department.CannotJoin", "Can't join Department, please check your input");

        public static Error AlreadyExest => Error.Failure("Department.AlreadyExest", "Department aleaready exists");

        public static Error CannotDeleteDepartment => Error.Failure("Department.CannaotLeaveDepartment", "this Department cant be Deleted");


    }
}