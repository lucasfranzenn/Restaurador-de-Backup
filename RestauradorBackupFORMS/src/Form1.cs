using MySqlConnector;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ChangeConfig;

namespace RestauradorBackupFORMS
{
    public partial class form : Form
    {
        private string host = "10.1.1.220";
        private string user = "root";
        private string pwd = "vssql";
        private int port;
        private string dir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        private string nomeBackup;
        private string nomeBanco;
        private MySqlConnection con;

        public string Host { get => host; set => host = value; }
        public int Port { get => port; set => port = value; }
        public string User { get => user; set => user = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Dir { get => dir; set => dir = value; }
        public string NomeBackup { get => nomeBackup; set => nomeBackup = value; }
        public MySqlConnection Con { get => con; set => con = value; }
        public string NomeBanco { get => nomeBanco; set => nomeBanco = value; }

        public form()
        {
            InitializeComponent();
        }

        private bool showDatabase()
        {

            if (text_nomeBanco.Text == "")
            {
                MessageBox.Show("Por favor, insira algum nome de banco!", "Erro!");
                return false;
            }

            nomeBanco = text_nomeBanco.Text;

            con.Open();
            nomeBanco = text_nomeBanco.Text;
            string procuraBanco = $"SHOW DATABASES LIKE '{nomeBanco}'";

            MySqlCommand cmd = new MySqlCommand(procuraBanco, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                StringBuilder bancosEncontrados = new StringBuilder();
                bancosEncontrados.AppendLine("BANCOS EXISTENTES: ");

                reader.Close();
                procuraBanco = $"SHOW DATABASES LIKE '{nomeBanco}%'";
                cmd = new MySqlCommand(procuraBanco, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bancosEncontrados.AppendLine(reader.GetString(0));
                }

                reader.Close();

                string mensagem = bancosEncontrados.ToString();
                MessageBox.Show(mensagem, "Banco não pode ser criado pois já existe!");

                con.Close();
                return false;

            }
            else
            {

                con.Close();
                return true;
            }

        }

        private void conectaDB()
        {
            try
            {
                Con = new MySqlConnection($"Server={host};Port={Port};User Id={user};Password={pwd};");
                Con.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve falha na conexão!", ".:: ERRO ::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Convert.ToString(Con.State) == "Open")
                {
                    lbl_statusCon.Text = $"CONECTADO {host} {port}";
                    lbl_statusCon.ForeColor = Color.Green;
                    gb_backup.Visible = true;
                    lbl_credit.Visible = true;
                    linkLabel1.Visible = true;
                }
                else
                {
                    lbl_statusCon.Text = "FALHA NA CONEXÃO";
                    lbl_statusCon.ForeColor = Color.Red;
                    gb_backup.Visible = false;
                    lbl_credit.Visible = false;
                    linkLabel1.Visible = false;
                }

                Con.Close();


            }
        }

        private void bttn_3307_CheckedChanged(object sender, EventArgs e)
        {
            Port = 3307;
            conectaDB();
        }

        private void bttn_3306_CheckedChanged(object sender, EventArgs e)
        {
            Port = 3306;
            conectaDB();
        }


