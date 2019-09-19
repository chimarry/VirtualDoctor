using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.DataGridControls;
using VirtualDoctor.ViewModels;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System.Windows;
using AmbulanceDatabase;
using VirtualDoctor.AutoMapper;
using AmbulanceDatabase.Views;

namespace VirtualDoctor.AdminLocalCRUDUI.DoctorCRUD
{
    public class DataGridControlElementDoctor : DataGridControlElement
    {
        private readonly IDoctorService doctorService = ServicesAmbulanceFactory.GetInstance().CreateIDoctorService();
        public DataGridControlElementDoctor()
        {
        }

        public DataGridControlElementDoctor(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems) : base(dataGrid, pageInfo, totalNumberOfItems)
        {
        }

        public override async Task<int> GetNumberOfItems()
        {
            return await doctorService.GetTotalNumberOfItems();
        }

        public override void HideColumns()
        {
            foreach (var column in DataGrid.Columns)
            {
                if (column.SortMemberPath.StartsWith("Id"))
                {
                    column.Visibility = Visibility.Hidden;
                }
            };
        }

        protected async override Task<IList> GetData(int index, int number)
        {
            var list = await doctorService.GetRangeViews(index,number) as List<DoctorsView>;
            return Mapping.Mapper.Map<List<DoctorsView>, List<DoctorViewModel>>(list);
        }

        protected override Type GetDataType()
        {
            return typeof(DoctorViewModel);
        }
    }
}
