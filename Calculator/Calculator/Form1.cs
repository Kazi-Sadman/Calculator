using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = string.Empty;
        string firstNum, secondNum;
        bool enterValue = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDisplay1.Text)) return;

                secondNum = txtDisplay1.Text;
                txtDisplay2.Text = $"{txtDisplay2.Text} {txtDisplay1.Text} =";

                if (txtDisplay1.Text == "0" && operation == "÷")
                {
                    MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (operation)
                {
                    case "+":
                        txtDisplay1.Text = (result + Double.Parse(txtDisplay1.Text)).ToString();
                        break;
                    case "-":
                        txtDisplay1.Text = (result - Double.Parse(txtDisplay1.Text)).ToString();
                        break;
                    case "×":  // Changed from "✕" to match your button
                        txtDisplay1.Text = (result * Double.Parse(txtDisplay1.Text)).ToString();
                        break;
                    case "÷":
                        txtDisplay1.Text = (result / Double.Parse(txtDisplay1.Text)).ToString();
                        break;
                    default:
                        txtDisplay2.Text = $"{txtDisplay1.Text}";
                        break;
                }
                result = Double.Parse(txtDisplay1.Text);
                operation = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Calculation error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMathOperation_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDisplay1.Text))
                {
                    MessageBox.Show("Please enter a number first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (result != 0 && !string.IsNullOrEmpty(operation))
                {
                    btnEquals.PerformClick();
                }
                else
                {
                    result = Double.Parse(txtDisplay1.Text);
                }

                Button button = (Button)sender;
                operation = button.Text;
                enterValue = true;

                txtDisplay2.Text = firstNum = $"{result} {operation}";
                txtDisplay1.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Operation error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDisplay1.Text == "0" || enterValue)
                {
                    txtDisplay1.Text = string.Empty;
                    enterValue = false;
                }

                Button button = (Button)sender;

                if (button.Text == ".")
                {
                    if (!txtDisplay1.Text.Contains("."))
                        txtDisplay1.Text += button.Text;
                }
                else
                {
                    txtDisplay1.Text += button.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Number input error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplicationExti_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (txtDisplay1.Text.Length > 0)
                txtDisplay1.Text = txtDisplay1.Text.Remove(txtDisplay1.Text.Length - 1, 1);
            if (txtDisplay1.Text == string.Empty) txtDisplay1.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay1.Text = "0";
            txtDisplay2.Text = string.Empty;
           result = 0;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;

            switch(operation)
            { 
                case "√x":
                    txtDisplay2.Text = $"√({txtDisplay1.Text})";
                    txtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(txtDisplay1.Text)));
                    break;
                case "x^2":
                    txtDisplay2.Text = $"({txtDisplay1.Text})^2";
                    txtDisplay1.Text = Convert.ToString(Convert.ToDouble(txtDisplay1.Text) * Convert.ToDouble(txtDisplay1.Text));
                    break;
                case "1/x":
                    txtDisplay2.Text = $"1/x({txtDisplay1.Text})";
                    txtDisplay1.Text = Convert.ToString(1.0 / Convert.ToDouble(txtDisplay1.Text));
                    break;
                case "%":
                    txtDisplay2.Text = $"%({txtDisplay1.Text})"; // This seems like a copy-paste error, should likely be related to percentage
                    txtDisplay1.Text = Convert.ToString(Convert.ToDouble(txtDisplay1.Text)/ Convert.ToDouble(100)); // This also seems like a copy-paste error
                    break;
                case "土": 
                    
                    txtDisplay1.Text = Convert.ToString(-1 * Convert.ToDouble(txtDisplay1.Text)); // This also seems like a copy-paste error
                    break;
                default:
                    break;
                }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtDisplay1.Text = "0";
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private Rectangle _normalWindowBounds; // Store the normal window position/size

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                // For borderless forms
                this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                // Optionally restore to default size
                this.Size = new Size(800, 600); // Your default size
                this.CenterToScreen();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization if needed
        }
    }
}