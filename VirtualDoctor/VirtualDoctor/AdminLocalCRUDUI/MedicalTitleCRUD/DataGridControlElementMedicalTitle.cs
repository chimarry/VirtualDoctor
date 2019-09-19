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

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalTitleCRUD
{
    public class DataGridControlElementMedicalTitle : DataGridControlElement
    {
        private readonly IMedicalTitleService medicalTitleService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalTitleService();
        public DataGridControlElementMedicalTitle()
        {
        }

        public DataGridControlElementMedicalTitle(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems) : base(dataGrid, pageInfo, totalNumberOfItems)
        {
        }
        public override async Task<int> GetNumberOfItems()
        {
            return await medicalTitleService.GetTotalNumberOfItems();
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

            List<MedicalTitle> titles = await medicalTitleService.GetRange(index, number) as List<MedicalTitle>;

            return titles.Select(x => AutoMapper.Mapping.Mapper.Map<MedicalTitleViewModel>(x)).ToList();
        }

        protected override Type GetDataType()
        {
            return typeof(MedicalTitleViewModel);
        }
    }
}
