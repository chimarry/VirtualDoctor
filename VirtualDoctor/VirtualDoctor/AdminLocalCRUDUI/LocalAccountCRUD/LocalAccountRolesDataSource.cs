using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.DataSources;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.LocalAccountCRUD
{
    public class LocalAccountRolesDataSource : ComboBoxDataSource<RoleViewModel>, INotifyPropertyChanged
    {
        private readonly IRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateIRoleService();
        private readonly ILocalAccountRoleService localAccountRoleService = ServicesAmbulanceFactory.GetInstance().CreateILocalAccountRoleService();

        public LocalAccountRolesDataSource(int? idLocalAccount = null) : base(idLocalAccount)
        {
        }
        protected async override void InitializeItems()
        {

            if (idCurrentModel != null)
            {
                SelectedItems = new ObservableCollection<RoleViewModel>(
                    (await localAccountRoleService.GetAllRolesFor(idCurrentModel.Value))
                     .Select(x => Mapping.Mapper.Map<RoleViewModel>(x))
                    );
            }
            IList<Role> avaliableRoles = await roleService.GetAll();
            var roleslist = avaliableRoles.Select(x => Mapping.Mapper.Map<RoleViewModel>(x))?.Except(SelectedItems)?.Union(SelectedItems);
            Items = new ObservableCollection<RoleViewModel>(roleslist ?? new List<RoleViewModel>());
        }

    }
}