        private void deleteCREATEUSE(string caminhoCompleto)
        {
            bool validaArq = false;

            List<string> linhas_lidas = new List<string>();
            try
            {
                using (StreamReader arqv = new StreamReader(caminhoCompleto, Encoding.GetEncoding("latin1")))
                {
                    int lineNumber = 0;
                    string line;
                    while ((line = arqv.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (lineNumber <= 50)
                        {
                            linhas_lidas.Add(line);

                            if (line.ToUpper().Contains("CREATE DATABASE") || line.ToUpper().Contains("USE"))
                            {
                                validaArq = true;
                                linhas_lidas.Remove(line);
                            }
                        }
                        else
                        {
                            if (validaArq == false)
                            {
                                break;
                            }
                            linhas_lidas.Add(line);
                        }
                    }
                }

                if (validaArq == true)
                {
                    using (StreamWriter arquivoEscrita = new StreamWriter(caminhoCompleto, false, Encoding.GetEncoding("latin1")))
                    {
                        foreach (string linha in linhas_lidas)
                        {
                            arquivoEscrita.WriteLine(linha);
                        }
                    }
                }

                MessageBox.Show("Linhas CREATE e USE foram deletadas!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "OCORREU UM ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            finally
            {
                linhas_lidas.Clear();
            }
        }

        private void createDatabase()
        {
            showDatabase();

            con.Open();
            string create_database = $"CREATE DATABASE `{nomeBanco}`";

            try
            {
                MySqlCommand cmd = new MySqlCommand(create_database, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Banco `{nomeBanco}` criado com sucesso! ", "Sucesso!");
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void atualizaDB()
        {

            string atualizaPath = "C:\\Visual Software\\MyCommerce\\AtualizarDB.exe";
            string configPath = "C:\\Visual Software\\MyCommerce\\config.ini";
            string portaAntiga = null;
            string bancoAntigo = null;

            string[] lines = File.ReadAllLines(configPath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("PortaServidor="))
                {
                    portaAntiga = lines[i].Split('=')[1];

                    lines[i] = $"PortaServidor={port}";
                }
                else if (lines[i].StartsWith("Database="))
                {
                    bancoAntigo = lines[i].Split('=')[1];

                    lines[i] = $"Database={nomeBanco}";
                }
                else if (lines[i].StartsWith("IPServidor="))
                {
                    bancoAntigo = lines[i].Split('=')[1];

                    lines[i] = $"IPServidor={host}";
                }
                else if (lines[i].StartsWith("Relatorios="))
                {
                    break;
                }
            }

            File.WriteAllLines(configPath, lines);

            this.Hide();
            Process process = new Process();

            process.StartInfo.FileName = atualizaPath;

            process.Start();

            Thread.Sleep(250);
            SendKeys.Send("{TAB}");
            SendKeys.Send("{ENTER}");

            process.WaitForExit();

            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;


        }

        private void restaurarBanco()
        {
            string restore_backup = $"mysql -h {host} -u {user} -p{pwd} -P {port} -f {nomeBanco} < \"{nomeBackup}\"";

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = dir
            };

            Process process = new Process()
            {
                StartInfo = psi
            };

            MessageBox.Show("Clique em OK", "Backup sendo restaurado...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            process.Start();
            process.StandardInput.WriteLine(restore_backup);

            process.StandardInput.Close();

            process.WaitForExit();
            SoundPlayer simpleSound = new SoundPlayer(dir + "/backupDone.wav");
            simpleSound.Play();
            MessageBox.Show("Backup restaurado com sucesso!", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            process.Close();
        }

        private void bttn_fileSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = dir;
            dialog.Filter = "Arquivos SQL e RAR (*.sql;*.rar)|*.sql;*.rar";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                text_nomeBackup.Text = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_nomeBackup.Text == "")
            {
                MessageBox.Show("Insira algum nome de backup!", "Aviso!");
                return;
            }
            nomeBackup = text_nomeBackup.Text;

            if (Path.GetExtension(nomeBackup).Equals(".sql"))
            {
                deleteCREATEUSE(nomeBackup);

            }
            else if (Path.GetExtension(NomeBackup).Equals(".rar"))
            {
                openRar();

                deleteCREATEUSE(nomeBackup);
            }


        }

        private void openRar()
        {
            using (var arquivo = ArchiveFactory.Open(nomeBackup))
            {
                try
                {
                    foreach (var entry in arquivo.Entries)
                    {
                        if (!entry.IsDirectory && entry.Key.EndsWith(".sql"))
                        {
                            string caminhoExtrair = dir + "Backups";

                            entry.WriteToDirectory(caminhoExtrair, new ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });

                            caminhoExtrair += "/" + entry.Key;

                            text_nomeBackup.Text = caminhoExtrair;
                            nomeBackup = caminhoExtrair;

                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERRO!");
                }
            }
        }

        private void text_nomeBanco_Leave(object sender, EventArgs e)
        {
            nomeBanco = text_nomeBanco.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!cb_createDb.Checked && !cb_excluir.Checked && !cb_restauraBackup.Checked &&
                !cb_atualizadb.Checked && !cb_updates.Checked)
            {
                MessageBox.Show("Por favor, selecione alguma opção", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cb_createDb.Checked)
            {
                if (text_nomeBanco.Text == "")
                {
                    MessageBox.Show("Por favor, insira algum nome de banco!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (showDatabase() == true)
                {
                    createDatabase();

                }
                else
                {
                    return;
                }

            }

            if (cb_excluir.Checked)
            {
                if (text_nomeBackup.Text == "")
                {
                    MessageBox.Show("Insira algum nome de backup!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                nomeBackup = text_nomeBackup.Text;

                if (Path.GetExtension(nomeBackup).Equals(".sql"))
                {
                    deleteCREATEUSE(nomeBackup);

                }
                else if (Path.GetExtension(NomeBackup).Equals(".rar"))
                {
                    openRar();

                    deleteCREATEUSE(nomeBackup);
                }
            }

            if (cb_restauraBackup.Checked)
            {
                if (text_nomeBackup.Text == "" || text_nomeBanco.Text == "")
                {
                    MessageBox.Show("Faltou alguma informação!\nVerifique e atualize", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                string procuraBanco = $"SHOW DATABASES LIKE '{nomeBanco}'";
                MySqlCommand cmd = new MySqlCommand(procuraBanco, con);
                MySqlDataReader reader = cmd.ExecuteReader();


                if (!reader.HasRows)
                {
                    MessageBox.Show("Banco não foi encontrado!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return;
                }

                con.Close();
                nomeBackup = text_nomeBackup.Text;
                //encondeutf8();
                restaurarBanco();
            }

            if (cb_atualizadb.Checked)
            {
                if (text_nomeBanco.Text == "")
                {
                    MessageBox.Show("Por favor, insira algum nome de banco!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                nomeBanco = text_nomeBanco.Text;
                string procuraBanco = $"SHOW DATABASES LIKE '{nomeBanco}'";

                MySqlCommand cmd = new MySqlCommand(procuraBanco, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        atualizaDB();
                    }
                    else
                    {
                        MessageBox.Show("Banco não foi encontrado", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                finally
                {
                    con.Close();
                }

            }

            if (cb_updates.Checked)
            {
                if (text_nomeBanco.Text == "")
                {
                    MessageBox.Show("Por favor, insira algum nome de banco!", "Aviso!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                string useBanco = $"use `{nomeBanco}`";
                string[] updates = {
                    "UPDATE usuarios SET PASSWORD = 'W'",
                    "UPDATE usuarios_supervisores SET Password = '4'"};

                try
                {
                    MySqlCommand cmd = new MySqlCommand(useBanco, con);
                    cmd.ExecuteNonQuery();

                    for(int i=0; i< updates.Length; i++)
                    {
                        cmd = new MySqlCommand(updates[i], con);
                        cmd.ExecuteNonQuery();
                    }


                    MessageBox.Show("Updates realizados com sucesso:\n\n" +
                        " -Senha=1;\n" +
                        " -SenhaSupervisor=1;\n" +
                        " -Telefone=9999999999;\n" +
                        "", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SendKeys.Send("{ESC}");
                    Thread.Sleep(250);

                }
                finally
                {
                    con.Close();
                }



            }

            /*if (cb_pwdsupervisor.Checked)
            {
                if (text_nomeBanco.Text == "")
                {
                    MessageBox.Show("Por favor, insira algum nome de banco!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                string useBanco = $"use `{nomeBanco}`";
                string updatePWD = $"UPDATE usuarios_supervisores SET Password = '4'";

                try
                {
                    MySqlCommand cmd = new MySqlCommand(useBanco, con);
                    cmd.ExecuteNonQuery();

                    cmd = new MySqlCommand(updatePWD, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Todas as senhas de supervisores foram atualizadas para 1", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                }


            }*/


        }

        private void encondeutf8()
        {
            string encoder = File.ReadAllText(nomeBackup);

            File.WriteAllText(nomeBackup, encoder, Encoding.UTF8);
        }

        private void text_nomeBackup_MouseLeave(object sender, EventArgs e)
        {
            nomeBackup = text_nomeBackup.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (bttn_outro.Checked)
            {
                box_porta.Enabled = false;
                port = Convert.ToInt32(text_porta.Text);
                host = text_host.Text;

                lbl_porta.Enabled = true;
                text_porta.Enabled = true;
                lbl_Host.Enabled = true;
                text_host.Enabled = true;

                if (bttn_3306.Checked == true)
                {
                    port = 3306;
                    text_porta.Text = "3306";   

                }
                else if (bttn_3307.Checked == true)
                {
                    port = 3307;
                    text_porta.Text = "3307";
                }
                    conectaDB();
            }

        }

        private void bttn_220_CheckedChanged(object sender, EventArgs e)
        {
            if (bttn_220.Checked)
            {
                box_porta.Enabled = true;

                host = "10.1.1.220";

                lbl_porta.Enabled = false;
                text_porta.Enabled = false;
                lbl_Host.Enabled = false;
                text_host.Enabled = false;
                conectaDB();
            }
        }

        private void text_host_Leave(object sender, EventArgs e)
        {
            host = text_host.Text;

            conectaDB();
        }

        private void text_porta_Leave(object sender, EventArgs e)
        {
            port = Convert.ToInt32(text_porta.Text);

            conectaDB();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forum.visualsoftware.inf.br/index.php");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label4.Text);
            ToolTip tt = new ToolTip();
            tt.Show("Copiado para Área de Transferência", label4, -45, 20, 960);

        }

        private void cmd_atualiza()
        {
            string configPath = "C:\\Visual Software\\MyCommerce\\config.ini";
            string[] lines = File.ReadAllLines(configPath);
            bttn_3306.Checked = true;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("PortaServidor="))
                {
                    port = Convert.ToInt32(lines[i].Split('=')[1]);
                    if (port == 3306) bttn_3306.Checked = true; else if (port == 3307) bttn_3307.Checked = true; else text_porta.Text = (lines[i].Split('=')[1]);
                }
                else if (lines[i].StartsWith("Database="))
                {
                    nomeBanco = lines[i].Split('=')[1];
                    text_nomeBanco.Text = nomeBanco.Trim();
                }
                else if (lines[i].StartsWith("IPServidor="))
                {
                    host = lines[i].Split('=')[1];
                    if (host == "10.1.1.220") bttn_220.Checked = true; else bttn_outro.Checked = true;
                }
                else if (lines[i].StartsWith("Relatorios="))
                {
                    break;
                }
            }

            conectaDB();
        }

        private void form_Load(object sender, EventArgs e)
        {
            cmd_atualiza();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 configForm = new Form2();
            configForm.Show();
        }

        private void bttn_reloadconfig_Click(object sender, EventArgs e)
        {
           cmd_atualiza();
           ToolTip tt = new ToolTip();
           tt.Show("Configurações de banco sincronizadas!", bttn_reloadconfig, 20, 0, 960);
        }
    }
}
