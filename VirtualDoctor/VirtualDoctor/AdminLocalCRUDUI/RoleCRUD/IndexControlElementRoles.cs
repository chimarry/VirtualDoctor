using System.Data;
using System.Windows;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Controls.IndexControl;
using VirtualDoctor.Shared.Helpers;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    public class IndexControlElementRoles : IndexControlElement
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
            RoleViewModel role = Mapping.Mapper.Map<RoleViewModel>(item);

            Window deleteModal = new DeleteModal(role);
            WindowHelper.CenterWindow(deleteModal, height, width);
            deleteModal.ShowDialog();
        }


        public override void Edit(object selectedItem, double height = 0, double width = 0)
        {
            var item = (DataRowView)selectedItem;
            RoleViewModel role = Mapping.Mapper.Map<RoleViewModel>(item);
            EditModal modal = new EditModal(role);
            WindowHelper.SetModal(modal, height, width);
            modal.ShowDialog();
        }
    }
}
