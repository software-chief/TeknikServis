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
    public partial class FrmArizaliUrunKaydi : DevExpress.XtraEditors.XtraForm
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(TxtID.Text);
            t.GELISTARIH = DateTime.Parse(TxtTarih.Text);
            t.PERSONEL = short.Parse(TxtPersonel.Text);
            t.URUNSERINO = TxtSeriNo.Text;
            t.URUNDURUM = true;



            t.URUNDURUMDETAY = TxtDetay.Text;
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arıza Girişi Gerçekleştirilmiştir.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}