using AmbulanceDatabase;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Views;
using AutoMapper;
using System.Data;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region EntityToViewModel
            MapToViewModel();
            #endregion

            #region ViewModelToEntity
            MapToEntity();
            #endregion

        }
        private void MapToViewModel()
        {
            CreateMap<DataRowView, LocalAccountViewModel>().ForMember(dest => dest.Email, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.IdLocalAccount, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.FullName, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.PasswordHash, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
                ForMember(dest => dest.Roles, conf => conf.MapFrom(src => src.Row.ItemArray[4]));

            CreateMap<DataRowView, RoleViewModel>().ForMember(dest => dest.RoleName, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.IdRole, conf => conf.MapFrom(src => src.Row.ItemArray[0]));

            CreateMap<DataRowView, MedicalTitleViewModel>().ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
               ForMember(dest => dest.IdMedicalTitle, conf => conf.MapFrom(src => src.Row.ItemArray[0]));

            CreateMap<Role, RoleViewModel>();

            CreateMap<LocalAccount, LocalAccountViewModel>().ForMember(dest => dest.Roles, conf => conf.MapFrom(src => src.GetRoleNames())).
                AfterMap((src, dest) => dest.SetRoles(src.GetRoles()));

            CreateMap<MedicalTitle, MedicalTitleViewModel>();

            CreateMap<Place, PlaceViewModel>().AfterMap((src, dest) => dest.AverageQuality = dest.CalculateAverageQuality());

            CreateMap<DataRowView, PlaceViewModel>().ForMember(dest => dest.IdPlace, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.CountryName, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.PostalCode, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
                ForMember(dest => dest.DrinkingWaterQuality, conf => conf.MapFrom(src => src.Row.ItemArray[4])).
                ForMember(dest => dest.FoodQuality, conf => conf.MapFrom(src => src.Row.ItemArray[5])).
                ForMember(dest => dest.RecreationalWaterQuality, conf => conf.MapFrom(src => src.Row.ItemArray[6])).
                ForMember(dest => dest.AirQuality, conf => conf.MapFrom(src => src.Row.ItemArray[7])).
                ForMember(dest => dest.InlandWaterQuality, conf => conf.MapFrom(src => src.Row.ItemArray[8])).
                ForMember(dest => dest.TerrainQuality, conf => conf.MapFrom(src => src.Row.ItemArray[9])).
                ForMember(dest => dest.MedicalVasteInformation, conf => conf.MapFrom(src => src.Row.ItemArray[10])).
                ForMember(dest => dest.NoiseInformation, conf => conf.MapFrom(src => src.Row.ItemArray[11])).
                ForMember(dest => dest.Radiation, conf => conf.MapFrom(src => src.Row.ItemArray[12]));

            CreateMap<Clinic, ClinicViewModel>();

            CreateMap<DataRowView, ClinicViewModel>().ForMember(dest => dest.IdClinic, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.Place, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.IdPlace, conf => conf.MapFrom(src => src.Row.ItemArray[3]));

            CreateMap<DataRowView, DoctorsView>().ForMember(dest => dest.IdDoctor, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.LastName, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.WorkExperience, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
                ForMember(dest => dest.Deleted, conf => conf.MapFrom(src => src.Row.ItemArray[4])).
           ForMember(dest => dest.IdLocalAccount, conf => conf.MapFrom(src => src.Row.ItemArray[5])).
           ForMember(dest => dest.Email, conf => conf.MapFrom(src => src.Row.ItemArray[6]));

            CreateMap<DataRowView, MedicalRecordsView>().ForMember(dest => dest.IdMedicalRecord, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.LastName, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.Jmb, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
                ForMember(dest => dest.Gender, conf => conf.MapFrom(src => src.Row.ItemArray[4])).
                ForMember(dest => dest.BirthDate, conf => conf.MapFrom(src => src.Row.ItemArray[5])).
                ForMember(dest => dest.BirthPlace, conf => conf.MapFrom(src => src.Row.ItemArray[6])).
                ForMember(dest => dest.MarriageStatus, conf => conf.MapFrom(src => src.Row.ItemArray[7])).
                ForMember(dest => dest.MothersFullName, conf => conf.MapFrom(src => src.Row.ItemArray[8])).
                ForMember(dest => dest.FathersFullName, conf => conf.MapFrom(src => src.Row.ItemArray[9])).
                ForMember(dest => dest.MothersProfession, conf => conf.MapFrom(src => src.Row.ItemArray[10])).
                ForMember(dest => dest.FathersProfession, conf => conf.MapFrom(src => src.Row.ItemArray[11])).
                ForMember(dest => dest.InsuranceNumber, conf => conf.MapFrom(src => src.Row.ItemArray[12])).
                ForMember(dest => dest.IdResidence, conf => conf.MapFrom(src => src.Row.ItemArray[13])).
                ForMember(dest => dest.ResidenceName, conf => conf.MapFrom(src => src.Row.ItemArray[14])).
                ForMember(dest => dest.Deleted, src => src.NullSubstitute(0));

            CreateMap<DataRowView, MedicalRecordViewModel>().ForMember(dest => dest.IdMedicalRecord, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
             ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
             ForMember(dest => dest.LastName, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
             ForMember(dest => dest.Jmb, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
             ForMember(dest => dest.Gender, conf => conf.MapFrom(src => src.Row.ItemArray[4])).
             ForMember(dest => dest.BirthDate, conf => conf.MapFrom(src => src.Row.ItemArray[5])).
             ForMember(dest => dest.BirthPlace, conf => conf.MapFrom(src => src.Row.ItemArray[6])).
             ForMember(dest => dest.MarriageStatus, conf => conf.MapFrom(src => src.Row.ItemArray[7])).
             ForMember(dest => dest.MothersFullName, conf => conf.MapFrom(src => src.Row.ItemArray[8])).
             ForMember(dest => dest.FathersFullName, conf => conf.MapFrom(src => src.Row.ItemArray[9])).
             ForMember(dest => dest.MothersProfession, conf => conf.MapFrom(src => src.Row.ItemArray[10])).
             ForMember(dest => dest.FathersProfession, conf => conf.MapFrom(src => src.Row.ItemArray[11])).
             ForMember(dest => dest.InsuranceNumber, conf => conf.MapFrom(src => src.Row.ItemArray[12])).
             ForMember(dest => dest.IdResidence, conf => conf.MapFrom(src => src.Row.ItemArray[13])).
             ForMember(dest => dest.ResidenceName, conf => conf.MapFrom(src => src.Row.ItemArray[14]));

            CreateMap<Doctor, DoctorViewModel>().AfterMap((src, dest) => dest.SetClinics(src.GetClinics())).AfterMap((src, dest) => dest.SetMedicalTitles(src.GetMedicalTitles()));
            CreateMap<DoctorMedicalTitle, DoctorMedicalTitleViewModel>();
            CreateMap<DoctorClinic, DoctorClinicViewModel>();
            CreateMap<DoctorsView, DoctorViewModel>();

            CreateMap<MedicalRecord, MedicalRecordViewModel>();

            CreateMap<MedicalRecordsView, MedicalRecordViewModel>();
        }
        private void MapToEntity()
        {
            CreateMap<DataRowView, Doctor>().ForMember(dest => dest.IdDoctor, conf => conf.MapFrom(src => src.Row.ItemArray[0])).
                ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.Row.ItemArray[1])).
                ForMember(dest => dest.LastName, conf => conf.MapFrom(src => src.Row.ItemArray[2])).
                ForMember(dest => dest.WorkExperience, conf => conf.MapFrom(src => src.Row.ItemArray[3])).
                ForMember(dest => dest.Deleted, conf => conf.MapFrom(src => src.Row.ItemArray[4]));

            CreateMap<RoleViewModel, Role>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<DoctorViewModel, DoctorsView>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<ClinicViewModel, Clinic>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<DoctorClinicViewModel, DoctorClinic>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<PlaceViewModel, Place>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<DoctorViewModel, Doctor>().ForMember(x => x.Deleted, y => y.NullSubstitute(0)).
                AfterMap((src, dest) => dest.SetClinics(src.GetClinics())).AfterMap((src, dest) => dest.SetMedicalTitles(src.GetMedicalTitles()));

            CreateMap<DoctorMedicalTitleViewModel, DoctorMedicalTitle>();

            CreateMap<MedicalTitleViewModel, MedicalTitle>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));

            CreateMap<LocalAccountViewModel, LocalAccount>().ForMember(x => x.Deleted, y => y.NullSubstitute(0)).
                AfterMap((src, dest) => dest.SetRoles(src.GetRoles()));

            CreateMap<MedicalRecordViewModel, MedicalRecord>().ForMember(x => x.Deleted, y => y.NullSubstitute(0));
        }
    }
}
