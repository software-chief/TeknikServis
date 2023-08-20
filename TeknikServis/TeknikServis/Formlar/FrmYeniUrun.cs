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
    public partial class FrmYeniUrun : DevExpress.XtraEditors.XtraForm
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORI = byte.Parse(TxtKategori.Text.ToString());
            t.MARKA = TxtMarka.Text;
            db.TBLURUN.Add(t);  
            db.SaveChanges();
            MessageBox.Show("Ürününüz başarıyla eklenmiştir.", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();

        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {

        }
    }
}