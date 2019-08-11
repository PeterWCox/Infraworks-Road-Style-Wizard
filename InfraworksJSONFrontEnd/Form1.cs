using InfraworksClassLibrary;
using InfraworksClassLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace InfraworksJSONFrontEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvInputTable.Rows.Add();
            GenerateTestData1();
            GenerateTestData2();
        }

        private void GenerateTestData1()
        {
            dgvInputTable.Rows[0].Cells[0].Value = "The Lot";
            dgvInputTable.Rows[0].Cells[1].Value = 1;
            dgvInputTable.Rows[0].Cells[2].Value = "Literally Everything";

            dgvInputTable.Rows[0].Cells[3].Value = 3;
            dgvInputTable.Rows[0].Cells[4].Value = 1;
            dgvInputTable.Rows[0].Cells[5].Value = 3.65;
            dgvInputTable.Rows[0].Cells[6].Value = 3.65;
            dgvInputTable.Rows[0].Cells[7].Value = 3.65;
            dgvInputTable.Rows[0].Cells[8].Value = 3.65;
            dgvInputTable.Rows[0].Cells[9].Value = 1;
            dgvInputTable.Rows[0].Cells[10].Value = 1.25;

            dgvInputTable.Rows[0].Cells[11].Value = 1.25;
            dgvInputTable.Rows[0].Cells[12].Value = 1;
            dgvInputTable.Rows[0].Cells[13].Value = 3.65;
            dgvInputTable.Rows[0].Cells[14].Value = 3.65;
            dgvInputTable.Rows[0].Cells[15].Value = 3.65;
            dgvInputTable.Rows[0].Cells[16].Value = 3.65;
            dgvInputTable.Rows[0].Cells[17].Value = 1;
            dgvInputTable.Rows[0].Cells[18].Value = 3;
        }

        private void GenerateTestData2()
        {
            dgvInputTable.Rows[1].Cells[0].Value = "Single CW";
            dgvInputTable.Rows[1].Cells[1].Value = 1;
            dgvInputTable.Rows[1].Cells[2].Value = "Single carriageway with 2m Verges ";

            dgvInputTable.Rows[1].Cells[3].Value = 2;
            dgvInputTable.Rows[1].Cells[4].Value = 0;
            dgvInputTable.Rows[1].Cells[5].Value = 3.65;
            dgvInputTable.Rows[1].Cells[6].Value = 0;
            dgvInputTable.Rows[1].Cells[7].Value = 0;
            dgvInputTable.Rows[1].Cells[8].Value = 0;
            dgvInputTable.Rows[1].Cells[9].Value = 0;
            dgvInputTable.Rows[1].Cells[10].Value = 0;

            dgvInputTable.Rows[1].Cells[11].Value = 0;
            dgvInputTable.Rows[1].Cells[12].Value = 0;
            dgvInputTable.Rows[1].Cells[13].Value = 3.65;
            dgvInputTable.Rows[1].Cells[14].Value = 0;
            dgvInputTable.Rows[1].Cells[15].Value = 0;
            dgvInputTable.Rows[1].Cells[16].Value = 0;
            dgvInputTable.Rows[1].Cells[17].Value = 0;
            dgvInputTable.Rows[1].Cells[18].Value = 2;
        }


        private void BtnExportToJSON_Click(object sender, EventArgs e)
        {
            //TODO - Perform data validation on datagridView 

            //Create the main object 
            Master m = new Master();
            m.city_name = txtCityName.Text;
            m.session_id = txtSessionID.Text;

            //Convert each row of the datagrid view into a List<object>

            string laneName = "ComponentDefinition/Lane";
            string shoulderName = "ComponentDefinition/Shoulder";
            bool showLaneMarkings = cbShowLaneMarkings.Checked;

            for (int i = 0; i < dgvInputTable.Rows.Count; i++)
            {
                double cr1 = ParseDGVCellToDouble(dgvInputTable, i, 10);
                double hs1_LHS = ParseDGVCellToDouble(dgvInputTable, i, 9);
                double L4 = ParseDGVCellToDouble(dgvInputTable, i, 8);
                double L3 = ParseDGVCellToDouble(dgvInputTable, i, 7);
                double L2 = ParseDGVCellToDouble(dgvInputTable, i, 6);
                double L1 = ParseDGVCellToDouble(dgvInputTable, i, 5);
                double hs2_LHS = ParseDGVCellToDouble(dgvInputTable, i, 4);
                double verge_LHS = ParseDGVCellToDouble(dgvInputTable, i, 3);

                double cr2 = ParseDGVCellToDouble(dgvInputTable, i, 11);
                double hs1_RHS = ParseDGVCellToDouble(dgvInputTable, i, 12);
                double L5 = ParseDGVCellToDouble(dgvInputTable, i, 13);
                double L6 = ParseDGVCellToDouble(dgvInputTable, i, 14);
                double L7 = ParseDGVCellToDouble(dgvInputTable, i, 15);
                double L8 = ParseDGVCellToDouble(dgvInputTable, i, 16);
                double hs2_RHS = ParseDGVCellToDouble(dgvInputTable, i, 17);
                double verge_RHS = ParseDGVCellToDouble(dgvInputTable, i, 18);

                string roadName = ParseDGVCellToString(dgvInputTable, i, 0);
                int revision = ParseDGVCellToInt(dgvInputTable, i, 1);
                string description = ParseDGVCellToString(dgvInputTable, i, 2);

                List<ReferenceModel> rm = new List<ReferenceModel>()
                {
                new ReferenceModel(shoulderName, cr1, true),
                new ReferenceModel(laneName, hs1_LHS, true),
                new ReferenceModel(laneName, L4, true),
                new ReferenceModel(laneName, L3, true),
                new ReferenceModel(laneName, L2, true),
                new ReferenceModel(laneName, L1, true),
                new ReferenceModel(laneName, hs2_LHS, true),
                new ReferenceModel(shoulderName, verge_LHS, true),

                new ReferenceModel(shoulderName, cr2, false),
                new ReferenceModel(laneName, hs1_RHS, false),
                new ReferenceModel(laneName, L5, false),
                new ReferenceModel(laneName, L6, false),
                new ReferenceModel(laneName, L7, false),
                new ReferenceModel(laneName, L8, false),
                new ReferenceModel(laneName, hs2_RHS, false),
                new ReferenceModel(shoulderName, verge_RHS, false)
                };

                //TODO fix hardcoded reference for showmarking 
                component c = new component();
                c.styleType = "Component";
                c.name = roadName;
                c.description = description;
                c.category = "assembly";
                c.showMarking = showLaneMarkings;   
                c.revision = revision;
                c.AddListComponents(rm);

                m.AddComponent($"Component/Custom/{roadName}", c);
            };

            //Write to JSON file 
            string json = JsonConvert.SerializeObject(m,
               Formatting.Indented,
               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string fileName = txtJSONFileName.Text;

            File.WriteAllText(fileName, json);

            MessageBox.Show($"JSON File Successfully Written to {fileName}.");
        }

        private static double ParseDGVCellToDouble(DataGridView dgv, int row, int column)
        {
            return double.Parse(dgv.Rows[row].Cells[column].Value.ToString());
        }

        private static int ParseDGVCellToInt(DataGridView dgv, int row, int column)
        {
            return int.Parse(dgv.Rows[row].Cells[column].Value.ToString());
        }

        private static string ParseDGVCellToString(DataGridView dgv, int row, int column)
        {
            return dgv.Rows[row].Cells[column].Value.ToString();
        }

        private void BtnImportFromExcel_Click(object sender, EventArgs e)
        {
            //Clear all data in the existing table
            RemoveAllRows(dgvInputTable);

            //Open up the excel workbook 
            Excel.Application xlApp = new Excel.Application();
            Excel._Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\pcox\Desktop\infraworksTestFile.xlsm");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range oRng;
            xlApp.Visible = true;

            //Start Excel and get Application object.



            //Count the number of rows that are non empty 

            //For each row, transform to the datagridview 
        }

        public static void RemoveAllRows(DataGridView dgv)
        {
            do
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    try
                    {
                        dgv.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dgv.Rows.Count > 1);
        }


    }
}
