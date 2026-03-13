using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab3_OOP
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Collection that stores all vehicles currently displayed on the form.
        /// BindingList is used to automatically update UI when list changes.
        /// </summary>
        private readonly BindingList<Vehicle> _vehicles = new();

        /// <summary>
        /// Creates main form and initializes all controls and data bindings.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeDataBinding();
        }

        /// <summary>
        /// Sets up bindings between UI controls and underlying data collections.
        /// </summary>
        private void InitializeDataBinding()
        {
            // Force creation of at least one instance of every known vehicle type.
            // This guarantees that static constructors are executed and all types
            // are registered inside VehicleRegistry before UI reads registry content.
            _ = new Car();
            _ = new Truck();
            _ = new Bus();
            _ = new Motorcycle();
            _ = new ElectricCar();
            _ = new SportsCar();

            // Bind list box to collection with vehicles.
            listBoxVehicles.DataSource = _vehicles;

            // Vehicle.ToString will be used for row text.
            // No additional configuration is required here.

            // Fill combo box with available vehicle types from registry.
            var factories = VehicleRegistry.GetAllFactories().ToList();
            comboBoxVehicleTypes.DataSource = factories;
            comboBoxVehicleTypes.DisplayMember = nameof(VehicleRegistry.VehicleFactoryInfo.DisplayName);
            comboBoxVehicleTypes.ValueMember = nameof(VehicleRegistry.VehicleFactoryInfo.TypeId);

            if (factories.Count > 0)
            {
                comboBoxVehicleTypes.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Called when user changes selected item inside list box.
        /// Property grid is updated with selected vehicle instance.
        /// </summary>
        private void listBoxVehicles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            propertyGridVehicle.SelectedObject = listBoxVehicles.SelectedItem;
        }

        /// <summary>
        /// Creates new vehicle of chosen type and adds it to collection.
        /// </summary>
        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            if (comboBoxVehicleTypes.SelectedItem is not VehicleRegistry.VehicleFactoryInfo info)
            {
                MessageBox.Show(this, "Please select vehicle type first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Create new instance using factory from registry.
            var vehicle = info.Factory();

            // Default values can be adjusted manually by user in property grid.
            _vehicles.Add(vehicle);
            listBoxVehicles.SelectedItem = vehicle;
        }

        /// <summary>
        /// Removes currently selected vehicle from collection.
        /// </summary>
        private void buttonRemove_Click(object? sender, EventArgs e)
        {
            var selected = listBoxVehicles.SelectedItem as Vehicle;
            if (selected == null)
            {
                MessageBox.Show(this, "Please select vehicle to remove.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _vehicles.Remove(selected);
            propertyGridVehicle.SelectedObject = null;
        }

        /// <summary>
        /// Serializes collection of vehicles into binary file.
        /// </summary>
        private void buttonSave_Click(object? sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Binary files|*.bin|All files|*.*",
                DefaultExt = "bin",
                AddExtension = true,
                FileName = "vehicles.bin"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                VehicleBinarySerializer.Save(dialog.FileName, _vehicles);
                MessageBox.Show(this, "Vehicles were successfully serialized.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show(this, $"I/O error while saving file: {ioEx.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Unexpected error while saving file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deserializes collection of vehicles from binary file and replaces current list.
        /// </summary>
        private void buttonLoad_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Binary files|*.bin|All files|*.*",
                DefaultExt = "bin",
                CheckFileExists = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var loaded = VehicleBinarySerializer.Load(dialog.FileName);

                _vehicles.Clear();
                foreach (var v in loaded)
                {
                    _vehicles.Add(v);
                }

                if (_vehicles.Count > 0)
                {
                    listBoxVehicles.SelectedIndex = 0;
                }

                MessageBox.Show(this, "Vehicles were successfully deserialized.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show(this, $"I/O error while loading file: {ioEx.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Unexpected error while loading file: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
