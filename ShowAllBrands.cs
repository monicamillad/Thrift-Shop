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
    public partial class ShowAllBrands : Form
    {
        public ShowAllBrands()
        {
            InitializeComponent();
        }

        private void ShowAllBrands_Load(object sender, EventArgs e)
        {
            Model1 db = new Model1();

            var q = from b in db.brands
                    orderby b.products.Count descending
                    select new
                    {
                        name = b.name,
                        products = b.products.Count
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
