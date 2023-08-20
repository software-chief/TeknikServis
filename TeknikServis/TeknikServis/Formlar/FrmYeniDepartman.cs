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
    public partial class FrmYeniDepartman : DevExpress.XtraEditors.XtraForm
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();

            if (TxtDepAd.Text.Length <= 50 && TxtDepAd.Text != "")
            {
                t.AD = TxtDepAd.Text;
                t.ACIKLAMA = TxtDepAciklama.Text;


                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();

                MessageBox.Show("Departman Eklemesi Başarılı", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("İsteğiniz Gerçekleştirilemedi", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniDepartman_Load(object sender, EventArgs e)
        {

        }
    }
}