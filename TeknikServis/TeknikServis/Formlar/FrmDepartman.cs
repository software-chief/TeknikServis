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
    public partial class FrmDepartman : DevExpress.XtraEditors.XtraForm
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();

        void metot1()
        {
            var degerler = from u in db.TBLDEPARTMAN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.ACIKLAMA

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            metot1();
            labelControl12.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl16.Text = db.TBLPERSONEL.Count().ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)

        {

            TBLDEPARTMAN t = new TBLDEPARTMAN();

            if (TxtDepAd.Text.Length <= 50 && TxtDepAd.Text != "" &&
                TxtDepAciklama.Text.Length >= 1)
            {
                t.AD = TxtDepAd.Text;
                t.ACIKLAMA = TxtDepAciklama.Text;
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        
        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = TxtDepAd.Text;
            deger.ACIKLAMA = TxtDepAciklama.Text;
            
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi!", "Bilgi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

      

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtDepAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtDepAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi!", "Bilgi", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}