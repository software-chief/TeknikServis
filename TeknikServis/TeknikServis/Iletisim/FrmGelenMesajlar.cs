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
    public partial class FrmGelenMesajlar : DevExpress.XtraEditors.XtraForm
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                            x.ID,
                                            x.ADSOYAD,
                                            x.KONU,
                                            x.MAIL,
                                            x.MESAJ
                                       }).ToList();
        }
    }
}