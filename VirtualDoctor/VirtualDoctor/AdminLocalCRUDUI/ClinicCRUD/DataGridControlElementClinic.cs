using AmbulanceDatabase;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.Shared.Controls.DataGridControls;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.ClinicCRUD
{
    public class DataGridControlElementClinic : DataGridControlElement
    {
        private readonly IClinicService clinicService = ServicesAmbulanceFactory.GetInstance().CreateIClinicService();
        private readonly IPlaceService placeService = ServicesAmbulanceFactory.GetInstance().CreateIPlaceService();
        public DataGridControlElementClinic()
        {
        }

        public DataGridControlElementClinic(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems) : base(dataGrid, pageInfo, totalNumberOfItems)
        {
        }

        public override async Task<int> GetNumberOfItems()
        {
            return await clinicService.GetTotalNumberOfItems();
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

        protected async override Task<IList> GetData(int index, int number)
        {
            List<Clinic> list = await clinicService.GetRange(index, number) as List<Clinic>;

            var modelList = list.Select(x => AutoMapper.Mapping.Mapper.Map<ClinicViewModel>(x)).ToList();
            foreach (var x in modelList)
            {
                x.Place = (await placeService.GetByPrimaryKey(new Place() { IdPlace = x.IdPlace })).ToString();
            }
            return modelList;
        }

        protected override Type GetDataType()
        {
            return typeof(ClinicViewModel);
        }
    }
}
