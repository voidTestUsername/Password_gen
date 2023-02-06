using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_gen
{
    public partial class Form1 : Form
    {
        class Symbol_set
        {
            public int val, border1, border2;
            public void set_val(Random rand, int n1, int n2)
            {
                val = rand.Next(n1, n2);
            }
            public void set_borders(string setting)
            {
                if (setting == "A")
                {
                    border1 = 65;
                    border2 = 90;
                }
                else if(setting == "a")
                {
                    border1 = 97;
                    border2 = 122;
                }
                else if(setting == "0_")
                {
                    border1 = 48;
                    border2 = 57;
                }
                else if(setting == "!")
                {
                    border1 = 33;
                    border2 = 42;
                }
            }
            public Symbol_set()
            {
                val = 0;
                border1 = 0;
                border2 = 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Symbol_set set1 = new Symbol_set();
            Symbol_set set2 = new Symbol_set();
            Symbol_set set3 = new Symbol_set();
            Symbol_set set4 = new Symbol_set();

            int set_L = 4;
            Symbol_set[] set_arr = new Symbol_set[set_L];

            Random rand = new Random();
            int rand_key;

            const int L = 8;
            char[] password = new char[L];
            int[] pos_s = new int[L];

            set1.set_borders("A");
            set2.set_borders("a");
            set3.set_borders("0_");
            set4.set_borders("!");

            rand_key = rand.Next(0, 100);

            if (rand_key < 50)
            {
                set1.val = 2;

                rand_key = rand.Next(0, 100);

                if (rand_key < 50)
                {
                    set2.val = 2;

                    rand_key = rand.Next(0, 100);

                    if(rand_key < 50)
                    {
                        set3.val = 2;
                        set4.val = 2;
                    }
                    else
                    {
                        set3.val = 3;
                        set4.val = 1;
                    }
                }
                else
                {
                    set2.val = 3;

                    rand_key = rand.Next(0, 100);

                    if (rand_key < 50)
                    {
                        set3.val = 1;
                        set4.val = 2;
                    }
                    else
                    {
                        set3.val = 2;
                        set4.val = 1;
                    }
                }
            }
            else
            {
                set1.val = 3;
                set2.val = 2;

                rand_key = rand.Next(0, 100);

                if (rand_key < 50)
                {
                    set3.val = 1;
                    set4.val = 2;
                }
                else
                {
                    set3.val = 2;
                    set4.val = 1;
                }
            }

            set_arr[0] = set1;
            set_arr[1] = set2;
            set_arr[2] = set3;
            set_arr[3] = set4;

            for (int i = 0; i < L; i++)
            {
                pos_s[i] = i;
            }

            int n1, n2, temp_, set_c = 0;

            for (int i = 0; i < 100; i++)
            {
                n1 = rand.Next(0, L / 2);
                n2 = rand.Next(L / 2, L);

                temp_ = pos_s[n1];
                pos_s[n1] = pos_s[n2];
                pos_s[n2] = temp_;
            }

            for (int i = 0; i < L; i++)
            {
                if (set_arr[set_c].val == 0)
                {
                    set_c += 1;
                }

                password[pos_s[i]] = (char)(rand.Next(set_arr[set_c].border1, set_arr[set_c].border2));

                set_arr[set_c].val -= 1;
            }

            textBox1.Clear();

            for (int i = 0; i < L; i++)
            {
                textBox1.Text += password[i];
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }
    }
}
