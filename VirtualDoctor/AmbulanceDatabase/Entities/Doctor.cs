using AmbulanceDatabase.Entities;
using System;
using System.Collections.Generic;

namespace AmbulanceDatabase
{
    public class Doctor : IDeleteable, IDbTableAssociate, IUniquelyIdentifiable
    {


        public int IdDoctor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }
        public sbyte Deleted { get; set; }
        public int IdLocalAccount { get; set; }
        public void SetDeletedEntity(bool idDeleted)
        {
            Deleted = Convert.ToSByte(idDeleted);
        }
        public string GetAssociatedDbTableName()
        {
            return "Doctor";
        }

        public string[] GetPrimaryKeyPropertyNames()
        {
            return new string[] { "IdDoctor" };
        }

        private List<DoctorClinic> clinics = new List<DoctorClinic>();
        public void SetClinics(List<DoctorClinic> clinics)
        {
            this.clinics = clinics;
        }
        private List<DoctorMedicalTitle> titles = new List<DoctorMedicalTitle>();
        public void SetMedicalTitles(List<DoctorMedicalTitle> titles)
        {
            this.titles = titles;
        }
        public List<DoctorClinic> GetClinics()
        {
            return clinics;
        }
        public List<DoctorMedicalTitle> GetMedicalTitles()
        {
            return titles;
        }
    }
}
