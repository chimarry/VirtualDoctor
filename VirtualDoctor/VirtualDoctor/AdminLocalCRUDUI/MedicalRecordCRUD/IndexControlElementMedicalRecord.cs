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

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalRecordCRUD
{
    public class IndexControlElementMedicalRecord : IndexControlElement
    {
        public override void Create(double height = 0, double width = 0)
        {
            Window modalCreate = new CreateModal();
            WindowHelper.SetModal(modalCreate, height, width);
            modalCreate.ShowDialog();
        }

        public override void Delete(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            MedicalRecordViewModel model = Mapping.Mapper.Map<MedicalRecordViewModel>(item);

            Window deleteModal = new DeleteModal(model);
            WindowHelper.CenterWindow(deleteModal, height, width);
            deleteModal.ShowDialog();
        }

        public override void Edit(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            MedicalRecordViewModel model = Mapping.Mapper.Map<MedicalRecordViewModel>(item);

            Window editModal = new EditModal(model);
            WindowHelper.SetModal(editModal, height, width);
            editModal.ShowDialog(); ;
        }
    }
}
