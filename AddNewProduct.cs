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
    public partial class AddNewProduct : Form
    {
        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            String n = name.Text;
            double p = Double.Parse(price.Text);
            String c = category.Text;
            String b = brand.Text;

            Boolean check = false;
            int id = -1;

            Model1 db = new Model1();
            var brands = (from r in db.brands select new { name = r.name , id = r.id }).ToList() ;

            foreach( var bb in brands)
            {
                if( bb.name.Equals(b) )
                {
                    check = true;
                    id = bb.id;
                    break;
                }
            }

            if( check)
            {
                
                db.products.Add(new product { id = db.products.Count() , name = n , price = (decimal)p , category = c , brand_id = id });

                db.SaveChanges();

                ShowAllProducts f = new ShowAllProducts();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("This brand does not exist !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
