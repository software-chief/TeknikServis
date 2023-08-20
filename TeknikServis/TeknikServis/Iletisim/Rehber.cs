using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Iletisim
{
    public partial class Rehber : DevExpress.XtraEditors.XtraForm
    {
        public Rehber()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void Rehber_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLCARI
                                      select new
                                      {
                                          x.AD,
                                          x.SOYAD,
                                          x.TELEFON,
                                          x.MAIL
                                      }).ToList();
        }
    }
}