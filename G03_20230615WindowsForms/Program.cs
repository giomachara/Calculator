using System;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace G03_20230615WindowsForms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorForm calculatorForm = new CalculatorForm();
            Application.EnableVisualStyles();
            Application.Run(calculatorForm);
        }
    }

    class CalculatorForm : Form
    {
        private TextBox _txtMessage;
        private Button _btnExit;
        private Button _btnEqual;
        private Button _btnEmpty;

        double x, y;
        char operation;

        Size formSize = new Size(500, 570);
        Size btnSize = new Size(90, 90);
        Font btnFont = new Font("Arial", 18);
        System.Threading.Timer timer;

        public CalculatorForm()
        {
            this.Text = "Calculator";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = formSize;
            this.Font = btnFont;

            AddControls();
            AddNumButtons();
            AddMathButtons();
        }



        private void AddControls()
        {
            _txtMessage = new NumericTextBox();
            _btnExit = new Button();
            _btnEqual = new Button();
            _btnEmpty = new Button();

            _txtMessage.Location = new Point(30, 10);
            _txtMessage.Multiline = false;
            _txtMessage.Font = new Font("Arial", 25);
            _txtMessage.Size = new Size(310, 0);
            _txtMessage.MaxLength = 9;

            _btnExit.Text = "Exit";
            _btnExit.Location = new Point(30, 400);
            _btnExit.Size = btnSize;
            _btnExit.Click += (s, a) => this.Close();

            _btnEqual.Text = "=";
            _btnEqual.Location = new Point(360, 400);
            _btnEqual.Size = btnSize;
            _btnEqual.Click += EqualBtnClick;

            _btnEmpty.Size = new Size(310, 35);
            _btnEmpty.Location = new Point(30, 60);
            _btnEmpty.Text = "Clear";
            _btnEmpty.Click += ClearBtnClick;

            this.Controls.Add(_txtMessage);
            this.Controls.Add(_btnExit);
            this.Controls.Add(_btnEqual);
            this.Controls.Add(_btnEmpty);
        }

        private void AddMathButtons()
        {
            Button btnDivide = new Button();
            btnDivide.Location = new Point(360, 5);
            btnDivide.Text = "/";
            btnDivide.Size = btnSize;
            btnDivide.Click += OperationBtnClick;

            Button btnMultiply = new Button();
            btnMultiply.Location = new Point(360, 100);
            btnMultiply.Text = "*";
            btnMultiply.Size = btnSize;
            btnMultiply.Click += OperationBtnClick;

            Button btnMinus = new Button();
            btnMinus.Location = new Point(360, 200);
            btnMinus.Text = "-";
            btnMinus.Size = btnSize;
            btnMinus.Click += OperationBtnClick;

            Button btnPlus = new Button();
            btnPlus.Location = new Point(360, 300);
            btnPlus.Text = "+";
            btnPlus.Size = btnSize;
            btnPlus.Click += OperationBtnClick;

            this.Controls.Add(btnDivide);
            this.Controls.Add(btnMultiply);
            this.Controls.Add(btnMinus);
            this.Controls.Add(btnPlus);
        }

        private void OperationBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                x = Convert.ToDouble(_txtMessage.Text);
            }

            operation = (sender as Button).Text[0];
            _txtMessage.ResetText();

            if (operation == '/' && y == 0)
            {
                MessageBox.Show(new DivideByZeroException().Message);
                _txtMessage.ResetText();
                return;
            }
            Calculate();
        }

        #region old methods
        private void DivideBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                x = Convert.ToDouble(_txtMessage.Text);
            }

            operation = (sender as Button).Text[0];
            _txtMessage.ResetText();
        }

        private void MultiplyBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                x = Convert.ToDouble(_txtMessage.Text);
            }

            operation = (sender as Button).Text[0];
            _txtMessage.ResetText();
        }

        private void MinusBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                x = Convert.ToDouble(_txtMessage.Text);
            }

            operation = (sender as Button).Text[0];
            _txtMessage.ResetText();
        }

        private void PlusBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                x = Convert.ToDouble(_txtMessage.Text);
            }

            operation = (sender as Button).Text[0];
            _txtMessage.ResetText();
        }

        #endregion

        private void EqualBtnClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.HasValue())
            {
                y = Convert.ToDouble(_txtMessage.Text);
            }


            if (operation == '/' && y == 0)
            {
                MessageBox.Show(new DivideByZeroException().Message);
                _txtMessage.ResetText();
                return;
            }
            _txtMessage.Text = Calculate().ToString();
        }

        private void ClearBtnClick(object sender, EventArgs e)
        {
            x = y = 0;
            _txtMessage.ResetText();
        }

        private double Calculate()
        {
            switch (operation)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '/':
                    return x / y;
                case '*':
                    return x * y;

                default:
                    return default;
            }
        }

        #region old buttons
        //private void AddNumButtons()
        //{
        //    Button btnDot = new Button();
        //    btnDot.Location = new Point(250, 400);
        //    btnDot.Text = ".";
        //    btnDot.Size = btnSize;

        //    Button btnZero = new Button();
        //    btnZero.Location = new Point(140, 400);
        //    btnZero.Text = "0";
        //    btnZero.Size = btnSize;

        //    Button btnOne = new Button();
        //    btnOne.Location = new Point(30, 300);
        //    btnOne.Text = "1";
        //    btnOne.Size = btnSize;

        //    Button btnTwo = new Button();
        //    btnTwo.Location = new Point(140, 300);
        //    btnTwo.Text = "2";
        //    btnTwo.Size = btnSize;

        //    Button btnThree = new Button();
        //    btnThree.Location = new Point(250, 300);
        //    btnThree.Text = "3";
        //    btnThree.Size = btnSize;

        //    Button btnFour = new Button();
        //    btnFour.Location = new Point(30, 200);
        //    btnFour.Text = "4";
        //    btnFour.Size = btnSize;

        //    Button btnFive = new Button();
        //    btnFive.Location = new Point(140, 200);
        //    btnFive.Text = "5";
        //    btnFive.Size = btnSize;

        //    Button btnSix = new Button();
        //    btnSix.Location = new Point(250, 200);
        //    btnSix.Text = "6";
        //    btnSix.Size = btnSize;

        //    Button btnSeven = new Button();
        //    btnSeven.Location = new Point(30, 100);
        //    btnSeven.Text = "7";
        //    btnSeven.Size = btnSize;

        //    Button btnEight = new Button();
        //    btnEight.Location = new Point(140, 100);
        //    btnEight.Text = "8";
        //    btnEight.Size = btnSize;

        //    Button btnNine = new Button();
        //    btnNine.Location = new Point(250, 100);
        //    btnNine.Text = "9";
        //    btnNine.Size = btnSize;

        //    this.Controls.Add(btnDot);
        //    this.Controls.Add(btnZero);
        //    this.Controls.Add(btnOne);
        //    this.Controls.Add(btnTwo);
        //    this.Controls.Add(btnThree);
        //    this.Controls.Add(btnFour);
        //    this.Controls.Add(btnFive);
        //    this.Controls.Add(btnSix);
        //    this.Controls.Add(btnSeven);
        //    this.Controls.Add(btnEight);
        //    this.Controls.Add(btnNine);
        //}
        #endregion
        private void AddNumButtons()
        {
            AddButton(".", new Point(250, 400));
            AddButton("0", new Point(140, 400));
            AddButton("1", new Point(30, 300));
            AddButton("2", new Point(140, 300));
            AddButton("3", new Point(250, 300));
            AddButton("4", new Point(30, 200));
            AddButton("5", new Point(140, 200));
            AddButton("6", new Point(250, 200));
            AddButton("7", new Point(30, 100));
            AddButton("8", new Point(140, 100));
            AddButton("9", new Point(250, 100));
        }

        private void AddButton(string text, Point location)
        {
            Button button = new Button();
            button.Location = location;
            button.Text = text;
            button.Size = btnSize;
            button.Click += ButtonClick;
            Controls.Add(button);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (_txtMessage.Text.Length < _txtMessage.MaxLength)
            {
                var value = (sender as Button).Text;
                _txtMessage.Text += value;
            }
            else
            {
                BlinkConf();
                MessageBox.Show("ტენილი ყველი გიყვარს?");
                timer.Dispose();

                _txtMessage.ForeColor = Color.Black;
            }
        }

        private void BlinkConf()
        {
            timer = new System.Threading.Timer(Blink, null, 0, 100);
        }

        private void Blink(object state)
        {
            _txtMessage.ForeColor = _txtMessage.ForeColor == Color.Black ? Color.Red : Color.Black;
        }

        public class NumericTextBox : TextBox
        {
            public NumericTextBox()
            {
                this.KeyPress += NumericTextBox_KeyPress;
            }

            private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }

            }
        }

    }

    public static class StringExtensions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}