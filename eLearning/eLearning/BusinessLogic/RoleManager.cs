using eLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLearning.BusinessLogic
{
    public class RoleManager
    {
        /// <summary>
        /// The available user roles
        /// </summary>
        public enum eRole
        {
            Unknown = 0,
            Teacher = 1,
            Student = 2
            
        }

        /// <summary>
        /// The user to manage permissions for
        /// </summary>
        public UserItem User { get; }

        /// <summary>
        /// The name of the user's role
        /// </summary>
        public eRole RoleName { get; }

        /// <summary>
        /// Constructor for the role manager. Create this everytime a user changes.
        /// </summary>
        /// <param name="user">The user to get the permissions for</param>
        public RoleManager(UserItem user)
        {
            User = user;

            if (user != null)
            {
                RoleName = (eRole)user.RoleId;
            }
            else
            {
                RoleName = eRole.Unknown;
            }
        }

        /// <summary>
        /// Specifies if the user has teacher permissions
        /// </summary>
        public bool IsTeacher
        {
            get
            {
                return RoleName == eRole.Teacher;
            }
        }

        /// <summary>
        /// Specifies if the user has student permissions
        /// </summary>
        public bool IsStudent
        {
            get
            {
                return RoleName == eRole.Student;
            }
        }

        
        /// <summary>
        /// Specifies if the user has unknown permissions
        /// </summary>
        public bool IsUnknown
        {
            get
            {
                return RoleName == eRole.Unknown;
            }
        }
    }
}
