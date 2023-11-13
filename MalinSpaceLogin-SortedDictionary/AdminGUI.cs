using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace MalinSpaceLogin_SortedDictionary
{
    public partial class AdminGUI : Form
    {
        public AdminGUI()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        //7.1.	Create the Admin GUI with the following settings: Form is model, all Control Box features are removed/hidden,
        //      then add two text boxes.The text box for the Staff ID should be read-only for Update and Delete purposes.


        //7.2.	Create a method that will receive the Staff ID from the General GUI and then populate text boxes with the related data.

        // Inside AdminGUI.cs
        public void SetStaffInfo(string name, string staffID)
        {
            tbID.Text = staffID;
            tbName.Text = name;
        }


        //7.3.	Create a method that will create a new Staff ID and input the staff name from the related text box.
        //      The Staff ID must be unique starting with 77xxxxxxx while the staff name may be duplicated.
        //      The new staff member must be added to the SortedDictionary data structure.
        private int GenerateUniqueID()
        {
            Random random = new Random();
            int uniqueID;
            try
            {
                do
                {
                    uniqueID = random.Next(0, 10000000) + 770000000;
                }
                while (GeneralGUI.MasterFile.ContainsKey(uniqueID));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return uniqueID;
        }

        private void AddStaff()
        {
            Trace.WriteLine("Tracing 7.3 GenerateUniqueID() and AddStaff() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            int staffID = GenerateUniqueID();
            try
            {
                // ensures a valid ID was generated
                if (staffID != 0 && tbID.Text == string.Empty)
                {
                    string name = tbName.Text.Trim();
                    // ensures name isn't empty or white space
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        GeneralGUI.MasterFile.Add(staffID, name);
                        MessageBox.Show("New entry has been added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Please enter a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("This staff ID is already in the record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for GenerateUniqueID() and AddStaff() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //7.4.	Create a method that will Update the name of the current Staff ID.
        private void UpdateStaffName()
        {
            Trace.WriteLine("Tracing 7.4 UpdateStaffName() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // Ensure there's a valid ID in tbID and a name in tbName
                if (int.TryParse(tbID.Text, out int staffID) && !string.IsNullOrEmpty(tbName.Text))
                {
                    if (GeneralGUI.MasterFile.ContainsKey(staffID))
                    {
                        // Update the name associated with the staff ID
                        GeneralGUI.MasterFile[staffID] = tbName.Text.Trim();
                        MessageBox.Show("Name updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show($"Staff ID {staffID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Please enter a valid Staff ID and Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for UpdateStaffName() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //7.5.	Create a method that will Remove the current Staff ID and clear the text boxes.
        private void RemoveStaff()
        {
            Trace.WriteLine("Tracing 7.5 RemoveStaff() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // Ensure there's a valid ID in tbID and a name in tbName
                if (int.TryParse(tbID.Text, out int staffID) && !string.IsNullOrEmpty(tbName.Text))
                {
                    if (GeneralGUI.MasterFile.ContainsKey(staffID))
                    {
                        // Delete the selected entry
                        GeneralGUI.MasterFile.Remove(staffID);
                        tbID.Text = string.Empty;
                        tbName.Text = string.Empty;
                        MessageBox.Show("Selected entry has been deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show($"Staff ID {staffID} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Please enter a valid Staff ID and Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for RemoveStaff() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        //7.6.	Create a method that will save changes to the csv file, this method should be called as the Admin GUI closes.
        private void SaveToCSV()
        {
            Trace.WriteLine("Tracing 5.6 SaveToCSV() in Dictionary");
            Stopwatch sw = Stopwatch.StartNew();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MalinStaffNamesV2.csv");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false)) // False means overwrite the file
                {
                    foreach (var entry in GeneralGUI.MasterFile)
                    {
                        writer.WriteLine($"{entry.Key},{entry.Value}"); // Write each key,value pair as a line in the CSV
                    }
                }
                MessageBox.Show("New file is saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            sw.Stop();
            Trace.WriteLine($"The elapsed time for SaveToCSV() is {sw.ElapsedTicks} ticks");
            Trace.WriteLine("---");
            Trace.Flush();
        }

        private void AdminGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToCSV();
        }

        //7.7.	Create a method that will close the Admin GUI when the Alt + L keys are pressed.
        private void AdminGUI_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Alt + L keys are pressed
            if (e.Alt && e.KeyCode == Keys.L)
                this.Close();

            if (e.Control && e.KeyCode == Keys.A)
                AddStaff();

            if (e.Control && e.KeyCode == Keys.U)
                UpdateStaffName();

            if (e.Control && e.KeyCode == Keys.D)
                RemoveStaff();
        }

        //7.8.	Add suitable error trapping and user feedback via a status strip or similar to ensure a fully functional User Experience.
        //      Make all methods private and ensure the SortedDictionary is updated.


        //7.9.	Ensure all code is adequately commented.
        //      Map the programming criteria and features to your code/methods by adding comments above the method signatures.
        //      Ensure your code is compliant with the CITEMS and MS coding standards (refer http://www.citems.com.au/).


    }
}
