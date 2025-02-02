﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.Json;


namespace CryptoScreener1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string response = client.DownloadString($"https://api.coingecko.com/api/v3/simple/price?ids={textBox1.Text}&vs_currencies=usd");
                        decimal price = JsonDocument.Parse(response).RootElement.GetProperty(textBox1.Text).GetProperty("usd").GetDecimal();
                        label1.Text = "The Price of " + textBox1.Text + " is: " + price.ToString();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    throw;
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}