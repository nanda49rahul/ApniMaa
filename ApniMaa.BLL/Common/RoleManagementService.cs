using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApniMaa.BLL.Helpers;
using ApniMaa.BLL.Models;

namespace ApniMaa.BLL.Common
{
    //public static class RoleManagementService
    //{

    //    public static readonly string Dashboard = "Dashboard";

    //    public static readonly string ManageFleets = "Manage Fleets";

    //    public static readonly string Profile = "Profile";

    //    public static readonly string Reports = "Reports";
    //    public static readonly string DriverReport = "Driver Report";
    //    public static readonly string PremiumBorderau = "Premium Borderau";
    //    public static readonly string ChangeReport = "Change Report";
    //    public static readonly string RenewalReport = "Renewal Report";
    //    public static readonly string SectionReport = "SectionReport";
    //    public static readonly string LesseChange = "Lesse Change";
    //    public static readonly string VehicleChnage = "Vehicle Chnage";
    //    public static readonly string CancellationReport = "Cancellation Report";
    //    public static readonly string PremiumIDCReport = "Premium IDC Report";
    //    public static readonly string InsuredIDCReport = "Insured IDC Report";
    //    public static readonly string ControlIDCReport = "Control IDC Report";


    //    public static readonly string FleetReports = "FleetReports";
    //    public static readonly string FleetDriverReport = "FleetDriver Report";
    //    public static readonly string FleetPremiumBorderau = "FleetPremium Borderau";
    //    public static readonly string FleetChangeReport = "FleetChange Report";
    //    public static readonly string FleetRenewalReport = "FleetRenewal Report";
    //    public static readonly string FleetSectionReport = "FleetSectionReport";
    //    public static readonly string FleetLesseChange = "FleetLesse Change";
    //    public static readonly string FleetVehicleChnage = "FleetVehicle Chnage";
    //    public static readonly string FleetCancellationReport = "FleetCancellation Report";


    //    public static readonly string ApniMaaAdmin = "ApniMaa Admin";
    //    public static readonly string ManageCountries = "Manage Countries";
    //    public static readonly string ManageProvinces = "Manage Provinces";
    //    public static readonly string ManageCities = "Manage Cities";
    //    public static readonly string EmailTemplate = "Email Template";
    //    public static readonly string ManageNews = "Manage News";
    //    public static readonly string KnowledgeBase = "Knowledge Base";
    //    public static readonly string QuickLinks = "QuickLinks";

    //    public static readonly string ManageInsurace = "Manage Insurace";
    //    public static readonly string MyCalendar = "My Calendar";
    //    public static readonly string ManageCertificates = "Manage Certificates";
    //    public static readonly string ManageDrivers = "Manage Drivers";


    //    public static readonly string FleetHomeController = "Home";
    //    public static readonly string FleetHomeIndex = "Index";
    //    public static readonly string FleetHomeFirmLogin = "FirmLogin";
    //    public static readonly string FleetHomeDashboard = "Dashboard";

    //    public static readonly string HomeController = "Home";
    //    public static readonly string HomeDashboard = "Dashboard";

    //    public static readonly string FleetsController = "Fleets";
    //    public static readonly string FleetsDashboard = "FleetDetails";
    //    public static readonly string FleetsEditFleet = "EditFleet";

    //    public static readonly string PolicyController = "Policy";
    //    public static readonly string PolicyManagePolicies = "ManagePolicies";
    //    public static readonly string PolicyAddPolicy = "AddPolicy";

    //    public static readonly string VehicleController = "Vehicle";
    //    public static readonly string VehicleManageVehicles = "ManageVehicles";
    //    public static readonly string VehicleAddVehicleDetails = "AddVehicleDetails";
    //    public static readonly string EditVehicleDetails = "EditVehicleDetails";

    //    public static readonly string ComissionController = "Comission";
    //    public static readonly string ComissionManageCommisions = "ManageCommisions";
    //    public static readonly string ComissionAddComissionDetails = "AddComissionDetails";
    //    public static readonly string ComissionManageSectionCodes = "ManageSectionCodes";
    //    public static readonly string ComissionAddSectionCodesDetails = "AddSectionCodesDetails";

    //    public static readonly string DriverController = "Driver";
    //    public static readonly string DriverManageDrivers = "ManageDrivers";
    //    public static readonly string DriverAdd = "Add";
    //    public static readonly string DriverEdit = "Edit";

    //    public static readonly string AuditTrailController = "AuditTrail";
    //    public static readonly string AuditTrailFirmAudit = "FirmAudit";


    //    public static readonly string EmployeeController = "Employee";
    //    public static readonly string EmployeeIndex = "Index";
    //    public static readonly string EmployeeAdd = "Add";
    //    public static readonly string EmployeeEdit = "Edit";

    //    public static readonly string ReportController = "report";
    //    public static readonly string ReportPremiumBordereau = "premiumbordereau";
    //    public static readonly string ReportLesseChange = "LesseChange";
    //    public static readonly string ReportDriverReport = "DriverReport";
    //    public static readonly string ReportRenewalReport = "RenewalReport";
    //    public static readonly string ReportSectionReport = "SectionReport";

    //    public static bool LoginAsAdmin = false;

    //    public static bool DefineRolePermission(string accessMethodName)
    //    {
    //        if (string.IsNullOrEmpty(accessMethodName))
    //            return false;

    //        accessMethodName = accessMethodName.ToLower().Trim();

    //        int roleType = Extensions.GetCurrentUser(LoginAsAdmin).UserType;

