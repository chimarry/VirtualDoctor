using AmbulanceDatabase;
using AmbulanceDatabase.Views;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    public class IndexControlElementDoctor : IndexControlElement
    {

        private readonly IDoctorService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIDoctorService();

        public override void Create(double height = 0, double width = 0)
        {
            Window modalCreate = new CreateModal();
            WindowHelper.SetModal(modalCreate, height, width);
            modalCreate.ShowDialog();
        }

        public async override void Delete(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            Doctor doctor = Mapping.Mapper.Map<Doctor>(item);

            doctor = await doctorService.GetByPrimaryKey(doctor);

            Window deleteModal = new DeleteModal(Mapping.Mapper.Map<DoctorViewModel>(doctor));
            WindowHelper.CenterWindow(deleteModal, height, width);
            deleteModal.ShowDialog();
        }

        public async override void Edit(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            Doctor doctor = Mapping.Mapper.Map<Doctor>(item);

            doctor = await doctorService.GetByPrimaryKey(doctor);

            Window editModal = new EditModal(Mapping.Mapper.Map<DoctorViewModel>(doctor));
            WindowHelper.SetModal(editModal, height, width);
            editModal.ShowDialog();
        }

        public async override void Details(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            Doctor doctor = Mapping.Mapper.Map<Doctor>(item);

            doctor = await doctorService.GetByPrimaryKey(doctor);

            Window detailsModall = new DetailsModal(Mapping.Mapper.Map<DoctorViewModel>(doctor));
            WindowHelper.SetModal(detailsModall, height, width);
            detailsModall.ShowDialog();
        }
    }
}
