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
    public partial class FrmUrunSatis : DevExpress.XtraEditors.XtraForm
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(TxtID.Text);
            t.MUSTERI = int.Parse(TxtMusteri.Text);
            t.PERSONEL = short.Parse(TxtPersonel.Text);
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.ADET = byte.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Satış işleminiz başarıyla gerçekleştirilmiştir.", "Bilgi",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}