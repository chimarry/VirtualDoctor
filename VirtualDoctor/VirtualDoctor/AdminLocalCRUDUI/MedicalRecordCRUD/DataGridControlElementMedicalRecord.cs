using AmbulanceDatabase.Views;
using AmbulanceServices.Factories;
using AmbulanceServices.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.AutoMapper;
using VirtualDoctor.Shared.Controls.DataGridControls;
using VirtualDoctor.ViewModels;

namespace VirtualDoctor.AdminLocalCRUDUI.MedicalRecordCRUD
{
    public class DataGridControlElementMedicalRecord : DataGridControlElement
    {
        private readonly IMedicalRecordService medicalRecordService = ServicesAmbulanceFactory.GetInstance().CreateIMedicalRecordService();

        public DataGridControlElementMedicalRecord()
        {
        }

        public DataGridControlElementMedicalRecord(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems) : base(dataGrid, pageInfo, totalNumberOfItems)
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
            };
        }
        public override async Task<int> GetNumberOfItems()
        {
            return await medicalRecordService.GetTotalNumberOfItems();
        }
        protected async override Task<IList> GetData(int index, int number)
        {
            var list = await medicalRecordService.GetRangeViews(index,number) as List<MedicalRecordsView>;
     
            return Mapping.Mapper.Map<List<MedicalRecordsView>, List<MedicalRecordViewModel>>(list);
        }

        protected override Type GetDataType()
        {
            return typeof(MedicalRecordViewModel);
        }
    }
}