    //        var haveRole = Enum.IsDefined(typeof(UserRoleTypes), roleType);

    //        if (haveRole == false)
    //            return false;

    //        if ((int)UserRoleTypes.Broker == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //               Dashboard,    ManageFleets,      Profile,    Reports,
    //                DriverReport,   PremiumBorderau,    ChangeReport, RenewalReport,SectionReport,  LesseChange,   VehicleChnage,   CancellationReport , ApniMaaAdmin , ManageCountries , ManageProvinces , ManageCities , EmailTemplate , ManageNews , KnowledgeBase , QuickLinks , PremiumIDCReport , InsuredIDCReport , ControlIDCReport
    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }

    //        if ((int)UserRoleTypes.Underwriter == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //                 Dashboard,    ManageFleets,      Profile,    Reports,
    //                DriverReport,   PremiumBorderau,    ChangeReport, RenewalReport,SectionReport,  LesseChange,   VehicleChnage,   CancellationReport
    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }

    //        if ((int)UserRoleTypes.LiscAdmin == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //                Dashboard,     ManageFleets,      Profile,    Reports,
    //                DriverReport,   PremiumBorderau,    ChangeReport,RenewalReport, SectionReport,  LesseChange,   VehicleChnage,   CancellationReport,
    //                 ApniMaaAdmin , ManageCountries , ManageProvinces , ManageCities , EmailTemplate , ManageNews , KnowledgeBase , QuickLinks, ApniMaaAdmin , ManageCountries , ManageProvinces , ManageCities , EmailTemplate , ManageNews , KnowledgeBase , QuickLinks  
    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }

    //        if ((int)UserRoleTypes.ClaimManagement == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //                Dashboard,     ManageFleets,      Profile,    Reports,
    //                DriverReport,   PremiumBorderau,    ChangeReport,RenewalReport, SectionReport,  LesseChange,   VehicleChnage,   CancellationReport
    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }

    //        if ((int)UserRoleTypes.FleetAdmin == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //                ManageInsurace ,MyCalendar , HomeController , HomeDashboard , FleetsController , FleetsDashboard , FleetsEditFleet , PolicyController , PolicyManagePolicies,  PolicyAddPolicy ,
    //                VehicleController , VehicleManageVehicles , VehicleAddVehicleDetails , EditVehicleDetails,
    //                ComissionController , ComissionManageCommisions , ComissionAddComissionDetails , ComissionManageSectionCodes , ComissionAddSectionCodesDetails ,
    //                DriverController , DriverManageDrivers , DriverAdd , DriverEdit ,
    //                AuditTrailController , AuditTrailFirmAudit ,
    //                EmployeeController , EmployeeIndex , EmployeeAdd , EmployeeEdit ,
    //                FleetReports , FleetDriverReport , FleetPremiumBorderau , FleetChangeReport , FleetLesseChange , FleetVehicleChnage , FleetCancellationReport , FleetRenewalReport, FleetSectionReport,
    //                ReportController, ReportPremiumBordereau ,ReportLesseChange, ReportDriverReport , ReportSectionReport , ReportRenewalReport
                    
    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }

    //        if ((int)UserRoleTypes.Employee == roleType)
    //        {
    //            string[] BrokerRole = new string[] 
    //            {
    //               ManageCertificates ,ManageDrivers ,Dashboard , FleetHomeController , FleetHomeIndex , FleetHomeFirmLogin , FleetHomeDashboard ,FleetsController , FleetsDashboard,
    //                HomeController , HomeDashboard  ,
    //                VehicleController , VehicleManageVehicles , VehicleAddVehicleDetails , EditVehicleDetails,
    //                DriverController , DriverManageDrivers , DriverAdd , DriverEdit ,
                    

    //            };

    //            var isAccessible = BrokerRole.Contains(accessMethodName, StringComparer.OrdinalIgnoreCase);
    //            return isAccessible;
    //        }


    //        return false;
    //    }

    //    public static bool IsAuthorised(string controllerName, string actionName, bool loginAsAdmin)
    //    {
    //        LoginAsAdmin = loginAsAdmin;

    //        int roleType = Extensions.GetCurrentUser(LoginAsAdmin).UserType;

    //        var haveRole = Enum.IsDefined(typeof(UserRoleTypes), roleType);

    //        if (haveRole == false)
    //            return false;

    //        if (LoginAsAdmin && ((int)UserRoleTypes.FleetAdmin != roleType && (int)UserRoleTypes.Employee != roleType))
    //        {
    //            if ((int)UserRoleTypes.Employee == roleType)
    //                return false;
    //            else
    //                return true;
    //        }
    //        else
    //        {
    //            if (DefineRolePermission(controllerName))
    //            {
    //                if (DefineRolePermission(actionName))
    //                {
    //                    return true;
    //                }
    //            }
    //        }

    //        return false;
    //    }

    //    public static bool LogInAsAdmin()
    //    {
    //        int roleType = Extensions.GetCurrentUser(LoginAsAdmin).UserType;

    //        var haveRole = Enum.IsDefined(typeof(UserRoleTypes), roleType);

    //        if (haveRole == false)
    //            return false;

    //        if (LoginAsAdmin && ((int)UserRoleTypes.FleetAdmin != roleType && (int)UserRoleTypes.Employee != roleType))
    //        {
    //            if ((int)UserRoleTypes.Employee == roleType)
    //                return false;
    //            else
    //                return true;
    //        }
            

    //        return false;
    //    }
    //}
}
