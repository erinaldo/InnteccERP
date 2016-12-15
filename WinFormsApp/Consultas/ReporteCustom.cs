using System.Collections;
using System.Data;
using ActionService;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.Design;

namespace WinFormsApp
{
    public partial class ReporteCustom : DevExpress.XtraEditors.XtraForm
    {
        private static Service _service = new Service();
        private GridEditorCollection gridEditors;
        public ReporteCustom()
        {
            InitializeComponent();

            InitLookUpDataTable();

            this.gridEditors = new GridEditorCollection();
            InitInplaceEditors();

            //<gridControl1>
            this.gridEditors = new GridEditorCollection();
            InitInplaceEditors();
            this.gridControl1.DataSource = gridEditors;
            //</gridControl1>
        }

        private void InitInplaceEditors()
        {

            this.gridEditors.Add(this.repositoryItemDateEdit , "Fecha Inicial", System.DateTime.Now);
            this.gridEditors.Add(this.repositoryItemDateEdit, "Fecha Final", System.DateTime.Now);
            this.gridEditors.Add(this.repositoryItemLookUpEdit, "Cliente", 2);
            
                    
        }

        void AddRecordToLookUpDataTable(string fName, string department)
        {
            DataRow row = this.dataTableLookUp.NewRow();
            row["clnId"] = this.dataTableLookUp.Rows.Count + 1;
            row["clnName"] = fName;
            row["clnDepartment"] = department;
            this.dataTableLookUp.Rows.Add(row);
        }
        void InitLookUpDataTable()
        {
            AddRecordToLookUpDataTable("Paul Bailey", "Management");
            AddRecordToLookUpDataTable("Brad Barnes", "QA");
            AddRecordToLookUpDataTable("Jerry Campbell", "RD");
            AddRecordToLookUpDataTable("Carl Lucas", "Documentation");
            AddRecordToLookUpDataTable("Peter Dolan", "Marketing");
            AddRecordToLookUpDataTable("Ryan Fischer", "RD");

        }


        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == this.gridEditorValue)
            {
                GridEditorItem item = gridView1.GetRow(e.RowHandle) as GridEditorItem;
                if (item != null) e.RepositoryItem = item.RepositoryItem;
            }
        }
    }

    public class GridEditorItem
    {
        string fName;
        object fValue;
        RepositoryItem fRepositoryItem;

        public GridEditorItem(RepositoryItem fRepositoryItem, string fName, object fValue)
        {
            this.fRepositoryItem = fRepositoryItem;
            this.fName = fName;
            this.fValue = fValue;
        }
        public string Name { get { return this.fName; } }
        public object Value { get { return this.fValue; } set { this.fValue = value; } }
        public RepositoryItem RepositoryItem { get { return this.fRepositoryItem; } }
    }

    class GridEditorCollection : ArrayList
    {
        public GridEditorCollection()
        {
        }
        public new GridEditorItem this[int index] { get { return base[index] as GridEditorItem; } }
        public void Add(RepositoryItem fRepositoryItem, string fName, object fValue)
        {
            base.Add(new GridEditorItem(fRepositoryItem, fName, fValue));
        }
    }
}