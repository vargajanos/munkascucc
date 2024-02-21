using cucc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace munkaido_nyilvantartas
{
    public partial class Form1 : Form
    {


        static List<Munkavallalo> munkavallalok = new List<Munkavallalo>();
        static List<Munkaido> munkaidok = new List<Munkaido>();
        static List<Eloleg> elolegek = new List<Eloleg>();



        static bool isLoaded = false;
        static bool isChanged = false;
        static int selectedIndex = -1;
        public Form1()
        {

            InitializeComponent();
            MunkavallalokOlvasas();
            ComboBoxFeltoltes();
            UpdateMunkaVallaloGrid();


        }

        private void MunkavallalokOlvasas()
        {
            try
            {
                StreamReader olvas = new StreamReader("munkavallalok.txt");
                while (!olvas.EndOfStream)
                {
                    munkavallalok.Add(new Munkavallalo(olvas.ReadLine()));
                }
                olvas.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Baj van a Munkavállalók olvasásánál");
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Valamelyik kötelező adat hiányzik");
            }
            else
            {
                string sor = textBox1.Text + ';' + textBox2.Text + ';' + comboBox1.Text + ';' + numericUpDown1.Value + ';' + textBox4.Text + ';' + textBox5.Text;

                munkavallalok.Add(new Munkavallalo(sor));

                isLoaded = false;
                isChanged = true;

                ComboBoxFeltoltes();
                UpdateMunkaVallaloGrid();
                DolgokUritese();
            }


        }

        private void DolgokUritese()
        {
            munkavalalloGrid.ClearSelection();

            elolegDataGrid.ClearSelection();



            munkavallalo_felveszBTN.Enabled = true;
            munkavallalo_modositBTN.Enabled = false;
            munkavallalo_torolBTN.Enabled = false;


            eloleg_felveszBTN.Enabled = true;
            eloleg_modositBTN.Enabled = false;
            eloleg_torolBTN.Enabled = false;


            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            numericUpDown1.Value = 0;
            textBox4.Text = "";
            textBox5.Text = "";

            ElolegComboBox.Text = "";
            elolegNumericCucc.Value = 0;

        }

        private void ComboBoxFeltoltes()
        {
            nameCBOX.Items.Clear();
            comboBox1.Items.Clear();
            ElolegComboBox.Items.Clear();

            for (int i = 0; i < munkavallalok.Count; i++)
            {
                if (!comboBox1.Items.Contains(munkavallalok[i].Beosztas))
                {
                    comboBox1.Items.Add(munkavallalok[i].Beosztas);
                }
            }

            foreach (Munkavallalo item in munkavallalok)
            {
                if (!nameCBOX.Items.Contains(item.Nev))
                {
                    nameCBOX.Items.Add(item.Nev);
                    ElolegComboBox.Items.Add(item.Nev);
                }
            }


        }

        private void UpdateMunkaVallaloGrid()
        {

            munkavalalloGrid.Rows.Clear();
            munkavallalok.ForEach(item =>
            {
                munkavalalloGrid.Rows.Add();
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[0].Value = item.Nev;
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[1].Value = item.Lakcim;
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[2].Value = item.Beosztas;
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[3].Value = item.Oraber;
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[4].Value = item.Email;
                munkavalalloGrid.Rows[munkavalalloGrid.Rows.Count - 1].Cells[5].Value = item.Telefonszam;


            });

            isLoaded = true;



            if (isChanged)
            {
                SaveToFile();
            }


        }


        private void munkavallalo_modositBTN_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Valamelyik kötelező adat hiányzik");
            }
            else
            {

                int index = munkavalalloGrid.CurrentRow.Index;

                munkavallalok[index].Nev = textBox1.Text;
                munkavallalok[index].Lakcim = textBox2.Text;
                munkavallalok[index].Beosztas = comboBox1.Text;
                munkavallalok[index].Oraber = Convert.ToInt32(numericUpDown1.Value);
                munkavallalok[index].Email = textBox4.Text;
                munkavallalok[index].Telefonszam = textBox5.Text;

                isLoaded = false;
                isChanged = true;

                UpdateMunkaVallaloGrid();
                MessageBox.Show("Adat módosítva");
            }
        }

        private void munkavalalloGrid_SelectionChanged(object sender, EventArgs e)
        {
            int index;
            if (isLoaded)
            {
                if (selectedIndex == -1)
                {
                    index = munkavalalloGrid.CurrentRow.Index;
                }
                else
                {
                    index = selectedIndex;
                }


                if (index > -1)
                {

                    munkavallalo_felveszBTN.Enabled = false;
                    munkavallalo_modositBTN.Enabled = true;
                    munkavallalo_torolBTN.Enabled = true;

                    textBox1.Text = munkavalalloGrid.Rows[index].Cells[0].Value.ToString();
                    textBox2.Text = munkavalalloGrid.Rows[index].Cells[1].Value.ToString();
                    comboBox1.Text = munkavalalloGrid.Rows[index].Cells[2].Value.ToString();
                    numericUpDown1.Value = Convert.ToInt32(munkavalalloGrid.Rows[index].Cells[3].Value);
                    textBox4.Text = munkavalalloGrid.Rows[index].Cells[4].Value.ToString();
                    textBox5.Text = munkavalalloGrid.Rows[index].Cells[5].Value.ToString();

                }
            }


        }

        private void munkavallalo_torolBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törlöd az adatot?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isLoaded = false;
                isChanged = true;

                munkavallalok.RemoveAt(munkavalalloGrid.CurrentRow.Index);
                UpdateMunkaVallaloGrid();
                MessageBox.Show("Adat törölve");

            }
        }


        private void SaveToFile()
        {
            try
            {
                StreamWriter file = new StreamWriter("munkavallalok.txt");
                foreach (var item in munkavallalok)
                {
                    file.WriteLine("{0};{1};{2};{3};{4};{5}",
                        item.Nev,
                        item.Lakcim,
                        item.Beosztas,
                        item.Oraber,
                        item.Email,
                        item.Telefonszam);
                }
                file.Close();

            }
            catch (IOException ex)
            {
                MessageBox.Show("Hiba a mentéskor!", ex.Message);

            }




        }

        private void felvesz_munkaido_btn_Click(object sender, EventArgs e)
        {
            if (nameCBOX.Text != "" && startTBOX.Text != "" && endTBOX.Text != "")
            {
                isLoaded = false;
                Munkavallalo alkalm = munkavallalok.Find(item => item.Nev.Equals(nameCBOX.Text));
                munkaidok.Add(new Munkaido(alkalm, dateDTP.Value, startTBOX.Text, endTBOX.Text));
                MunkaidoGridUpdate();
                MessageBox.Show("Hozzá van adva az új adat!");
            }
            else
            {
                MessageBox.Show("Kérem adjon meg minden adatot!");
            }
        }

        private void MunkaidoGridUpdate()
        {
            munkaido_datagrid.Rows.Clear();
            munkaidok.ForEach(item =>
            {
                munkaido_datagrid.Rows.Add();
                munkaido_datagrid.Rows[munkaido_datagrid.Rows.Count - 1].Cells[0].Value = item.Alkalmazott.Nev;
                munkaido_datagrid.Rows[munkaido_datagrid.Rows.Count - 1].Cells[1].Value = item.Date.ToShortDateString();
                munkaido_datagrid.Rows[munkaido_datagrid.Rows.Count - 1].Cells[2].Value = item.Start.ToString();
                munkaido_datagrid.Rows[munkaido_datagrid.Rows.Count - 1].Cells[3].Value = item.End.ToString();
            });

            munkaido_datagrid.ClearSelection();
            ;
            isLoaded = true;
        }

        private void munkavalalloGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DolgokUritese();
            }
        }

        private void eloleg_felveszBTN_Click(object sender, EventArgs e)
        {
            if (elolegGroupBox.Text == "" || elolegDateTimePicker.Text == "" || elolegNumericCucc.Value == 0)
            {
                MessageBox.Show("Valamelyik kötelező adat hiányzik");
            }
            else
            {
                Munkavallalo alkalm = munkavallalok.Find(item => item.Nev.Equals(ElolegComboBox.Text));
                elolegek.Add(new Eloleg(alkalm, elolegDateTimePicker.Value, Convert.ToInt32(elolegNumericCucc.Value)));

                isLoaded = false;
                isChanged = true;

                UpdateElolegGrid();
                DolgokUritese();
            }


        }

        private void UpdateElolegGrid()
        {
            elolegDataGrid.Rows.Clear();
            elolegek.ForEach(item =>
            {
                elolegDataGrid.Rows.Add();
                elolegDataGrid.Rows[elolegDataGrid.Rows.Count - 1].Cells[0].Value = item.Alkalmazott.Nev;
                elolegDataGrid.Rows[elolegDataGrid.Rows.Count - 1].Cells[1].Value = item.Datum.ToShortDateString();
                elolegDataGrid.Rows[elolegDataGrid.Rows.Count - 1].Cells[2].Value = item.Osszeg.ToString();

            });

            elolegDataGrid.ClearSelection();

            isLoaded = true;
        }

        private void eloleg_modositBTN_Click(object sender, EventArgs e)
        {




        }

        private void elolegDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            int index;
            if (isLoaded)
            {
                if (selectedIndex == -1)
                {
                    index = munkavalalloGrid.CurrentRow.Index;
                }
                else
                {
                    index = selectedIndex;
                }


                if (index > -1)
                {

                    eloleg_felveszBTN.Enabled = false;
                    eloleg_modositBTN.Enabled = true;
                    eloleg_torolBTN.Enabled = true;

                    ElolegComboBox.Text = elolegDataGrid.Rows[index].Cells[0].Value.ToString();
                    elolegDateTimePicker.Text = elolegDataGrid.Rows[index].Cells[1].Value.ToString();
                    elolegNumericCucc.Text = elolegDataGrid.Rows[index].Cells[2].Value.ToString();


                }
            }
        }
    }
}
