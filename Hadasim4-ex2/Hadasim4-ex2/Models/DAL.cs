using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hadasim4_ex2.Models
{
    public class DAL
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employees", connection);
            DataTable dt = new DataTable();
            List<Employee> lstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    DataRow row = dt.Rows[i];

                    employee.Id = Convert.ToString(row["Id"]);
                    employee.FirstName = Convert.ToString(row["FirstName"]);
                    employee.LastName = Convert.ToString(row["LastName"]);
                    employee.Address = Convert.ToString(row["Address"]);
                    employee.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    employee.Telephone = Convert.ToString(row["Telephone"]);
                    employee.MobilePhone = Convert.ToString(row["MobilePhone"]);
                    employee.PositiveResultDate = row["PositiveResultDate"] == DBNull.Value ? null : Convert.ToDateTime(dt.Rows[i]["PositiveResultDate"]);
                    employee.RecoveryDate = row["RecoveryDate"] == DBNull.Value ? null : Convert.ToDateTime(dt.Rows[i]["RecoveryDate"]);
                    employee.PhotoPath = Convert.ToString(row["PhotoPath"]);

                    lstEmployees.Add(employee);
                }

            }
            if (lstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.ItsEmployees = lstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.ItsEmployees = null;
            }
            return response;
        }

        public Response GetEmployeeById(SqlConnection connection, string id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employees WHERE ID= " + id, connection);
            DataTable dt = new DataTable();
            Employee Employee = new Employee();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                Employee employee = new Employee();
                DataRow row = dt.Rows[0];

                employee.Id = Convert.ToString(row["Id"]);
                employee.FirstName = Convert.ToString(row["FirstName"]);
                employee.LastName = Convert.ToString(row["LastName"]);
                employee.Address = Convert.ToString(row["Address"]);
                employee.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                employee.Telephone = Convert.ToString(row["Telephone"]);
                employee.MobilePhone = Convert.ToString(row["MobilePhone"]);
                employee.PositiveResultDate = row["PositiveResultDate"] == DBNull.Value ? null : Convert.ToDateTime(row["PositiveResultDate"]);
                employee.RecoveryDate = row["RecoveryDate"] == DBNull.Value ? null : Convert.ToDateTime(row["RecoveryDate"]);
                employee.PhotoPath = Convert.ToString(row["PhotoPath"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Employee = employee;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Employee = null;
            }
            return response;
        }

        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            bool existEmployee = ExistEmployee(connection, employee.Id);
            if (!existEmployee)
            {
                if (employee.PhotoPath == "")
                {
                    employee.PhotoPath = "https://p.kindpng.com/picc/s/24-248253_user-profile-default-image-png-clipart-png-download.png";
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO employees(ID, FirstName, LastName, Address, DateOfBirth, Telephone, MobilePhone, PositiveResultDate, RecoveryDate,PhotoPath) VALUES(@Id, @FirstName, @LastName, @Address, @DateOfBirth, @Telephone, @MobilePhone, @PositiveResultDate, @RecoveryDate, @PhotoPath)", connection);
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                cmd.Parameters.AddWithValue("@Telephone", employee.Telephone);
                cmd.Parameters.AddWithValue("@MobilePhone", employee.MobilePhone);
                cmd.Parameters.AddWithValue("@PositiveResultDate", (object)employee.PositiveResultDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RecoveryDate", (object)employee.RecoveryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PhotoPath", employee.PhotoPath);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Employee added.";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data inserted";
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "this employee id already exist";
            }
            return response;
        }

        public bool IsValidID(string id)
        {
            if (id.Length != 9)
                return false;

            if (!int.TryParse(id, out int _))
                return false;
            return true;
        }

        public List<string> ValidEmployee(Employee employee)
        {
            List<string> errors = new List<string>();

            // Check if employee is not null
            if (employee == null)
            {
                errors.Add("Employee object is null");
                return errors;
            }

            // Check if the ID is a valid non-negative value
            if (employee.Id.Length != 9 || !employee.Id.All(char.IsDigit))
                errors.Add("ID must be a non-empty string of 9 digits");

            // Check if first name is not null or empty
            if (string.IsNullOrEmpty(employee.FirstName) || employee.FirstName.Length > 20)
                errors.Add("First name cannot be null or empty or more than 20 characters");

            // Check if last name is not null or empty
            if (string.IsNullOrEmpty(employee.LastName) || employee.FirstName.Length > 20)
                errors.Add("Last name cannot be null or empty or more than 20 characters");

            // Check if address is not null or empty
            if (string.IsNullOrEmpty(employee.Address))
                errors.Add("Address cannot be null or empty");

            // Check if date of birth is valid (not default DateTime value)
            if (employee.DateOfBirth == default(DateTime) || employee.DateOfBirth > DateTime.Today)
                errors.Add("Date of birth must be provided and must be in the past");

            // Check if telephone is not null or empty
            if (!string.IsNullOrEmpty(employee.Telephone))
            {
                employee.Telephone = Regex.Replace(employee.Telephone, @"-", "");
                employee.Telephone = $"{employee.Telephone.Substring(0, 3)}{employee.Telephone.Substring(3)}";

                if (!Regex.IsMatch(employee.Telephone, @"^\d{10}$"))
                {
                    errors.Add("Phone must be a string of 10 digits.");
                }
            }

            // Check if mobile phone is not null or empty
            if (!string.IsNullOrEmpty(employee.MobilePhone))
            {
                // Remove hyphen from MobilePhone
                employee.MobilePhone = Regex.Replace(employee.MobilePhone, @"-", "");

                if (!Regex.IsMatch(employee.MobilePhone, @"^\d{9}$"))
                {
                    errors.Add("MobilePhone, if provided, must be a string of 9 digits.");
                }
            }

            return errors;
        }

        public Response GetAllCoronaDetails(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CoronaDetails", connection);
            DataTable dt = new DataTable();
            List<CoronaDetails> lstCoronaDetails = new List<CoronaDetails>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CoronaDetails cd = new CoronaDetails();
                    DataRow row = dt.Rows[i];

                    cd.Id = Convert.ToInt32(row["Id"]);
                    cd.EmployeeId = Convert.ToString(row["EmployeeId"]);
                    cd.VaccineDate = row["VaccineDate"] == DBNull.Value ? null : Convert.ToDateTime(row["VaccineDate"]);
                    cd.VaccineManufacturers = Convert.ToString(row["VaccineManufacturer"]);

                    lstCoronaDetails.Add(cd);
                }

            }
            if (lstCoronaDetails.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.itsCoronaDetails = lstCoronaDetails;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.itsCoronaDetails = null;
            }
            return response;
        }

        public Response GetCoronaDetailsById(SqlConnection connection, string id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CoronaDetails WHERE EmployeeID= " + id, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                CoronaDetails cd = new CoronaDetails();
                DataRow row = dt.Rows[0];

                cd.Id = Convert.ToInt32(row["Id"]);
                cd.EmployeeId = Convert.ToString(row["EmployeeId"]);
                cd.VaccineDate = row["VaccineDate"] == DBNull.Value ? null : Convert.ToDateTime(row["VaccineDate"]);
                cd.VaccineManufacturers = Convert.ToString(row["VaccineManufacturer"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.corona = cd;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.corona = null;
            }
            return response;
        }

        public bool ExistEmployee(SqlConnection connection, string id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees WHERE Id='" + id + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        public int CountCoronaDetails(SqlConnection connection, string id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CoronaDetails WHERE EmployeeId='" + id + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count;
        }

        public Response AddCoronaDetails(SqlConnection connection, CoronaDetails cd)
        {
            Response response = new Response();

            bool flag = ExistEmployee(connection, cd.EmployeeId);
            int count = CountCoronaDetails(connection, cd.EmployeeId);

            if (flag && count < 4)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CoronaDetails(ID, EmployeeId, VaccineDate, VaccineManufacturer) VALUES(@Id, @EmployeeId, @VaccineDate, @VaccineManufacturers)", connection);
                cmd.Parameters.AddWithValue("@Id", cd.Id);
                cmd.Parameters.AddWithValue("@EmployeeId", cd.EmployeeId);
                cmd.Parameters.AddWithValue("@VaccineDate", (object)cd.VaccineDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VaccineManufacturers", cd.VaccineManufacturers);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "CoronaDetails added.";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data inserted";
                }
            }
            else
            {
                if (!flag)
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data inserted becuase the employee id doesn't exist";
                    response.corona = null;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data inserted becuase the employee already have 4 vaccines";
                    response.corona = null;
                }
            }
            return response;
        }

        public List<string> ValidCoronaDetails(CoronaDetails cd)
        {
            List<string> errors = new List<string>();

            // Check if corona detail is not null
            if (cd == null)
            {
                errors.Add("CoronaDetail object is null");
                return errors;
            }

            // Check if the ID is a valid non-negative value
            if (cd.Id > 0)
                errors.Add("ID can't be negetive");

            // Check if the Employee ID is a valid non-negative value and exist
            if (cd.EmployeeId.Length != 9 || !cd.EmployeeId.All(char.IsDigit))
                errors.Add("Employee ID must be a non-empty string of 9 digits");


            // Check if VaccineManufacturers is not null or empty
            if (string.IsNullOrEmpty(cd.VaccineManufacturers))
                errors.Add("VaccineManufacturers cannot be null or empty");

            // Check if date of vaccine is valid (not default DateTime value)
            if (cd.VaccineDate == default(DateTime) || cd.VaccineDate >= DateTime.Today)
                errors.Add("Date of vaccine must be provided and must be in the past or today");


            return errors;
        }

        public Response GetCoronaDataForLastMonth(SqlConnection connection)
        {
            Response response = new Response();
            List<CoronaSummary> lst = new List<CoronaSummary>();

            string query = @"SELECT CONVERT(date, PositiveResultDate) AS Date,COUNT(*) AS ActivePatientsCount FROM Employees WHERE PositiveResultDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0) -- Start of last month AND PositiveResultDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) -- Start of current month
                             GROUP BY CONVERT(date, PositiveResultDate)
                            ORDER BY CONVERT(date, PositiveResultDate);";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        CoronaSummary summary = new CoronaSummary
                        {
                            Date = Convert.ToDateTime(reader["Date"]),
                            ActivePatients = Convert.ToInt32(reader["ActivePatientsCount"])
                        };
                        if (summary != null)
                            lst.Add(summary);
                    }
                    reader.Close();
                }
            }

            response.itsCoronaSummary = lst;
            return response;
        }

        public Response GetNotVaccinated(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Id, FirstName, LastName, Address, DateOfBirth, Telephone, MobilePhone, PositiveResultDate, RecoveryDate FROM Employees WHERE Id NOT IN(SELECT DISTINCT EmployeeId FROM CoronaDetails);", connection);
            DataTable dt = new DataTable();
            List<Employee> lstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    DataRow row = dt.Rows[i];

                    employee.Id = Convert.ToString(row["Id"]);
                    employee.FirstName = Convert.ToString(row["FirstName"]);
                    employee.LastName = Convert.ToString(row["LastName"]);
                    employee.Address = Convert.ToString(row["Address"]);
                    employee.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    employee.Telephone = Convert.ToString(row["Telephone"]);
                    employee.MobilePhone = Convert.ToString(row["MobilePhone"]);
                    employee.PositiveResultDate = row["PositiveResultDate"] == DBNull.Value ? null : Convert.ToDateTime(dt.Rows[i]["PositiveResultDate"]);
                    employee.RecoveryDate = row["RecoveryDate"] == DBNull.Value ? null : Convert.ToDateTime(dt.Rows[i]["RecoveryDate"]);

                    lstEmployees.Add(employee);
                }

            }
            if (lstEmployees.Count >= 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.ItsEmployees = lstEmployees;
                response.NotVaccinated = lstEmployees.Count;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.ItsEmployees = null;
            }
            return response;
        }
    }
}