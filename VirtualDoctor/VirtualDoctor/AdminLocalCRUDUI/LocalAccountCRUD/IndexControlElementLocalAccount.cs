using AmbulanceDatabase.Entities;
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

namespace VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD
{
    public class IndexControlElementLocalAccount : IndexControlElement
    {
        private readonly ILocalAccountRoleService localAccountRoleService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountRoleService();
        public override void Create(double height = 0, double width = 0)
        {
            Window modalCreate = new CreateModal();
            WindowHelper.SetModal(modalCreate, height, width);
            modalCreate.ShowDialog();
        }

        public async override void Delete(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            LocalAccountViewModel model = Mapping.Mapper.Map<LocalAccountViewModel>(item);
            model.SetRoles(await localAccountRoleService.GetAllRolesFor(model.IdLocalAccount) as List<Role>);
            Window deleteModal = new DeleteModal(model);
            WindowHelper.CenterWindow(deleteModal, height, width);
            deleteModal.ShowDialog();
        }

        public async override void Edit(object selectedItem, double height = 0, double width = 0)
        {
            DataRowView item = (DataRowView)selectedItem;
            LocalAccountViewModel model = Mapping.Mapper.Map<LocalAccountViewModel>(item);
            model.SetRoles(await localAccountRoleService.GetAllRolesFor(model.IdLocalAccount) as List<Role>);
            EditModal modal = new EditModal(model);
            WindowHelper.SetModal(modal, height, width);
            modal.ShowDialog();
        }
    }
}
