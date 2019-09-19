using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Services;

namespace AmbulanceServices.Factories
{

    public class ServicesAmbulanceFactory : IServicesAmbulanceFactory
    {
        private static IServicesAmbulanceFactory instance = new ServicesAmbulanceFactory();
        private ServicesAmbulanceFactory() { }
        public static IServicesAmbulanceFactory GetInstance()
        {
            return instance;
        }
        public IClinicService CreateIClinicService()
        {
            return new ClinicService();
        }

        public IDoctorService CreateIDoctorService()
        {
            return new DoctorService();
        }

        public ILocalAccountRoleService CreateILocalAccountRoleService()
        {
            return new LocalAccountRoleService();
        }

        public ILocalAccountService CreateILocalAccountService()
        {
            return new LocalAccountService();
        }

        public IMedicalRecordService CreateIMedicalRecordService()
        {
            return new MedicalRecordService();
        }

        public IMedicalTitleService CreateIMedicalTitleService()
        {
            return new MedicalTitleService();
        }

        public IPlaceService CreateIPlaceService()
        {
            return new PlaceService();
        }

        public IPrescriptionService CreateIPrescriptionService()
        {
            return new PrescriptionService();
        }

        public IRoleService CreateIRoleService()
        {
            return new RoleService();
        }

        public ITestResultsService CreateITestResultsService()
        {
            return new TestResultsService();
        }

        public IUserAuthenticationService CreateIUserAuthenticationService()
        {
            return new UserAuthenticationService();
        }
    }
}
