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
    public partial class FrmYeniKategori : DevExpress.XtraEditors.XtraForm
    {
        public FrmYeniKategori()
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

            if(TxtKategoriAd.Text != "" && TxtKategoriAd.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.AD = TxtKategoriAd.Text;

                db.TBLKATEGORI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori başarıyla eklenmiştir.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kategori adı boş geçilemez", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            
        }

        private void FrmYeniKategori_Load(object sender, EventArgs e)
        {

        }
    }
}