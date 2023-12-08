using System.Collections;  //for the arraylist

namespace evans
{
    public partial class Form1 : Form
    {

        // for storing new word and concatinated word.

        ArrayList newArrayWord = new ArrayList();
        ArrayList newConWord = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //in the event that the button to add a new word was clicked
            //1. retrieve the word from the text box
            String newWord = txtnewword.Text;
            //2. check if textbox is not empty
            if (newWord.Length == 0)
            {
                //display a message asking the user to enter a word
                MessageBox.Show("Please enter a word in the textbox");
            }
            else
            {
                bool exist = false;
                //check if the word already exist in the combobox
                foreach (var item in comboBox1.Items)
                {
                    //check each item in the combobox if we can find the new word entered by the user
                    if (item.ToString().Equals(newWord, StringComparison.OrdinalIgnoreCase))
                    {
                        exist = true;
                        break;
                    }
                }//end of for each loop
                //check if the word was found
                if (exist)
                {
                    MessageBox.Show("Word already exist please choose another word");
                }
                else
                {
                    //check if the checkbox is empty or contain the same word again
                    String output = txtAnswer.Text;
                    bool appears = output.Contains(newWord);
                    //if yes display a message
                    if (appears)
                    {
                        MessageBox.Show("Word already in output box");
                    }
                    else//add word to textbox and add new word to comboboxes
                    {
                        String finalword = output + newWord;
                        txtAnswer.Text = finalword;
                        comboBox1.Items.Add(newWord);//adding new word to the combobox
                        comboBox2.Items.Add(newWord);//adding new word to the combobox
                        MessageBox.Show("Word was added");//display a message for the user tto know the word was added
                        newArrayWord.Add(newWord);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //on load add a place older 
            comboBox2.Items.Add("--word--");
            comboBox1.Items.Add("--word--");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //remove word from left combobox
                if (comboBox1.SelectedIndex > 0)
                {
                    comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                    comboBox1.SelectedIndex = 0;
                }
            }
            else if (radioButton2.Checked)
            {
                //remove word from right combobox
                //remove word from left combobox
                if (comboBox2.SelectedIndex > 0)
                {
                    comboBox2.Items.RemoveAt(comboBox1.SelectedIndex);
                    comboBox2.SelectedIndex = 0;
                }

            }
            else
            {
                //concatenate word
                String wordleft = comboBox1.SelectedItem.ToString();
                String wordright = comboBox2.SelectedItem.ToString();
                //check if a word was selected

                if (wordleft.Equals("--word--") || wordright.Equals("--word--"))
                {
                    MessageBox.Show("Please select a word in both");
                }
                else
                {
                    if (wordleft.Equals(wordright))
                    {
                        MessageBox.Show("ComboBox one cannot have the same word selected as ComboBox two.");
                    }
                    else
                    {
                        String conc = wordleft + wordright;
                        txtAnswer.Text += conc;
                        newConWord.Add(conc);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Text = "Remove Item";
            }
            else
            {
                button1.Text = "Concatenate";

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button1.Text = "Remove Item";
            }
            else
            {
                button1.Text = "Concatenate";

            }

        }
    }
}