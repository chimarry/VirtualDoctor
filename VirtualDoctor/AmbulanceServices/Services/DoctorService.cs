using AmbulanceDatabase;
using AmbulanceDatabase.Context;
using AmbulanceDatabase.Entities;
using AmbulanceDatabase.Factories;
using AmbulanceDatabase.Procedures;
using AmbulanceDatabase.Views;
using AmbulanceServices.Interfaces;
using AmbulanceServices.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmbulanceServices.Services
{
    public class DoctorService : IDoctorService
    {
        public async Task<DbStatus> Add(Doctor doctor)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            Doctor currentDoctor = await GetByUniqueIdentifiers(new string[] { "Name", "LastName", "IdLocalAccount" }, doctor);

            if (currentDoctor != null && currentDoctor.Deleted == 0)
            {
                return DbStatus.EXISTS;
            }
            else if (currentDoctor != null && currentDoctor.Deleted == 1)
            {
                doctor.IdDoctor = currentDoctor.IdDoctor;
                commandsToExecute.Add(new InsertOrUpdateCommand<Doctor>().GetCommand(connection, doctor.GetAssociatedDbTableName(), doctor).CommandText);
                DeleteOrUpdateClinics(currentDoctor, doctor, commandsToExecute, connection);
                DeleteOrUpdateTitles(currentDoctor, doctor, commandsToExecute, connection);

            }
            else
            {
                commandsToExecute.Add(new InsertCommand<Doctor>().GetCommand(connection, doctor.GetAssociatedDbTableName(), doctor).CommandText);
                foreach (var clinic in doctor.GetClinics())
                {
                    commandsToExecute.Add(new InsertIntoConnectionTableCommand<DoctorClinic>("IdDoctor").GetCommand(connection, clinic.GetAssociatedDbTableName(), clinic).CommandText);

                }
                foreach (var title in doctor.GetMedicalTitles())
                {
                    commandsToExecute.Add(new InsertIntoConnectionTableCommand<DoctorMedicalTitle>("IdDoctor").GetCommand(connection, title.GetAssociatedDbTableName(), title).CommandText);
                }
            }
            DbTransactionProcedure transactionProcedure = new InsertDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;

        }

        public async Task<DbStatus> Delete(Doctor doctor)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            foreach (var clinic in doctor.GetClinics())
            {

                commandsToExecute.Add(new DeleteCommand<DoctorClinic>().GetCommand(connection, clinic.GetAssociatedDbTableName(), clinic).CommandText);
            }
            foreach (var title in doctor.GetMedicalTitles())
            {
                commandsToExecute.Add(new DeleteCommand<DoctorMedicalTitle>().GetCommand(connection, title.GetAssociatedDbTableName(), title).CommandText);
            }
            commandsToExecute.Add(new DeleteCommand<Doctor>().GetCommand(connection, doctor.GetAssociatedDbTableName(), doctor).CommandText);
            DbTransactionProcedure transactionProcedure = new DeleteDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;
        }
        public async Task<DbStatus> Update(Doctor doctor)
        {
            List<string> commandsToExecute = new List<string>();
            IConnector connector = ConnectorFactory.CreateConnector();
            MySqlConnection connection = connector.CreateConnection();
            await connector.OpenConnection(connection);
            Doctor currentDoctor = await GetByPrimaryKey(doctor);
            if (currentDoctor == null)
            {
                return DbStatus.NOT_FOUND;
            }
            DeleteOrUpdateClinics(currentDoctor, doctor, commandsToExecute, connection);
            DeleteOrUpdateTitles(currentDoctor, doctor, commandsToExecute, connection);
            commandsToExecute.Add(new UpdateCommand<Doctor>().GetCommand(connection, doctor.GetAssociatedDbTableName(), doctor).CommandText);
            DbTransactionProcedure transactionProcedure = new UpdateDbTransactionProcedure(commandsToExecute.ToArray());
            DbStatus status = await transactionProcedure.Execute();
            return status;
        }

        public async Task<IList<Doctor>> GetAll()
        {
            var doctors = await ServiceHelper<Doctor>.ExecuteSelectCommand(new SelectAllCommand<Doctor>());
            foreach (Doctor doc in doctors)
            {

                var doctorClinics = await ServiceHelper<DoctorClinic>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<DoctorClinic>(new string[] { "IdDoctor" }), new DoctorClinic()
                {
                    IdDoctor = doc.IdDoctor
                });
                var doctorTitles = await ServiceHelper<DoctorMedicalTitle>.ExecuteSelectCommand(
                    new SelectWithAttributeValuesCommand<DoctorMedicalTitle>(new string[] { "IdDoctor" }), new DoctorMedicalTitle()
                    {
                        IdDoctor = doc.IdDoctor
                    });
                doc.SetMedicalTitles(doctorTitles);
                doc.SetClinics(doctorClinics);
            }
            return doctors;
        }

        public async Task<Doctor> GetByPrimaryKey(Doctor doctor)
        {
            var doc = (await ServiceHelper<Doctor>.ExecuteSelectCommand(new SelectWithPrimaryKeyCommand<Doctor>(), doctor))?.SingleOrDefault();
            if (doc != null)
            {
                var doctorClinics = await ServiceHelper<DoctorClinic>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<DoctorClinic>(new string[] { "IdDoctor" }), new DoctorClinic()
                {
                    IdDoctor = doc.IdDoctor
                });
                var doctorTitles = await ServiceHelper<DoctorMedicalTitle>.ExecuteSelectCommand(
                    new SelectWithAttributeValuesCommand<DoctorMedicalTitle>(new string[] { "IdDoctor" }), new DoctorMedicalTitle()
                    {
                        IdDoctor = doc.IdDoctor
                    });
                doc.SetMedicalTitles(doctorTitles);
                doc.SetClinics(doctorClinics);
            }
            return doc;
        }

        public async Task<IList<Doctor>> GetRange(int begin, int count)
        {

            var doctors = await ServiceHelper<Doctor>.ExecuteSelectCommand(new SelectWithRangeCommand<Doctor>(begin, count, "Name"));
            foreach (Doctor doc in doctors)
            {

                var doctorClinics = await ServiceHelper<DoctorClinic>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<DoctorClinic>(new string[] { "IdDoctor" }), new DoctorClinic()
                {
                    IdDoctor = doc.IdDoctor
                });
                var doctorTitles = await ServiceHelper<DoctorMedicalTitle>.ExecuteSelectCommand(
                    new SelectWithAttributeValuesCommand<DoctorMedicalTitle>(new string[] { "IdDoctor" }), new DoctorMedicalTitle()
                    {
                        IdDoctor = doc.IdDoctor
                    });
                doc.SetMedicalTitles(doctorTitles);
                doc.SetClinics(doctorClinics);
            }
            return doctors;
        }

        public async Task<DbStatus> AddOrUpdate(Doctor doctor)
        {
            return await ServiceHelper<Doctor>.ExecuteCRUDCommand(new InsertOrUpdateCommand<Doctor>(), doctor);
        }

        public async Task<Doctor> GetByUniqueIdentifiers(string[] propertyNames, Doctor entity, bool? deleted = null)
        {
            var doc = (await ServiceHelper<Doctor>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<Doctor>
               (propertyNames, deleted), entity))?.SingleOrDefault();
            if (doc != null)
            {
                var doctorClinics = await ServiceHelper<DoctorClinic>.ExecuteSelectCommand(new SelectWithAttributeValuesCommand<DoctorClinic>(new string[] { "IdDoctor" }), new DoctorClinic()
                {
                    IdDoctor = doc.IdDoctor
                });
                var doctorTitles = await ServiceHelper<DoctorMedicalTitle>.ExecuteSelectCommand(
                    new SelectWithAttributeValuesCommand<DoctorMedicalTitle>(new string[] { "IdDoctor" }), new DoctorMedicalTitle()
                    {
                        IdDoctor = doc.IdDoctor
                    });
                doc.SetMedicalTitles(doctorTitles);
                doc.SetClinics(doctorClinics);
            }
            return doc;
        }
        public void DeleteOrUpdateClinics(Doctor currentDoctor, Doctor doctor, List<string> commandsToExecute, MySqlConnection connection)
        {
            var clinicsToDelete = currentDoctor.GetClinics().Except(doctor.GetClinics());
            var clinicsToAdd = doctor.GetClinics().Except(currentDoctor.GetClinics());
            foreach (var clinic in clinicsToDelete)
            {

                commandsToExecute.Add(new CompletelyDeleteCommand<DoctorClinic>().GetCommand(connection, clinic.GetAssociatedDbTableName(), clinic).CommandText);
            }
            foreach (var clinic in clinicsToAdd)
            {
                clinic.IdDoctor = currentDoctor.IdDoctor;
                commandsToExecute.Add(new InsertOrUpdateCommand<DoctorClinic>().GetCommand(connection, clinic.GetAssociatedDbTableName(), clinic).CommandText);

            }
        }
        public void DeleteOrUpdateTitles(Doctor currentDoctor, Doctor doctor, List<string> commandsToExecute, MySqlConnection connection)
        {
            var titlesToDelete = currentDoctor.GetMedicalTitles().Except(doctor.GetMedicalTitles());
            var titlesToAdd = doctor.GetMedicalTitles().Except(currentDoctor.GetMedicalTitles());
            foreach (var title in titlesToDelete)
            {
                commandsToExecute.Add(new CompletelyDeleteCommand<DoctorMedicalTitle>().GetCommand(connection, title.GetAssociatedDbTableName(), title).CommandText);
            }
            foreach (var title in titlesToAdd)
            {
                title.IdDoctor = currentDoctor.IdDoctor;
                commandsToExecute.Add(new InsertOrUpdateCommand<DoctorMedicalTitle>().GetCommand(connection, title.GetAssociatedDbTableName(), title).CommandText);

            }

        }

        public async Task<IList<DoctorsView>> GetAllViews()
        {
            return await ServiceHelper<DoctorsView>.ExecuteSelectCommand(new SelectAllCommand<DoctorsView>());
        }

        public async Task<string> GetTitlesName(int idDoctor, int idMedicalTitle)
        {
            InputDbParameter inParam1 = new InputDbParameter("IdDoctorParam", MySqlDbType.Int32, idDoctor);
            InputDbParameter inParam2 = new InputDbParameter("IdMedicalTitleParam", MySqlDbType.Int32, idMedicalTitle);

            DbStoredProcedure storedProcedure = new GetTitlesNameDbStoredProcedure(new InputDbParameter[] { inParam1, inParam2 });
            return (string)(await storedProcedure.ExecuteCommand());
        }

        public async Task<IList<DoctorsView>> GetRangeViews(int begin, int count)
        {
            return await ServiceHelper<DoctorsView>.ExecuteSelectCommand(new SelectWithRangeCommand<DoctorsView>(begin, count,"Name"));
        }

        public async Task<int> GetTotalNumberOfItems()
        {
            return Convert.ToInt32(await ServiceHelper<Doctor>.ExecuteScalarCommand(new CountCommand<Doctor>()));
        }
    }
}
