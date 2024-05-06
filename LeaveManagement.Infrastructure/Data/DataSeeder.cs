using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using LeaveManagement.Core.Entities;
using LeaveManagement.Infrastructure.Persistence;

namespace LeaveManagement.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(LeaveManagementDbContext context)
        {
            try
            {
                // Check if data already exists
                if (context.Users.Any())
                {
                    return; // Database has been seeded
                }

                // Add sample users with roles
                var users = new User[]
                {
                new User { FullName = "Sajid MSH", Role = "CEO", Username = "sajid", Password = "password1", Email = "sajid@example.com", Age = 35, ManagerId = null },
                new User { FullName = "Ashar", Role = "Manager", Username = "ashar", Password = "password2", Email = "ashar@example.com", Age = 35,  ManagerId = null },
                new User { FullName = "Afx", Role = "Manager", Username = "ali", Password = "password3", Email = "ali@example.com", Age = 35, ManagerId = null  },
                new User { FullName = "Bob Brown", Role = "Employee", Username = "bob", Password = "password4", Email = "bob@example.com", Age = 35, ManagerId = null  },
                new User { FullName = "John Doe", Role = "Employee", Username = "john", Password = "password5", Email = "john@example.com", Age = 35, ManagerId = null  },
                new User { FullName = "Jane Smith", Role = "Employee", Username = "jane", Password = "password6", Email = "jane@example.com", Age = 35, ManagerId = null  },
                new User { FullName = "Alice Johnson", Role = "Employee", Username = "alice", Password = "password7", Email = "alice@example.com", Age = 35, ManagerId = null  },
                    // Add more users as needed
                };

                // Add users to context
                context.Users.AddRange(users);
                context.SaveChanges();

                // Assign managers and CEO to employees
                var managers = users.Where(u => u.Role == "Manager").ToList();
                var ceo = users.FirstOrDefault(u => u.Role == "CEO");

                int managerIndex = 0;
                foreach (var user in users)
                {
                    // Managers are assigned to employees in a round-robin fashion, and the CEO is assigned as the manager for all managers.
                    if (user.Role == "Employee")
                    {
                        user.ManagerId = managers[managerIndex % managers.Count].Id; // Making sure managers are equaly Assigned to Emplyees
                        managerIndex++;
                    }
                    else if (user.Role == "Manager")
                    {
                        user.ManagerId = ceo.Id; // Set the CEO as the approver for Managers

                    }
                }

                context.SaveChanges(); // Save changes after assigning managers
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SeedData: {ex.Message}");
                throw; // Rethrow the exception to propagate it
            }
        }
    }
}
