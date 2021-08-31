using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.ViewComponents.RoleEnum
{
    public class CustomClaimTypes
    {
        public static class SecurityGroups
        {
            public const string ApplicationOrTechnicalConsultants = "Application/Technical Consultants";
            public const string ProjectManager = "Project Managers";
            public const string Clients = "Clients";
            public const string SuperUser = "Super User";
            public const string DedicatedSupportStaff = "Isianpadu Helpdesk Staff (Dedicated support staff)";
            public const string ManagingDirectorOrDirectors = "Managing Director/Directors";
            public const string Clients2 = "Clients (2) *";
            public const string ProjectDirectors = "Project Directors";
            public const string CompanyStaff = "Company Staff";
        }
        public static class PolicyTypes
        {
            public static class ApplicationOrTechnicalConsultants
            {
                public const string Manage = "ApplicationOrTechnicalConsultants.manage.policy";
            }
            public static class ProjectManager
            {
                public const string Manage = "ProjectManager.manage.policy";
            }
            public static class Clients
            {
                public const string View = "Clients.manage.policy";
            }
            public static class SuperUser
            {
                public const string All = "SuperUser.manage.policy";
            }

            public static class ManagingDirectorOrDirectors
            {
                public const string Admin = "ManagingDirectorOrDirectors.manage.policy";
            }

            public static class DedicatedSupportStaff
            {
                public const string Admin = "DedicatedSupportStaff.manage.policy";
            }
            public static class Clients2
            {
                public const string Admin = "Clients2.manage.policy";
            }
            public static class ProjectDirectors
            {
                public const string admin = "ProjectDirectors.manage.policy";
            }
            public static class CompanyStaff
            {
                public const string admin = "CompanyStaff.manage.policy";
            }
        }
    }
}

