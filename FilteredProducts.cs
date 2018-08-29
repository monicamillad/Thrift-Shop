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
    public partial class FilteredProducts : Form
    {
        public FilteredProducts()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tx = sender as TextBox;
            double test;
            if (!Double.TryParse(tx.Text, out test))
            {
                MessageBox.Show("Please enter only numbers.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal d = (decimal)Double.Parse(price.Text);

            Model1 db = new Model1();

            var q = from p in db.products
                    where (p.price < d)
                    select new
                    {
                        name = p.name,
                        price = p.price,
                        category = p.category,
                        brand = p.brand.name
                    };

            dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void FilteredProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
