using System.Data;

namespace HED_Editor
{
    public partial class Form1 : Form
    {
        DataTable data = new DataTable();
        DataTable backup_data = new DataTable();
        bool ends_with_semicolon = false;
        public Form1()
        {
            InitializeComponent();
            // Optimalizace pro gridview
            typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(dgvData, true, null);
        }
        private void load_data() // Nahrát data
        {
            // Testy
            string path = textPath.Text;
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Nejprve prosím vyberte složku s daty.", "Chybí složka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Zadaná složka neexistuje. Zkontrolujte cestu.", "Neplatná složka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] files = Directory.GetFiles(path, "*.hed");
            if (files.Length == 0)
            {
                MessageBox.Show("Ve vybrané složce nejsou žádné HED soubory.", "Prázdná složka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Určit první soubor a uložit header k porovnání s ostatními soubory
            string[] rows = File.ReadAllLines(files[0]);
            string compare_header = rows[0];

            // Ošetření pro případ, že řádek končí středníkem
            if (compare_header.EndsWith(";"))
            {
                ends_with_semicolon = true;
                compare_header = compare_header.Remove(compare_header.Length - 1);
            }

            string[] main_header = compare_header.Split(';');

            // Vytvořit datatable pro zobrazení dat a zálohu dat
            dgvData.DataSource = null;
            data = new DataTable();
            backup_data = new DataTable();

            // Přidat sloupec pro název souboru pro pozdější zápis dat zpět do souborů
            data.Columns.Add("File");


            // Naplnění datatable
            foreach (string column in main_header)
            {
                data.Columns.Add(column);
            }

            foreach (string file in files)
            {
                string[] row = File.ReadAllLines(file);
                string file_name = Path.GetFileName(file);
                if (ends_with_semicolon)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i].EndsWith(";")) row[i] = row[i].Remove(row[i].Length - 1);
                    }
                }
                string header = row[0];
                if (header != compare_header)
                {
                    // Vyhodit popup chybu, že soubor má špatný header
                    MessageBox.Show("Soubor " + file + " má špatný header!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 1; i < row.Length; i++)
                {
                    row[i] = file_name + ";" + row[i];
                    string[] columns = row[i].Split(";");
                    data.Rows.Add(columns);
                }
            }

            // Vytvořit zálohu pro případ, že uživatel chce původní data zálohovat
            backup_data = data.Copy();

            // Naplnit dropdown pro offset sloupců
            List<string> column_list = new List<string>();
            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName != "File" && column.ColumnName != "Description" && column.ColumnName != "Program No.")
                {
                    column_list.Add(column.ColumnName);
                }
            }

            dropdownColumns.DataSource = column_list;

            // Zobrazit data v datagridview
            dgvData.DataSource = data;
        }
        private void write_data_to_files(string path, DataTable data)
        {
            // Vytvořit string pro header
            List<string> column_list = new List<string>();
            string column_string = "";
            foreach (DataColumn column in data.Columns)
            {
                column_list.Add(column.ColumnName);
            }
            foreach (string item in column_list)
            {
                if (item != "File")
                {
                    column_string = column_string + item + ";";
                }
            }
            if (!ends_with_semicolon) column_string = column_string.Remove(column_string.Length - 1);

            // Vytvořit seznam všech unikátních názvů souborů
            List<string> files_from_table = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                string file_name = row[0].ToString(); // Sloupec "File"

                if (!files_from_table.Contains(file_name))
                {
                    files_from_table.Add(file_name);
                }
            }
            // Zápis dat podle souborů
            foreach (string file in files_from_table)
            {
                List<string> file_rows = new List<string>();
                file_rows.Add(column_string);

                foreach (DataRow row in data.Rows)
                {
                    if (row[0].ToString() == file)
                    {
                        string export_data = "";
                        for (int i = 1; i < column_list.Count(); i++)
                        {
                            export_data = export_data + row[i].ToString() + ";";
                        }
                        if (!ends_with_semicolon) export_data = export_data.Remove(export_data.Length - 1);
                        file_rows.Add(export_data);
                    }
                }

                string full_path = Path.Combine(path, file);
                // Vytvořit složku, pokud neexistuje -- primárně pro zálohu
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllLines(full_path, file_rows);
            }
        }
        private void offset(DataTable data, int offset, string column)
        {
            // Offset hodnot ve sloupci o zadanou hodnotu
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (data.Columns[i].ColumnName == column)
                {
                    for (int j = 0; j < data.Rows.Count; j++)
                    {
                        if (double.TryParse(data.Rows[j][i].ToString(), out double value))
                        {
                            data.Rows[j][i] = (value + offset).ToString();
                        }
                    }
                }
            }
        }
        private void btnVybratSoubor_Click(object sender, EventArgs e) // button - otevřít, pro vybrání cesty ke složce
        {
            // Otevřít dialog pro výběr složky.
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Vyberte složku s CSV soubory";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textPath.Text = dialog.SelectedPath;
            }

            load_data();
        }
        private void btnNahratData_Click(object sender, EventArgs e) => load_data(); // button - nahrát data
        private void btnUlozit_Click(object sender, EventArgs e) // button - uložit data, popř. záloha
        {
            // Získat cestu pro uložení dat i zálohy
            string path = textPath.Text;
            string backup_path = path + "_backup_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            // Zapsat data do souborů
            write_data_to_files(path, data);
            if (checkBackup.Checked) write_data_to_files(backup_path, backup_data);

            MessageBox.Show("Data úspěšně uložena!", "Data uložena", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnOffset_Click(object sender, EventArgs e) // button - aplikuje offset pro sloupec
        {
            // Aplikovat offset na zvolený sloupec
            int offset_value = (int)offsetInt.Value;
            if (offset_value == 0)
            {
                MessageBox.Show("Offset nemůže být nula.", "Špatný Offset", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                offset(data, offset_value, dropdownColumns.SelectedItem.ToString());
            }
        }
    }
}
