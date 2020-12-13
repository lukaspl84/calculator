using System;
using System.Windows.Forms;

namespace Kalkulator
{
    /// <summary>
    /// The main Calculator class.
    /// Contains all methods for performing basic math functions.
    /// </summary>
    /// <remarks>
    /// This class can add, subtract, multiply and divide.
    /// </remarks>
    public partial class Kalkulator : Form
    {
        private byte _variable = 0;
        private float _operand = 0;
        private bool _dot = false, _clearDisplay = true;

        /// <summary>
        /// Public constructor of the Calculator class.
        /// It initiates all of the needed components on the view.
        /// </summary>
        public Kalkulator() => InitializeComponent();

        /// <summary>
        /// Private functions which prepares and performs the requested operation type.
        /// </summary>
        /// <param name="operationType">The type of the requested operation to perform.</param>
        /// <remarks>
        /// Parameter `operType` can be 1 (adding), 2 (subtracting), 3 (multiplying) or 4 (dividing).
        /// </remarks>
        private void Calculate(byte operationType)
        {
            var operandB = float.Parse(textBoxResult.Text);
            if (_variable == 0)
            {
                _operand = operandB;
                _clearDisplay = true;
                _dot = false;
                _variable = operationType;
            }
            else
            {
                if (_variable == operationType)
                {
                    _operand = OperationCalculation(_operand, operandB, _variable);
                    textBoxResult.Text = Convert.ToString(_operand);
                    _clearDisplay = true;
                    _dot = false;
                }
                else
                {
                    if (_clearDisplay)
                    {
                        _variable = operationType;
                    }
                    else
                    {
                        _operand = OperationCalculation(_operand, operandB, _variable);
                        textBoxResult.Text = Convert.ToString(_operand);
                        _clearDisplay = true;
                        _dot = false;
                        _variable = operationType;
                    }
                }
            }
        }

        /// <summary>
        /// Functions which performs the requested operation type on two float parameters.
        /// </summary>
        /// <param name="operA">The first float parameter.</param>
        /// <param name="operB">The second float parameter.</param>
        /// <param name="operType">The type of the requested operation to perform.</param>
        /// <returns>The operation result based on the passed parameters and the operation type to perform.</returns>
        /// <remarks>
        /// Parameter `operType` can be 1 (adding), 2 (subtracting), 3 (multiplying) or 4 (dividing).
        /// </remarks>
        public float OperationCalculation(float operA, float operB, byte operType)
        {
            float result = 0;
            switch (operType)
            {
                case 1:
                    result = operA + operB;
                    break;

                case 2:
                    result = operA - operB;
                    break;

                case 3:
                    result = operA * operB;
                    break;

                case 4:
                    result = operA / operB;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Event click handler on the dot (.) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!_dot)
            {
                if (_clearDisplay)
                {
                    textBoxResult.Text = "0,";
                    _clearDisplay = false;
                }
                else
                {
                    textBoxResult.Text += ",";
                }
                _dot = true;
            }
        }

        /// <summary>
        /// Event click handler on the CE button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            _variable = 0;
        }

        /// <summary>
        /// Event click handler on the C button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonC_Click(object sender, EventArgs e)
        {
            _clearDisplay = true;
            _dot = false;
            _operand = 0;
            _variable = 0;
            textBoxResult.Text = "0";
        }

        /// <summary>
        /// Event click handler on the dot add (+) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Calculate(1);
        }

        /// <summary>
        /// Event click handler on the substract (-) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonSub_Click(object sender, EventArgs e)
        {
            Calculate(2);
        }

        /// <summary>
        /// Event click handler on the multiply (*) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonMul_Click(object sender, EventArgs e)
        {
            Calculate(3);
        }

        /// <summary>
        /// Event click handler on the divide (/) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Calculate(4);
        }

        /// <summary>
        /// Event click handler on the equals (=) button.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (_variable > 0)
            {
                var operandB = float.Parse(textBoxResult.Text);
                _operand = OperationCalculation(_operand, operandB, _variable);
                textBoxResult.Text = Convert.ToString(_operand);
                _clearDisplay = true;
                _dot = false;
                _variable = 0;
            }
        }

        /// <summary>
        /// Event click handler on the all digits (0-9) buttons.
        /// </summary>
        /// <param name="sender">The object sender button</param>
        /// <param name="e">Event data that provides values to use for event click button.</param>
        private void buttNum_Click(object sender, EventArgs e)
        {
            var buttonTxt = ((Button)sender).Text;
            if (textBoxResult.Text == "0" || _clearDisplay)
            {
                textBoxResult.Text = buttonTxt;
                _clearDisplay = false;
            }
            else
            {
                textBoxResult.Text += buttonTxt;
            }
        }
    }
}