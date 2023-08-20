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

namespace TeknikServis.Formlar
{
    public partial class FrmCariEkle : DevExpress.XtraEditors.XtraForm
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.IL = TxtIl.Text;
            t.ILCE = TxtIlce.Text;
            t.BANKA = TxtBanka.Text;
            t.MAIL = TxtMail.Text;  
            t.TELEFON = TxtTelefon.Text;
            t.VERGIDAIRESI = TxtVD.Text;
            t.VERGINO = TxtVN.Text;

            db.TBLCARI.Add(t);
            db.SaveChanges();

            MessageBox.Show("Cari Eklemesi Başarılı", "Bilgi", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }
}