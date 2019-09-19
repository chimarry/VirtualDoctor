using AmbulanceDatabase.Entities;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.DataGridControls;
using VirtualDoctor.ViewModels;
namespace VirtualDoctor.AdminLocalCRUDUI.RoleCRUD
{
    public class DataGridControlElementRoles : DataGridControlElement
    {
        private readonly IRoleService roleService = ServicesAmbulanceFactory.GetInstance().CreateIRoleService();
        public DataGridControlElementRoles(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems) : base(dataGrid, pageInfo, totalNumberOfItems)
        {
        }
        public DataGridControlElementRoles():base()
        {

        }
        public override void HideColumns()
        {
            foreach (var column in DataGrid.Columns)
            {
                if (column.SortMemberPath.StartsWith("Id"))
                {
                    column.Visibility = Visibility.Hidden;
                }
            }
        }

        protected override async Task<IList> GetData(int index, int number)
        {
            List<Role> list = await roleService.GetRange(index,number) as List<Role>;
            return list.Select(x => AutoMapper.Mapping.Mapper.Map<RoleViewModel>(x)).ToList();
        }

        protected override Type GetDataType()
        {
            return typeof(RoleViewModel);
        }

        public override async Task<int> GetNumberOfItems()
        {
            return await roleService.GetTotalNumberOfItems();
        }
    }
}
