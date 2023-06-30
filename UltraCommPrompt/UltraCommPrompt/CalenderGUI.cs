using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace UltraCommPrompt
{
    public partial class CalenderGUI : Form
    {
        public CalenderGUI()
        {
            InitializeComponent();
        }

        private void CalenderGUI_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //change the output label depending on click of the enter button
        private void button1_Click(object sender, EventArgs e)
        {
            //change the text of the output label 
            //use the string from the textbox as an input
            this.label3.Text = weekdayOutput(this.textBox1.Text);
        }

        private string weekdayOutput(string input)
        {
            //use helper functions to determine if input is valid and to calculate the correct weekday
            return validDate(input) ? calculateDay(input) : "Invalid Format \n(Use MM/DD/YYYY date format)";
        }

        private bool validDate(string input)
        {
            //create a regex string that matches to accepted MM/DD/YYYY date format
            string matchRegex = @"\d{1,2}[-/\.]\d{1,2}[-/\.]\d\d\d\d";
            Regex re = new Regex(matchRegex);

            //if a match return true, else return false (using ternary operator)
            return re.IsMatch(input) ? true : false;
        }

        private string calculateDay(string input)
        {
            char[] seperators = { '-', '/', '.' };
            string[] date = input.Split(seperators);
            int month = int.Parse(date[0]);
            int day = int.Parse(date[1]);
            int year = int.Parse(date[2]);

            bool leapyear = false;
            if (year % 4 == 0)
                leapyear = true;

            //a couple cases that catch impossible dates
            if (year < 1753)
                return "Date is too far in past!";
            if (year > 2099)
                return "Date it too far in future!";
            if (day < 1 || month > 12)
                return "Invalid Date!!";

            //Step A
            int weekday_value = year % 100;
            //Step B
            weekday_value += (weekday_value / 4);
            //Step C
            weekday_value += day;
            //Step D create a switch case table to add appropriate amount
            //to determine value that represents what day of the week
            //Also let the cases catch invalid dates!
            switch (month)
            {
                case 1:
                    if (day > 31)
                        return "Invalid Date!!";
                    if(!leapyear)
                        weekday_value += 1;
                    break;
                case 2:
                    if (!leapyear) 
                    {
                        if (day > 28)
                            return "Invalid Date!!";
                        weekday_value += 4;
                    }
                    else
                    {
                        if (day > 29)
                            return "Invalid Date!!";
                        weekday_value += 3;
                    }
                    break;
                case 3:
                    if (day > 31)
                        return "Invalid Date!!";
                    weekday_value += 4;
                    break;
                case 4:
                    if (day > 30)
                        return "Invalid Date!!";
                    break;
                case 5:
                    if (day > 31)
                        return "Invalid Date!!";
                    weekday_value += 2;
                    break;
                case 6:
                    if (day > 30)
                        return "Invalid Date!!";
                    weekday_value += 5;
                    break;
                case 7:
                    if (day > 31)
                        return "Invalid Date!!";
                    break;
                case 8:
                    if (day > 31)
                        return "Invalid Date!!";
                    weekday_value += 3;
                    break;
                case 9:
                    if (day > 30)
                        return "Invalid Date!!";
                    weekday_value += 6;
                    break;
                case 10:
                    if (day > 31)
                        return "Invalid Date!!";
                    weekday_value += 1;
                    break;
                case 11:
                    if (day > 30)
                        return "Invalid Date!!";
                    weekday_value += 4;
                    break;
                case 12:
                    if (day > 31)
                        return "Invalid Date!!";
                    weekday_value += 6;
                    break;
            }

            //Final Step to determine weekday value before division
            if (year >= 2000 && year <= 2099)
                weekday_value -= 1;
            else if (year < 1800)
                weekday_value += 4;
            else if (year < 1900)
                weekday_value += 2;

            //Return the correct weekday depending on value!
            int weekday_choice = weekday_value % 7;
            switch (weekday_choice)
            {
                case 0:
                    return "Saturday";
                case 1:
                    return "Sunday";
                case 2:
                    return "Monday";
                case 3:
                    return "Tuesday";
                case 4:
                    return "Wednesday";
                case 5:
                    return "Thursday";
                case 6:
                    return "Friday";
            }
            return "this should never be returned";
        }
    }
}
