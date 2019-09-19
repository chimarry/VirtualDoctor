using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulanceServices.Factories
{
    public interface IServicesAmbulanceFactory
    {
        IClinicService CreateIClinicService();
        ILocalAccountService CreateILocalAccountService();
        IRoleService CreateIRoleService();
        IDoctorService CreateIDoctorService();
        IMedicalRecordService CreateIMedicalRecordService();
        IPlaceService CreateIPlaceService();
        IPrescriptionService CreateIPrescriptionService();
        ITestResultsService CreateITestResultsService();
        IMedicalTitleService CreateIMedicalTitleService();
        IUserAuthenticationService CreateIUserAuthenticationService();
        ILocalAccountRoleService CreateILocalAccountRoleService();
    }
}
