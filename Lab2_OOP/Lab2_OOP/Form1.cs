using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lab2_OOP.Figures;
using Microsoft.VisualBasic;

namespace Lab2_OOP
{
    /// <summary>
    /// Main form of the primitive graphic editor.
    /// Allows the user to create figures via dialog input and draws them.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly FigureList _figures = new FigureList();

        // Map from figure type name to a function that creates a new figure instance.
        private readonly Dictionary<string, Func<Figure?>> _figureFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            _figureFactories = new Dictionary<string, Func<Figure?>>
            {
                { "Rectangle", CreateRectangle },
                { "Square", CreateSquare },
                { "Ellipse", CreateEllipse },
                { "Circle", CreateCircle },
                { "Line", CreateLine },
                { "Triangle", CreateTriangle }
            };

            // Fill combo box using keys from the factory dictionary.
            figureTypeComboBox.Items.AddRange(new List<string>(_figureFactories.Keys).ToArray());
            if (figureTypeComboBox.Items.Count > 0)
            {
                figureTypeComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the Add figure button click and creates a new figure using the selected factory.
        /// </summary>
        private void addFigureButton_Click(object? sender, EventArgs e)
        {
            if (figureTypeComboBox.SelectedItem is not string key)
            {
                return;
            }

            if (!_figureFactories.TryGetValue(key, out Func<Figure?>? factory))
            {
                return;
            }

            Figure? figure = factory();
            if (figure == null)
            {
                return;
            }

            _figures.Add(figure);
            Invalidate();
        }

        /// <summary>
        /// Draws all currently stored figures.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _figures.DrawAll(e.Graphics);
        }

        /// <summary>
        /// Creates a rectangle using dialog input for coordinates and color.
        /// </summary>
        private Figure? CreateRectangle()
        {
            if (!TryAskInt("Enter X of left side:", out int x) ||
                !TryAskInt("Enter Y of top side:", out int y) ||
                !TryAskInt("Enter width:", out int w) ||
                !TryAskInt("Enter height:", out int h) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new RectangleFigure(x, y, w, h, color);
        }

        /// <summary>
        /// Creates a square using dialog input.
        /// </summary>
        private Figure? CreateSquare()
        {
            if (!TryAskInt("Enter X of left side:", out int x) ||
                !TryAskInt("Enter Y of top side:", out int y) ||
                !TryAskInt("Enter size (side length):", out int size) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new Square(x, y, size, color);
        }

        /// <summary>
        /// Creates an ellipse using dialog input.
        /// </summary>
        private Figure? CreateEllipse()
        {
            if (!TryAskInt("Enter X of left side:", out int x) ||
                !TryAskInt("Enter Y of top side:", out int y) ||
                !TryAskInt("Enter width:", out int w) ||
                !TryAskInt("Enter height:", out int h) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new EllipseFigure(x, y, w, h, color);
        }

        /// <summary>
        /// Creates a circle using dialog input.
        /// </summary>
        private Figure? CreateCircle()
        {
            if (!TryAskInt("Enter X of left side:", out int x) ||
                !TryAskInt("Enter Y of top side:", out int y) ||
                !TryAskInt("Enter radius:", out int radius) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new Circle(x, y, radius, color);
        }

        /// <summary>
        /// Creates a line using dialog input.
        /// </summary>
        private Figure? CreateLine()
        {
            if (!TryAskInt("Enter X of first point:", out int x1) ||
                !TryAskInt("Enter Y of first point:", out int y1) ||
                !TryAskInt("Enter X of second point:", out int x2) ||
                !TryAskInt("Enter Y of second point:", out int y2) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new LineFigure(new Point(x1, y1), new Point(x2, y2), color);
        }

        /// <summary>
        /// Creates a triangle using dialog input.
        /// </summary>
        private Figure? CreateTriangle()
        {
            if (!TryAskInt("Enter X of first point:", out int x1) ||
                !TryAskInt("Enter Y of first point:", out int y1) ||
                !TryAskInt("Enter X of second point:", out int x2) ||
                !TryAskInt("Enter Y of second point:", out int y2) ||
                !TryAskInt("Enter X of third point:", out int x3) ||
                !TryAskInt("Enter Y of third point:", out int y3) ||
                !TryAskColor(out Color color))
            {
                return null;
            }

            return new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), color);
        }

        /// <summary>
        /// Asks the user for an integer value using a simple dialog.
        /// Returns false if the user cancels input.
        /// </summary>
        private bool TryAskInt(string message, out int value)
        {
            value = 0;

            while (true)
            {
                string input = Interaction.InputBox(message, "Figure parameter", "0");

                if (string.IsNullOrWhiteSpace(input))
                {
                    // Treat empty input as cancel.
                    return false;
                }

                if (int.TryParse(input, out value))
                {
                    return true;
                }

                MessageBox.Show(this, "Please enter a valid integer value.", "Invalid input", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Shows a color dialog and returns selected color.
        /// Returns false if the user cancels the dialog.
        /// </summary>
        private bool TryAskColor(out Color color)
        {
            using ColorDialog dialog = new ColorDialog
            {
                FullOpen = true
            };

            DialogResult result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                color = dialog.Color;
                return true;
            }

            color = Color.Black;
            return false;
        }
    }
}
