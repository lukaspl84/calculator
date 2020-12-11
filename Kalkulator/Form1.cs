using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{/// <summary>
/// 
/// </summary>
    public partial class Kalkulator : Form
    {
        private byte variable = 0;

        private float memory = 0, operand = 0;

        private bool dot = false, clearDisplay = true; 

        /// konfiguracja znaku kropki (.)
        private void dotCheck()
        {
            if (this.textBoxResult.Text.IndexOf(".") > 0)
            {
                this.dot = true;
            }
            else
            {
                this.dot = false;
            }
        }
        public Kalkulator()
        {
            InitializeComponent();
        }

        /// konfiguracja do obliczeń
        private void calculate(byte operationType)
        {
            float operandB = float.Parse(this.textBoxResult.Text);
            if (this.variable == 0)
            {
                this.operand = operandB;
                this.clearDisplay = true;
                this.dot = false;
                this.variable = operationType;
            }
            else
            {
                if (this.variable == operationType)
                {
                    this.operand = this.operationCalculation(this.operand, operandB, this.variable);
                    this.textBoxResult.Text = Convert.ToString(this.operand);
                    this.clearDisplay = true;
                    this.dot = false;
                }
                else
                {
                    if (this.clearDisplay)
                    {
                        this.variable = operationType;
                    }
                    else
                    {
                        this.operand = this.operationCalculation(this.operand, operandB, this.variable);
                        this.textBoxResult.Text = Convert.ToString(this.operand);
                        this.clearDisplay = true;
                        this.dot = false;
                        this.variable = operationType;
                    }
                }
            }
        }

        /// konfiguracja operacji obliczania
        private float operationCalculation(float operA, float operB, byte operType)
        {
            float result = 0;
            switch (operType)
            {
                
                /// operacja dodawania
                case 1:
                    result = operA + operB;
                break;
                
                /// operacja odejmowania
                case 2:
                    result = operA - operB;
                break;
                
                /// operacja mnożenia
                case 3:
                    result = operA * operB;
                break;
                
                /// operacja dzielenia
                case 4:                                      
                   result = operA / operB;                    
                break;
            }
            return result;
        }

        /// konfiguracja przycisku kropki (.)
        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!this.dot)
            {
                if (this.clearDisplay)
                {
                    this.textBoxResult.Text = "0,";
                    this.clearDisplay = false;
                }
                else
                {
                    this.textBoxResult.Text += ",";
                }
                this.dot = true;
            }
        }

        /// konfiguracja przycisku CE
        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            variable = 0;
        }

        /// konfiguracja przycisku C
        private void buttonC_Click(object sender, EventArgs e)
        {
            this.clearDisplay = true;
            this.dot = false;
            this.operand = 0;
            this.memory = 0;
            this.variable = 0;
            this.textBoxResult.Text = "0";
        }

        /// konfiguracja przycisku dodawania (+)
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.calculate(1);
        }

        /// konfiguracja przycisku odejmowania (-)
        private void buttonSub_Click(object sender, EventArgs e)
        {
            this.calculate(2);
        }
        
        /// konfiguracja przycisku mnożenia (*)
        private void buttonMul_Click(object sender, EventArgs e)
        {
            this.calculate(3);
        }

        /// konfiguracja przycisku dzielenia (/)
        private void buttonDiv_Click(object sender, EventArgs e)
        {
            this.calculate(4);
        }

        /// konfikuracja przycisku równa się (=)
        private void buttonResult_Click(object sender, EventArgs e)
        {
            if (this.variable > 0)
            {
                float operandB = float.Parse(this.textBoxResult.Text);
                this.operand = this.operationCalculation(this.operand, operandB, this.variable);
                this.textBoxResult.Text = Convert.ToString(this.operand);
                this.clearDisplay = true;
                this.dot = false;
                this.variable = 0;
            }
        }

        /// konfiguracja przycisków numerycznych od 0 do 9
        private void buttNum_Click(object sender, EventArgs e)
        {
            var buttonTxt = ((Button)sender).Text;
            if ((this.textBoxResult.Text == "0") || (this.clearDisplay))
            {
            this.textBoxResult.Text = buttonTxt;
            this.clearDisplay = false;
            }
            else
            {
                this.textBoxResult.Text += buttonTxt;
            }
        }
    }
}