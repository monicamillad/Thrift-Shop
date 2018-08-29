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
    public partial class AddBrand : Form
    {
        public AddBrand()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            String n = name.Text;

            Model1 db = new Model1();

            db.brands.Add(new brand { id = db.brands.Count() , name = n });

            db.SaveChanges();

            ShowAllBrands f = new ShowAllBrands();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
