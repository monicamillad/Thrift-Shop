using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thrift_Shop
{
    public partial class SortedProducts : Form
    {
        public SortedProducts()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sort = comboBox1.SelectedItem.ToString();
            String order = comboBox2.SelectedItem.ToString();

            Model1 db = new Model1();

            if( sort.Equals("Name") )
            {
                if(order.Equals("Ascending"))
                {
                    var q = from p in db.products
                            orderby p.name ascending
                            select new
                            {
                                name = p.name,
                                price = p.price,
                                category = p.category,
                                brand = p.brand.name
                            };

                    dataGridView1.DataSource = q.ToList();
                }
                else
                {
                    var q = from p in db.products                           
                            orderby p.name descending
                            select new
                            {
                                name = p.name,
                                price = p.price,
                                category = p.category,
                                brand = p.brand.name
                            };

                    dataGridView1.DataSource = q.ToList();
                }
            }
            else
            {
                if (order.Equals("Ascending"))
                {
                    var q = from p in db.products                           
                            orderby p.price ascending
                            select new
                            {
                                name = p.name,
                                price = p.price,
                                category = p.category,
                                brand = p.brand.name
                            };

                    dataGridView1.DataSource = q.ToList();
                }
                else
                {
                    var q = from p in db.products                            
                            orderby p.price descending
                            select new
                            {
                                name = p.name,
                                price = p.price,
                                category = p.category,
                                brand = p.brand.name
                            };

                    dataGridView1.DataSource = q.ToList();
                }
            }
            

            
        }

        private void SortedProducts_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
