//using Android.Views;

namespace Calculate_Anton;

public partial class MainPage : ContentPage
{
    int currentState = 1;
    string operatorMath;
    float firstNum, secondNum;
    bool simvol = true;

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);
    }

    void OnClear(object sender, EventArgs e)// ОЧИСТКА
    {
        firstNum = 0;
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
    }

    void BackOneNumber(object sender, EventArgs e)// СТИРАНИЕ ОДНОГО ЧИСЛА
    {
        int leng =this.result.Text.Length-1;
        string tx= this.result.Text;
        this.result.Text = "";
        for (int i = 0; i < leng; i++)
        {
            this.result.Text = this.result.Text + tx[i];
        }
    }
    void plusminus(object sender, EventArgs e)// ОТРИЦАТЕЛЬНОЕ ИЛИ ПОЛОЖИТЕЛЬНОЕ ЧИСЛО
    {
        if (simvol == true)
        {
            this.result.Text = "-" + this.result.Text;
            simvol = false;
        }
        else if (simvol == false)
        {
            this.result.Text = this.result.Text.Replace("-", " ");
            simvol = true;
        }
    }

    //void adddote(object sender, EventArgs e)
    //{
    //    this.result.Text = this.result.Text + ",";
    //}

    void OnNumberSelection(object sender, EventArgs e)// ОПРЕДЕЛЕНИЕ И ОБРАБОТКА ЗНАКА 
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;

        float number;
        if (float.TryParse(this.result.Text, out number))
        {
            this.result.Text = number.ToString("N0");
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
    }


    void onOperatorSelection(object sender, EventArgs e)//ОПЕРАЦИЯ ВЫБОРА
    {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        operatorMath = btnPressed;
    }

    void onCalculate(object sender, EventArgs e)// КОНЕЧНЫЙ РАСЧЕТ
    {
        if (currentState == 2)
        {
            var result = Calculate.DoCalculation(firstNum, secondNum, operatorMath);

            this.result.Text = result.ToString();
            try
            {
                firstNum = float.Parse(result);
            }
            catch (Exception)
            {
                this.result.Text=result;

            }

            currentState = -1;
        }
    }


}

