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

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalTitleCRUD
{
    public class IndexControlElementMedicalTitle : IndexControlElement
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
            MedicalTitleViewModel title = Mapping.Mapper.Map<MedicalTitleViewModel>(item);

            Window deleteModal = new DeleteModal(title);
            WindowHelper.CenterWindow(deleteModal, height, width);
            deleteModal.ShowDialog();
        }


        public override void Edit(object selectedItem, double height = 0, double width = 0)
        {
            var item = (DataRowView)selectedItem;
            MedicalTitleViewModel title = Mapping.Mapper.Map<MedicalTitleViewModel>(item);

            EditModal modal = new EditModal(title);
            WindowHelper.SetModal(modal, height, width);
            modal.ShowDialog();
        }
    }
}
