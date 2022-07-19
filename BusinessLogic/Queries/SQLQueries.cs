namespace BusinessLogic.Queries;

public static class SQLQueries
{
    public static string AddEmployee =
        "INSERT INTO Employee (Name, Age, Email, Status) VALUES (@Name, @Age, @Email, @Status)";

    public static string GetEmployeeList =
       "SELECT * FROM Employee";

    public static string GetEmployee =
       "SELECT * FROM Employee WHERE Id = @Id";

    public static string UpdateEmployee =
      "UPDATE Employee SET Name=@Name, Age=@Age, Email=@Email, Status=@Status WHERE Id=@Id";

    public static string ChangeStatus =
        "UPDATE Employee SET Status = @Status WHERE Id = @Id";
   
}
