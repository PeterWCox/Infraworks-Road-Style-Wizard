using InfraworksClassLibrary;
using InfraworksClassLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace InfraworksJSONFrontEnd
{
    public partial class InfraworksRoadStyleWizardUI : Form
    {
        public InfraworksRoadStyleWizardUI()
        {
            InitializeComponent();
        }

        private void BtnExportToJSON_Click(object sender, EventArgs e)
        {
            //Check if number of rows in dgv is 0 - if so inform user and return
            if (dgvInputTable.Rows.Count == 0)
            {
                MessageBox.Show("Table does not have any rows - JSON file cannot be exported. Please check input and try again.");
                return;
            }
            
            //Remove any empty cellsthe datagridview
            foreach (DataGridViewRow rw in dgvInputTable.Rows)
            {
                for (int k = 0; k < rw.Cells.Count; k++)
                {
                    if (rw.Cells[k].Value == null || rw.Cells[k].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[k].Value.ToString()))
                    {
                        MessageBox.Show("Empty/null cells detected- please do not leave any cells blank or empty.");
                        return;
                    }
                }
            }

            //Create the main object 
            Master m = new Master();

            //Convert each row of the datagrid view into a List<object>
            string laneName = "ComponentDefinition/Lane";
            string shoulderName = "ComponentDefinition/Shoulder";
            bool showLaneMarkings = cbShowLaneMarkings.Checked;

            for (int i = 0; i < dgvInputTable.Rows.Count; i++)
            {
                //Get the RoadName
                string roadName = ParseDGVCellToString(dgvInputTable, i, 0);

                //Verify that the row doesnt contain any blank or empty spaces. 
                for (int k = 0; k < 18; k++)
                {
                    try
                    {
                        string s = dgvInputTable.Rows[i].Cells[k].Value.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Blank cells found for RoadName: {roadName} in row {i + 1}. " +
                         $"Please do not leave any blank/empty cells - if a width of 0m is required then use a value of 0 rather than leaving" +
                         $" it empty.");
                        return;
                    }
                }

                //Verify that revision can be parsed otherwise send nagging msgbox and return void;
                int revision;
                bool revisionTryParse = Int32.TryParse(dgvInputTable.Rows[i].Cells[1].Value.ToString(), out revision);
                if (revisionTryParse == false)
                {
                    MessageBox.Show($"Revision number was not of the correct format for RoadName: {roadName} in row {i + 1}. " +
                        $"Revision number must be an integer e.g. 0,1,2,3 etc. Please check input and try again.");
                    return;
                }

                //Verify that each and every road component can be parsed as a double, otherwise nag and return void;
                for (int j = 3; j <= 18; j++)
                {
                    double tryParse;
                    bool crossSectionsTryParse = double.TryParse(dgvInputTable.Rows[i].Cells[j].Value.ToString(), out tryParse);
                    if (crossSectionsTryParse == false || tryParse < 0)
                    {
                        MessageBox.Show($"One or more components were not of the correct format for Road Name {roadName}. All verges, hardstrips and carriageways must have a width >= 0 and must not contain any letters. " +
                            $"Please check input and try again.");
                        return;
                    }
                }



                //Start keying up the reference model objects based on the data in the newly validated
                //dgv 
                string description = ParseDGVCellToString(dgvInputTable, i, 2);
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

            string filePath = Directory.GetCurrentDirectory() + "\\InfraworksRoadStyleWizard_V1.0.styles.json";

            File.WriteAllText(filePath, json);

            MessageBox.Show($"JSON File Successfully Written to {filePath}.");
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
            dgvInputTable.Rows.Clear();

            try
            {
                //Open up the excel workbook 
                Excel.Application xlApp = new Excel.Application();
                string filePath = Directory.GetCurrentDirectory() + "\\InfraworksRoadStyleWizardInputFile_V1.0.xlsm";
                Excel._Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

                //Convert the non-empty rows into datagridview rows 
                //Start at row 4, end at 100. 

                for (int i = 4; i < 1000; i++)
                {
                    //Get the ith row - hence first row will be from cells B4-T4. 
                    //Save the row as a List<string> 
                    Excel.Range ExcelRange = xlWorksheet.Range[$"B{i}", $"T{i}"];
                    List<string> s = rangeToList(ExcelRange);

                    //Check if roadName is null/empty - if so end script and dispose resources 
                    if (s[0] == "")
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(xlWorksheet);
                        xlWorkbook.Close();
                        Marshal.ReleaseComObject(xlWorkbook);
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                        break;
                    }
                    //Else add the row to the datagridview table
                    else
                    {
                        dgvInputTable.Rows.Add(s.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Excel file to import from not found or corrupted. " +
                    "Please check file is in the right condition as per sheet 2 and check" +
                    "the URL is valid and try again.");
                return;
            }
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

        private List<string> rangeToList(Excel.Range inputRng)
        {
            object[,] cellValues = (object[,])inputRng.Value2;
            List<string> lst = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
            return lst;
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

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void DgvInputTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            dgvInputTable.Rows.Add();
        }

        private void BtnClearTable_Click(object sender, EventArgs e)
        {
            dgvInputTable.Rows.Clear();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnLink_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.eurocodehelpers.com");
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvInputTable.SelectedRows)
            {
                dgvInputTable.Rows.RemoveAt(row.Index);
            }
        }
    }
}
