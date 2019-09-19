using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualDoctor.LoginAuthentication;
using VirtualDoctor.Shared.Config;

namespace VirtualDoctor.Shared.Controls.DataGridControls
{
    public abstract class DataGridControlElement
    {
        public static int FIRST_NUMBER = 0;
        protected IList ListForPage { get; set; }
        public int TotalNumberOfItems { get; set; }


        protected int NumberOfRecordsPerPage { get; set; } = Config.Properties.Default.NumberOfRecordsPerPage;
        protected int NextNumber { get; set; } = 0;

        public DataGrid DataGrid { get; set; }
        public Label PageInfo { get; set; }

        private Pager PagedTable;


        public DataGridControlElement(DataGrid dataGrid, Label pageInfo, int totalNumberOfItems)
        {
            TotalNumberOfItems = totalNumberOfItems;
            DataGrid = dataGrid;
            PageInfo = pageInfo;

        }

        public DataGridControlElement()
        {
            SetTotalNumberOfItems();

        }
        public async void SetTotalNumberOfItems()
        {
            TotalNumberOfItems = await GetNumberOfItems();
            if (TotalNumberOfItems < NumberOfRecordsPerPage)
            {
                NumberOfRecordsPerPage = TotalNumberOfItems;
            }
        }
        public async Task Show()
        {
            PagedTable = new Pager() { DataType = GetDataType(), TotalNumberToDisplay = TotalNumberOfItems };
            await SetFields(FIRST_NUMBER);
            SetPage(PagedTable.First(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }
        public async Task Last_Click(object sender, RoutedEventArgs e)
        {
            await SetFields(TotalNumberOfItems - NumberOfRecordsPerPage);
            SetPage(PagedTable.Last(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }

        public async Task Forward_Click(object sender, RoutedEventArgs e)
        {
            await SetFields(NumberOfRecordsPerPage + NextNumber);
            SetPage(PagedTable.Next(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }

        public async Task Backwards_Click(object sender, RoutedEventArgs e)
        {
            await SetFields(NextNumber - NumberOfRecordsPerPage);
            SetPage(PagedTable.Previous(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }

        public async Task First_Click(object sender, RoutedEventArgs e)
        {
            await SetFields(FIRST_NUMBER);
            SetPage(PagedTable.First(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }
        public async Task Refresh()
        {
            SetPage(PagedTable.First(ListForPage, NumberOfRecordsPerPage).DefaultView);
            TotalNumberOfItems =await GetNumberOfItems();
            SetPage(PagedTable.First(ListForPage, NumberOfRecordsPerPage).DefaultView);
        }
        public string PageNumberDisplay()
        {
            int PagedNumber = (NextNumber + NumberOfRecordsPerPage) > TotalNumberOfItems ? TotalNumberOfItems : NextNumber + NumberOfRecordsPerPage;
            return language.ShowingResults + (PagedNumber + @"/" + TotalNumberOfItems);
        }
        protected async Task SetFields(int nextNumber)
        {
            if (nextNumber <= 0)
            {
                nextNumber = 0;
            }
            NextNumber = nextNumber;
            ListForPage = await GetData(NextNumber, NumberOfRecordsPerPage);
        }
        protected void SetPage(DataView dataViewToDisplay)
        {
            DataGrid.ItemsSource = dataViewToDisplay;
            PageInfo.Content = PageNumberDisplay();
        }
        protected abstract Task<IList> GetData(int index, int number);

        public void InitializeColumns()
        {
            ResourceManager rm = new ResourceManager("VirtualDoctor.Shared.Config.language", Assembly.GetExecutingAssembly());
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            foreach (var x in DataGrid.Columns)
            {
                x.Header = rm.GetString(x.SortMemberPath, cultureInfo) ?? x.SortMemberPath;
            }
            HideColumns();
        }
        public abstract void HideColumns();

        public abstract Task<int> GetNumberOfItems();
        protected abstract Type GetDataType();
        private class Pager
        {
            public int PageIndex { get; set; }

            public Type DataType { get; set; }

            public int TotalNumberToDisplay { get; set; }

            private DataTable PagedList = new DataTable();
            public DataTable Next(IList ListToPage, int RecordsPerPage)
            {
                PageIndex++;
                if (PageIndex >= TotalNumberToDisplay / RecordsPerPage)
                {
                    PageIndex = TotalNumberToDisplay / RecordsPerPage;
                }
                PagedList = PageTable(ListToPage);
                return PagedList;
            }

            public DataTable Previous(IList ListToPage, int RecordsPerPage)
            {
                PageIndex--;
                if (PageIndex <= FIRST_NUMBER)
                {
                    PageIndex = FIRST_NUMBER;
                }
                PagedList = PageTable(ListToPage);
                return PagedList;
            }


            public DataTable First(IList ListToPage, int RecordsPerPage)
            {
                PageIndex = FIRST_NUMBER;
                PagedList = PageTable(ListToPage);
                return PagedList;
            }

            public DataTable Last(IList ListToPage, int RecordsPerPage)
            {
                PageIndex = ListToPage.Count / RecordsPerPage;
                PagedList = PageTable(ListToPage);
                return PagedList;
            }

            public DataTable PageTable(IList SourceList)
            {
                DataTable TableToReturn = new DataTable();

                ResourceManager rm = new ResourceManager("VirtualDoctor.Shared.Config.language", Assembly.GetExecutingAssembly());
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                foreach (var Column in DataType.GetProperties())
                {
                    TableToReturn.Columns.Add(Column.Name, Column.PropertyType);
                }

                foreach (object item in SourceList)
                {
                    DataRow ReturnTableRow = TableToReturn.NewRow();
                    foreach (var Column in DataType.GetProperties())
                    {
                        ReturnTableRow[Column.Name] = Column.GetValue(item);
                    }
                    TableToReturn.Rows.Add(ReturnTableRow);
                }
                return TableToReturn;
            }

        }
    }
}

