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
    public partial class ShowAllProducts : Form
    {
        public ShowAllProducts()
        {
            InitializeComponent();
        }

        private void ShowAllProducts_Load(object sender, EventArgs e)
        {
            Model1 db = new Model1();

            var q = from p in db.products
                    
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
    }
}
