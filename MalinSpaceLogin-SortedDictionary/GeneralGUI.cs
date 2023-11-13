using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace MalinSpaceLogin_SortedDictionary
{
    public partial class GeneralGUI : Form
    {
        public GeneralGUI()
        {
            InitializeComponent();
            ConfigureTraceListener();
            ReadData();
            DisplayDataInListBox();
            this.KeyPreview = true;
            ClearAllTexts();
        }
        private void ConfigureTraceListener()
        {
            string logFilePath = "TraceOutput.log";
            TextWriterTraceListener textListener = new TextWriterTraceListener(File.Create(logFilePath));
            Trace.Listeners.Add(textListener);
        }


        private object lastItemSelected = null;
        private bool wasEnterKeyPressed = false;

        //6.1.	Create a SortedDictionary data structure with a TKey of type integer and a TValue of type string,
        //      name the new data structure “MasterFile”.

        public static SortedDictionary <int, string> MasterFile = new SortedDictionary <int, string> ();

        //6.2.	Create a method that will read the data from the.csv file into the SortedDictionary data structure when the GUI loads.
        private void ReadData()
        {
            Trace.WriteLine("Tracing 6.2 ReadData() in SortedDictionary");
            Stopwatch sw = Stopwatch.StartNew();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MalinStaffNamesV2.csv");

            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');

                        // Assuming well-formed CSV and error handling for parsing 
                        // the integer and avoiding duplicate keys.
                        if (parts.Length == 2
                            && int.TryParse(parts[0], out int id)
                            && !MasterFile.ContainsKey(id))
                        {
                            MasterFile.Add(id, parts[1]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stLabel.Text = "Warning";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stLabel.Text = "Error";
            }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for ReadData() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //6.3.	Create a method to display the SortedDictionary data into a non-selectable display only list box (ie read only).
        private void DisplayDataInListBox()
        {
            Trace.WriteLine("Tracing 6.3 DisplayDataInListBox() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                lbStaffMain.Items.Clear();  // Clear any existing items

                foreach (var entry in MasterFile)
                {
                    lbStaffMain.Items.Add($"{entry.Key}    |    {entry.Value}");
                }

                lbStaffMain.SelectionMode = SelectionMode.None;  // Make the list box non-selectable
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stLabel.Text = "Error";
            }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for DisplayDataInListBox() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //6.4.	Create a method to filter the Staff Name data from the SortedDictionary into a second filtered and selectable list box.
        //      This method must use a text box input and update as each character is entered.
        //      The list box must reflect the filtered data in real time.
        private void FilterByNameAndDisplay()
        {
            Trace.WriteLine("Tracing 6.4 FilterByNameAndDisplay() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    lbStaffSecondary.Items.Clear();
                    stLabel.Text = string.Empty;
                }
                else
                {
                    var query = tbName.Text.Trim().ToLower();
                    lbStaffSecondary.Items.Clear();
                    var filteredStaff = MasterFile.Where(s => s.Value.ToLower().Contains(query)).ToList();
                    foreach (var entry in filteredStaff)
                    {
                        lbStaffSecondary.Items.Add($"{entry.Key}    |    {entry.Value}");
                    }
                }
                stLabel.Text = "Filter by name is underway";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stLabel.Text = "Error";
            }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for FilterByNameAndDisplay() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            FilterByNameAndDisplay();
        }

        //6.5.	Create a method to filter the Staff ID data from the SortedDictionary into the second filtered and selectable list box.
        //      This method must use a text box input and update as each number is entered.
        //      The list box must reflect the filtered data in real time.
        private void FilterByIDAndDisplay()
        {
            Trace.WriteLine("Tracing 6.5 FilterByIDAndDisplay() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                if (string.IsNullOrWhiteSpace(tbID.Text))
                {
                    lbStaffSecondary.Items.Clear();
                    stLabel.Text = string.Empty;
                }
                else
                {
                    var query = tbID.Text;
                    lbStaffSecondary.Items.Clear();
                    var filteredStaff = MasterFile.Where(s => s.Key.ToString().Contains(query)).ToList();
                    foreach (var entry in filteredStaff)
                    {
                        lbStaffSecondary.Items.Add($"{entry.Key}    |    {entry.Value}");
                    }
                }
                stLabel.Text = "Filter by ID is underway";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stLabel.Text = "Error";
            }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for  FilterByIDAndDisplay() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            FilterByIDAndDisplay();
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Mark the event as handled, which prevents the key from being processed
            }
        }

        //6.6.	Create a method for the Staff Name text box which will clear the contents and place the focus into the Staff Name text box.
        //      Utilise a keyboard shortcut.
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            // Alt + N
            if (e.Alt && e.KeyCode == Keys.N)
            {
                ClearAndFocusTextBox(tbName);
                e.Handled = true;
                stLabel.Text = "Name field is cleared";
            }
        }

        private void ClearAndFocusTextBox(System.Windows.Forms.TextBox tb)
        {
            tb.Clear();
            tb.Focus();
        }

        //6.7.	Create a method for the Staff ID text box which will clear the contents and place the focus into the text box.
        //      Utilise a keyboard shortcut.
        private void tbID_KeyDown(object sender, KeyEventArgs e)
        {
            // Alt + I
            if (e.Alt && e.KeyCode == Keys.I)
            {
                ClearAndFocusTextBox(tbID);
                e.Handled = true;
                stLabel.Text = "ID field is cleared";
            }
        }

        //6.8.	Create a method for the filtered and selectable list box which will populate the two text boxes
        //      when a staff record is selected.Utilise the Tab and keyboard keys.
        private void lbStaffSecondary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                PopulateTextboxes();
                e.Handled = true;
                wasEnterKeyPressed = true;
            }
        }

        private void lbStaffSecondary_SelectedIndexChanged(object sender, EventArgs e)
        {

            lastItemSelected = lbStaffSecondary.SelectedItem;
        }

        private void PopulateTextboxes()
        {
            Trace.WriteLine("Tracing 6.8 PopulateTextboxes() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            if (lastItemSelected != null)
            {
                string[] parts = lastItemSelected.ToString().Split(new string[] { "    |    " }, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    tbID.Text = parts[0].Trim();
                    tbName.Text = parts[1].Trim();
                }
            }
            stLabel.Text = "Details are available";
            sw.Stop();
            Trace.WriteLine($"The elapsed time for PopulateTextboxes() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //6.9.	Create a method that will open the Admin GUI when the Alt + A keys are pressed.
        //      Ensure the General GUI sends the currently selected Staff ID and Staff Name
        //      to the Admin GUI for Update and Delete purposes and is opened as modal.
        //      Create modified logic to open the Admin GUI to Create a new user when the Staff ID 77
        //      and the Staff Name is empty.Read the appropriate criteria in the Admin GUI for further information.
        private void GeneralGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.A)
            {
                OpenAdminGUI();
            }

            // Quality of life
            if (e.Alt && e.KeyCode == Keys.C)
            {
                ClearAllTexts();
            }
        }

        private void OpenAdminGUI()
        {
            Trace.WriteLine("Tracing 6.9 OpenAdminGUI() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // Check if SelectedItem is not null
                if (lastItemSelected != null)
                {
                    AdminGUI admin = new AdminGUI();
                    //Assuming the selected item's text is in the format "ID    |    Name"
                    string[] parts = lastItemSelected.ToString().Split(new string[] { "    |    " }, StringSplitOptions.None);

                    if (parts.Length == 2)
                    {
                        string id = parts[0].Trim();
                        string name = parts[1].Trim();

                        // Populate the AdminGUI form with selected values
                        admin.SetStaffInfo(name, id);
                    }
                    admin.ShowDialog();
                }
                else if (lastItemSelected == null && tbID.Text == "77" && tbName.Text == string.Empty)
                {
                    AdminGUI admin = new AdminGUI();

                    admin.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                stLabel.Text = "Error";
            }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for OpenAdminGUI() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //6.10.	Add suitable error trapping and user feedback via a status strip or similar to ensure a fully functional User Experience.
        //      Make all methods private and ensure the Dictionary is static and public.

        #region Quality of Life

        private void tbName_MouseClick(object sender, MouseEventArgs e)
        {
            if (!wasEnterKeyPressed)
            {
                tbID.Text = string.Empty;
            }
            wasEnterKeyPressed = false;
        }

        private void tbID_MouseClick(object sender, MouseEventArgs e)
        {
            if (!wasEnterKeyPressed)
            {
                tbName.Text = string.Empty;
            }
            wasEnterKeyPressed = false;
        }

        private void ClearAllTexts()
        {
            tbID.Text = string.Empty;
            tbName.Text = string.Empty;
            lbStaffSecondary.Items.Clear();
            lastItemSelected = null;
            this.Focus();
            stLabel.Text = string.Empty;
        }

        private void GeneralGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.Flush();
            foreach (TraceListener listener in Trace.Listeners) { listener.Close(); }
        }
        #endregion

        //6.11.	Ensure all code is adequately commented.Map the programming criteria and features to your code/methods
        //      by adding comments above the method signatures.
        //      Ensure your code is compliant with the CITEMS coding standards (refer http://www.citems.com.au/).

    }
}
