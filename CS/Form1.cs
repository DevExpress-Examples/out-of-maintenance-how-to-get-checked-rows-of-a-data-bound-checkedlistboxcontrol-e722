using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;

namespace WindowsApplication11
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.DataSource = this.dataTable1;
            this.checkedListBoxControl1.DisplayMember = "Name";
            this.checkedListBoxControl1.Location = new System.Drawing.Point(7, 7);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(200, 166);
            this.checkedListBoxControl1.TabIndex = 0;
            this.checkedListBoxControl1.ValueMember = "ID";
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ID"}, true)});
            this.dataTable1.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "ID";
            this.dataColumn1.DataType = typeof(System.Guid);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Name";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Checked";
            this.dataColumn3.DataType = typeof(bool);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(7, 187);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(200, 20);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Get checked rows";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(8, 216);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(200, 20);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Toggle 1st row check";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(219, 250);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Name = "Form1";
            this.Text = "How to get the checked rows of a data-bound CheckedListBoxControl";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			for(int i = 0; i < 5; i++)
				dataTable1.Rows.Add(new object[] {Guid.NewGuid(), "Item " + i.ToString(), i % 2 == 0});

			FillCheckedItems();
		}

		private void simpleButton1_Click(object sender, System.EventArgs e) {
			string result = "";
			foreach(object item in checkedListBoxControl1.CheckedItems) {
				DataRowView row = item as DataRowView;
				result += string.Format("{0}\t{1}\t{2}\r\n", row["ID"], row["Name"], row["Checked"]);
			}
			MessageBox.Show(result);
		}

		bool lockItemCheck = false;
		void FillCheckedItems() {
			lockItemCheck = true;
			try {
				for(int i = 0; i < dataTable1.DefaultView.Count; i++) {
					DataRowView row = dataTable1.DefaultView[i];
					if(true.Equals(row["Checked"]))
						checkedListBoxControl1.SetItemChecked(i, true);
				}
			}
			finally {
				lockItemCheck = false;
			}			
		}
		
		private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e) {
			if(lockItemCheck) return;
			DataRowView row = dataTable1.DefaultView[e.Index];
			row["Checked"] = e.State == CheckState.Checked;
		}

        private void simpleButton2_Click(object sender, System.EventArgs e) {
            bool val = checkedListBoxControl1.GetItemChecked(0);
            checkedListBoxControl1.SetItemChecked(0, !val);
        }
	} 
}
