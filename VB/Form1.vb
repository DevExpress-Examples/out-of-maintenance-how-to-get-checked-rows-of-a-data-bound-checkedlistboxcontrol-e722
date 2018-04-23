Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraEditors

Namespace WindowsApplication11
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents checkedListBoxControl1 As DevExpress.XtraEditors.CheckedListBoxControl
		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private dataColumn2 As System.Data.DataColumn
		Private dataColumn3 As System.Data.DataColumn
		Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
		Private WithEvents simpleButton2 As DevExpress.XtraEditors.SimpleButton
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.checkedListBoxControl1 = New DevExpress.XtraEditors.CheckedListBoxControl()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			Me.dataColumn3 = New System.Data.DataColumn()
			Me.dataSet1 = New System.Data.DataSet()
			Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
			Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.checkedListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' checkedListBoxControl1
			' 
			Me.checkedListBoxControl1.CheckOnClick = True
			Me.checkedListBoxControl1.DataSource = Me.dataTable1
			Me.checkedListBoxControl1.DisplayMember = "Name"
			Me.checkedListBoxControl1.Location = New System.Drawing.Point(7, 7)
			Me.checkedListBoxControl1.Name = "checkedListBoxControl1"
			Me.checkedListBoxControl1.Size = New System.Drawing.Size(200, 166)
			Me.checkedListBoxControl1.TabIndex = 0
			Me.checkedListBoxControl1.ValueMember = "ID"
'			Me.checkedListBoxControl1.ItemCheck += New DevExpress.XtraEditors.Controls.ItemCheckEventHandler(Me.checkedListBoxControl1_ItemCheck);
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2, Me.dataColumn3})
			Me.dataTable1.Constraints.AddRange(New System.Data.Constraint() { New System.Data.UniqueConstraint("Constraint1", New String() { "ID"}, True)})
			Me.dataTable1.PrimaryKey = New System.Data.DataColumn() { Me.dataColumn1}
			Me.dataTable1.TableName = "Table1"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.AllowDBNull = False
			Me.dataColumn1.ColumnName = "ID"
			Me.dataColumn1.DataType = GetType(System.Guid)
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "Name"
			' 
			' dataColumn3
			' 
			Me.dataColumn3.ColumnName = "Checked"
			Me.dataColumn3.DataType = GetType(Boolean)
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Locale = New System.Globalization.CultureInfo("en-US")
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' simpleButton1
			' 
			Me.simpleButton1.Location = New System.Drawing.Point(7, 187)
			Me.simpleButton1.Name = "simpleButton1"
			Me.simpleButton1.Size = New System.Drawing.Size(200, 20)
			Me.simpleButton1.TabIndex = 1
			Me.simpleButton1.Text = "Get checked rows"
'			Me.simpleButton1.Click += New System.EventHandler(Me.simpleButton1_Click);
			' 
			' simpleButton2
			' 
			Me.simpleButton2.Location = New System.Drawing.Point(8, 216)
			Me.simpleButton2.Name = "simpleButton2"
			Me.simpleButton2.Size = New System.Drawing.Size(200, 20)
			Me.simpleButton2.TabIndex = 2
			Me.simpleButton2.Text = "Toggle 1st row check"
'			Me.simpleButton2.Click += New System.EventHandler(Me.simpleButton2_Click);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(219, 250)
			Me.Controls.Add(Me.simpleButton2)
			Me.Controls.Add(Me.simpleButton1)
			Me.Controls.Add(Me.checkedListBoxControl1)
			Me.Name = "Form1"
			Me.Text = "How to get the checked rows of a data-bound CheckedListBoxControl"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.checkedListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			For i As Integer = 0 To 4
				dataTable1.Rows.Add(New Object() {Guid.NewGuid(), "Item " & i.ToString(), i Mod 2 = 0})
			Next i

			FillCheckedItems()
		End Sub

		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButton1.Click
			Dim result As String = ""
			For Each item As Object In checkedListBoxControl1.CheckedItems
				Dim row As DataRowView = TryCast(item, DataRowView)
				result &= String.Format("{0}" & Constants.vbTab & "{1}" & Constants.vbTab & "{2}" & Constants.vbCrLf, row("ID"), row("Name"), row("Checked"))
			Next item
			MessageBox.Show(result)
		End Sub

		Private lockItemCheck As Boolean = False
		Private Sub FillCheckedItems()
			lockItemCheck = True
			Try
				For i As Integer = 0 To dataTable1.DefaultView.Count - 1
					Dim row As DataRowView = dataTable1.DefaultView(i)
					If True.Equals(row("Checked")) Then
						checkedListBoxControl1.SetItemChecked(i, True)
					End If
				Next i
			Finally
				lockItemCheck = False
			End Try
		End Sub

		Private Sub checkedListBoxControl1_ItemCheck(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles checkedListBoxControl1.ItemCheck
			If lockItemCheck Then
				Return
			End If
			Dim row As DataRowView = dataTable1.DefaultView(e.Index)
			row("Checked") = e.State = CheckState.Checked
		End Sub

		Private Sub simpleButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles simpleButton2.Click
			Dim val As Boolean = checkedListBoxControl1.GetItemChecked(0)
			checkedListBoxControl1.SetItemChecked(0, (Not val))
		End Sub
	End Class
End Namespace
