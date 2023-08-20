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
    public partial class FrmYeniPersonel : DevExpress.XtraEditors.XtraForm
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.MAIL = TxtMail.Text;
            t.TELEFON = TxtTelefon.Text;
           
            t.DEPARTMAN = byte.Parse(TxtDepartman.Text.ToString());

            db.TBLPERSONEL.Add(t);
            db.SaveChanges();

            MessageBox.Show("Yeni personel hayırlı olsun.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniPersonel_Load(object sender, EventArgs e)
        {

        }
    }
}